using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IAuthService
  {
    ErrorOr<Created> CreateUser(UserCreationDto user);

    ErrorOr<int> SignIn(UserSignInDto user);

    ErrorOr<Updated> UpdateUserRole(Guid userId, int role);
  }
}
