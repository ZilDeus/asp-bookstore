using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.Presistence;
using ErrorOr;

namespace BookStoreApi.Services
{
  public class UserService : IUserService
  {

    private readonly BookStoreDbContext _context;
    private readonly Mapper mapper;
    public UserService(BookStoreDbContext context)
    {
      _context = context;
      mapper = MappingConfig.InitializeAutomapper();
    }

    public ErrorOr<Deleted> DeleteUser(Guid userId)
    {
      _context.Users.Remove(_context.Users.Find(userId));
      _context.SaveChanges();
      return new Deleted();
    }

    public ErrorOr<UserDto> GetUser(Guid userId)
    {
      return mapper.Map<UserDto>(_context.Users.Find(userId));
    }

    public ErrorOr<List<ReportDto>> GetUserReports(Guid userId)
    {
      return mapper.Map<List<ReportDto>>(_context.Users.Find(userId).Reports);
    }

    public ErrorOr<List<ReviewDto>> GetUserReviews(Guid userId)
    {
      return mapper.Map<List<ReviewDto>>(_context.Users.Find(userId).Reviews);
    }

    public ErrorOr<List<UserDto>> GetUsers()
    {
      return mapper.Map<List<UserDto>>(_context.Users);
    }

    public ErrorOr<Updated> UpdateUser(Guid userId, UserDto updateUserDto)
    {
      var u = _context.Users.Find(userId);
      u.Name = updateUserDto.Username;
      u.Email = updateUserDto.Email;
      _context.Users.Update(u);
      _context.SaveChanges();
      return new Updated();
    }
  }
}
