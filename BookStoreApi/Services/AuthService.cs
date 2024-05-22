using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreApi.Dto;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApi.Services
{
  public class AuthService : IAuthService
  {
    private readonly BookStoreDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IConfiguration _config;

    public AuthService(BookStoreDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
        , IConfiguration config)
    {
      _context = context;
      _userManager = userManager;
      _signInManager = signInManager;
      _config = config;
    }

    public async Task<ErrorOr<Created>> CreateUser(UserCreationDto user)
    {
      var u = new AppUser();
      u.Name = user.Username;
      u.Email = user.Email;
      u.PasswordHash = user.Password;
      Claim[] userClaims =
        [
          new Claim(ClaimTypes.Email,user.Email),
          new Claim(ClaimTypes.Role,user.Role)
        ];
      await _userManager.AddClaimsAsync(u, userClaims);
      _context.Users.Add(u);
      _context.SaveChanges();
      return new Created();
    }

    public async Task<IResult> SignIn(UserSignInDto user)
    {
      var u = await _userManager.FindByEmailAsync(user.Email);
      if (user == null) return Results.NotFound();

      var result = await _signInManager.CheckPasswordSignInAsync(u!, user.Password, false);
      if (!result.Succeeded) return Results.BadRequest();

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var creds = new SigningCredentials(securityKey, SecurityAlgorithms.Sha256);

      var token = new JwtSecurityToken(
          issuer: _config["Jwt:Issuer"],
          audience: _config["Jwt:Audience"],
          claims: await _userManager.GetClaimsAsync(u),
          expires: DateTime.Now.AddHours(1),
          signingCredentials: creds
          );
      return Results.Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public ErrorOr<Updated> UpdateUserRole(Guid userId, string role)
    {
      var u = _context.Users.Find(userId);
      //Claim[] userClaims =
      //  [
      //    new Claim(ClaimTypes.Email,user.Email),
      //    new Claim(ClaimTypes.Role,user.Role)
      //  ];
      ////_context.UserClaims.Add
      //u.Role = (UserRoles)role;
      //_context.Users.Update(u);
      //_context.SaveChanges();
      return new Updated();
    }
  }
}
