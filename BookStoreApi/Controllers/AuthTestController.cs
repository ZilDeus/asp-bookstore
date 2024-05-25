using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthTest : ControllerBase
{
  [HttpGet("all")]
  public IActionResult HiToValid()
  {
    return Ok("hi valid user!");
  }

  [Authorize(Roles = "Admin")]
  [HttpGet("admin")]
  public IActionResult HiAdmin()
  {
    return Ok("hi valid Admin!");
  }

  [Authorize(Roles = "Manager")]
  [HttpGet("manager")]
  public IActionResult HiManager()
  {
    return Ok("hi valid Manager!");
  }

  [Authorize(Roles = "User")]
  [HttpGet("user")]
  public IActionResult HiToUser()
  {
    return Ok("hi valid user!");
  }

}
