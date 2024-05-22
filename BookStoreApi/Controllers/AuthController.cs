using BookStoreApi.Dto;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authorization;
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
      return Ok(_service.CreateUser(user));
    }
    [HttpPost("log-in")]
    public IActionResult logIn(UserSignInDto user)
    {
      return Ok(_service.SignIn(user));
    }

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminTest()
    {
      return Ok("hello admin");
    }

    [HttpGet("manager")]
    [Authorize(Roles = "Manager")]
    public IActionResult ManagerTest()
    {
      return Ok("hello manager");
    }

    [HttpGet("user")]
    [Authorize(Roles = "User")]
    public IActionResult UserTest()
    {
      return Ok("hello user");
    }
  }
}
