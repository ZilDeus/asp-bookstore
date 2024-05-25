using BookStoreApi.Dto;
using BookStoreApi.Filters;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IUserService
  {
    ErrorOr<List<UserDto>> GetUsers(PaginationFilter paginationFilter);

    ErrorOr<UserDto> GetUser(Guid userId);

    ErrorOr<Deleted> DeleteUser(Guid userId);

    ErrorOr<Updated> UpdateUser(Guid userId, UserDto updateUserDto);

    ErrorOr<List<ReviewDto>> GetUserReviews(Guid userId, PaginationFilter paginationFilter);

    ErrorOr<List<ReportDto>> GetUserReports(Guid userId, PaginationFilter paginationFilter);
  }
}
