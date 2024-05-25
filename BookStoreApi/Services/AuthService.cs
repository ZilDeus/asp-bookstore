using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreApi.Dto;
using BookStoreApi.Entities;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApi.Services
{
  public class AuthService : IAuthService
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _configuration = configuration;
    }

    public async Task<ErrorOr<Created>> CreateUser(UserRegistrationDto registrationDto)
    {
      var userRole = Enum.GetName(typeof(UserRoles), registrationDto.Role)!;
      var userExsits = await _userManager.FindByEmailAsync(registrationDto.Email);
      if (userExsits != null)
        return Error.Conflict(description: "user already exsits");
      AppUser user = new AppUser
      {
        Email = registrationDto.Email,
        SecurityStamp = Guid.NewGuid().ToString(),
        UserName = registrationDto.Username,
      };
      var userCreationResult = await _userManager.CreateAsync(user, registrationDto.Password);
      if (!userCreationResult.Succeeded)
        return Error.Unexpected(description: "user could not be created");

      var roleExists = await _roleManager.RoleExistsAsync(userRole);
      if (!roleExists)
        await _roleManager.CreateAsync(new IdentityRole(userRole));

      roleExists = await _roleManager.RoleExistsAsync(userRole);
      if (roleExists)
        await _userManager.AddToRoleAsync(user, userRole);
      else
        return Error.Unexpected("role could not be created");

      return new Created();
    }

    public async Task<ErrorOr<string>> LogIn(UserLogInDto signInDto)
    {
      var user = await _userManager.FindByEmailAsync(signInDto.Email);

      if (user == null)
        return Error.NotFound(description: "user with this email not found");

      if (!await _userManager.CheckPasswordAsync(user, signInDto.Password))
        return Error.Unauthorized(description: "user with this email doesn't match this password");

      var userRoles = await _userManager.GetRolesAsync(user);

      var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName!),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

      foreach (var userRole in userRoles)
        authClaims.Add(new Claim(ClaimTypes.Role, userRole));

      string token = GenerateToken(authClaims);
      return token;
    }
    private string GenerateToken(IEnumerable<Claim> claims)
    {
      var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Issuer = _configuration["Jwt:Issuer"],
        Audience = _configuration["Jwt:Audience"],
        Expires = DateTime.UtcNow.AddHours(3),
        SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
        Subject = new ClaimsIdentity(claims)
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}
