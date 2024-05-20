using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IUserService
  {
    ErrorOr<List<UserDto>> GetUsers();

    ErrorOr<UserDto> GetUser(Guid userId);

    ErrorOr<Deleted> DeleteUser(Guid userId);

    ErrorOr<Updated> UpdateUser(Guid userId, UserDto updateUserDto);

    ErrorOr<List<ReviewDto>> GetUserReviews(Guid userId);

    ErrorOr<List<ReportDto>> GetUserReports(Guid userId);
  }
}
