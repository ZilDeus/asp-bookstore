using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IAuthService
  {
    Task<ErrorOr<Created>> CreateUser(UserCreationDto user);

    Task<IResult> SignIn(UserSignInDto user);

    ErrorOr<Updated> UpdateUserRole(Guid userId, string role);
  }
}
