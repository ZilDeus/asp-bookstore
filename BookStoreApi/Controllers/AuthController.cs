using BookStoreApi.Dto;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
  [Route("/api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _service;

    public AuthController(AuthService service)
    {
      _service = service;
    }

    [HttpPost("sign-up")]
    public IActionResult CreateUser(UserCreationDto user)
    {
      return _service.CreateUser(user).Match(
          ok => Ok("user created successfully"),
          errors => Problem(errors.ToString())
          );
    }
    [HttpPost("log-in")]
    public IActionResult logIn(UserSignInDto user)
    {
      return _service.SignIn(user).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }
    [HttpPost("{userId}/{role}")]
    public IActionResult ChangeUserRole(Guid userId, int role)
    {
      return _service.UpdateUserRole(userId, role).Match(
          ok => Ok("user role-update successfully"),
          errors => Problem(errors.ToString())
          );
    }
  }
}
