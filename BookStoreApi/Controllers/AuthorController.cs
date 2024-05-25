using BookStoreApi.Dto;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class AuthorController : ControllerBase
  {

    private readonly IAuthorService _service;

    public AuthorController(AuthorService service)
    {
      _service = service;
    }

    [HttpPost]
    public IActionResult AddAuthor(AuthorCreationDto author)
    {
      return _service.CreateAuthor(author).Match(
          ok => Ok("author created successfully"),
          errors => Problem(errors.ToString())
          );
    }
    [HttpGet]
    public IActionResult GetAuthors()
    {
      return _service.GetAuthors().Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }
    [HttpGet("{authorId}")]
    public IActionResult GetAuthor(Guid authorId)
    {
      return _service.GetAuthor(authorId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpDelete("{authorId}")]
    public IActionResult DeleteAuthor(Guid authorId)
    {
      return _service.DeleteAuthor(authorId).Match(
          ok => Ok("author deleted successfully"),
          errors => Problem(errors.ToString())
          );
    }

    [HttpPut("{authorId}")]
    public IActionResult UpdateAuthor(Guid authorId, AuthorDto authorUpdateDto)
    {

      return _service.UpdateAuthor(authorId, authorUpdateDto).Match(
          ok => Ok("author updated successfully"),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{authorId}/review")]
    public IActionResult GetAuthorReviews(Guid authorId)
    {
      return _service.GetAuthorReviews(authorId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{authorId}/books")]
    public IActionResult GetAuthorBooks(Guid authorId)
    {
      return _service.GetAuthorBooks(authorId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{authorId}/report")]
    public IActionResult GetAuthorReports(Guid authorId)
    {
      return _service.GetAuthorReports(authorId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }
  }
}
