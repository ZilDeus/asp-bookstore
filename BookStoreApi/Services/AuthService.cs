using BookStoreApi.Dto;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using ErrorOr;

namespace BookStoreApi.Services
{
  public class AuthService : IAuthService
  {
    private readonly BookStoreDbContext _context;

    public AuthService(BookStoreDbContext context)
    {
      _context = context;
    }

    public ErrorOr<Created> CreateUser(UserCreationDto user)
    {
      var u = new AppUser();
      u.Username = user.Username;
      u.Email = user.Email;
      u.Password = user.Password;
      u.Role = (UserRoles)user.Role;
      _context.Users.Add(u);
      _context.SaveChanges();
      return new Created();
    }

    public ErrorOr<int> SignIn(UserSignInDto user)
    {
      //TODO: return the user token if sign-in is successfull
      throw new NotImplementedException();
    }

    public ErrorOr<Updated> UpdateUserRole(Guid userId, int role)
    {
      var u = _context.Users.Find(userId);
      u.Role = (UserRoles)role;
      _context.Users.Update(u);
      _context.SaveChanges();
      return new Updated();
    }
  }
}
