using BookStoreApi.Dto;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
      _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(UserRegistrationDto registrationDto)
    {
      if (!ModelState.IsValid)
        return Problem("invalid input");

      var userCreationResult = await _service.CreateUser(registrationDto);
      return userCreationResult.Match(
          ok => Ok("user created succesfully"),
          errors => Problem(errors.First().Description)
          );
    }
    [HttpPost("log-in")]
    public async Task<IActionResult> logIn(UserLogInDto LogInDto)
    {
      if (!ModelState.IsValid)
        return Problem("invalid input");
      var userLogIn = await _service.LogIn(LogInDto);
      return userLogIn.Match(
          data => Ok(data),
          errors => Problem(errors.First().Description)
      );
    }
  }
}
