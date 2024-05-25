using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IAuthService
  {
    Task<ErrorOr<Created>> CreateUser(UserRegistrationDto registrationDto);

    Task<ErrorOr<string>> LogIn(UserLogInDto signInDto);
  }
}
