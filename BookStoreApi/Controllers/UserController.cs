using BookStoreApi.Dto;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
  [Route("/api/[controller]")]
  public class UserController : ControllerBase
  {

    private readonly IUserService _service;

    public UserController(UserService service)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
      return _service.GetUsers().Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{userId}")]
    public IActionResult GetUser(Guid userId)
    {
      return _service.GetUser(userId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(Guid userId)
    {
      return _service.DeleteUser(userId).Match(
          ok => Ok("user deleted successfully"),
          errors => Problem(errors.ToString())
          );
    }

    [HttpPut("{userId}")]
    public IActionResult UpdateUser(Guid userId, UserDto userUpdateDto)
    {
      return _service.UpdateUser(userId, userUpdateDto).Match(
          ok => Ok("user updated successfully"),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{userId}/review")]
    public IActionResult GetUserReviews(Guid userId)
    {

      return _service.GetUserReviews(userId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{userId}/report")]
    public IActionResult GetUserReports(Guid userId)
    {

      return _service.GetUserReports(userId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }
  }
}

