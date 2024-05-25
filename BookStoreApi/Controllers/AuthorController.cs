using BookStoreApi.Dto;
using BookStoreApi.Filters;
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
          errors => Problem(errors.First().Description)
          );
    }
    [HttpGet]
    public IActionResult GetAuthors([FromQuery] PaginationFilter paginationFilter)
    {
      return _service.GetAuthors(paginationFilter).Match(
          ok => Ok(ok),
          errors => Problem(errors.First().Description)
          );
    }
    [HttpGet("{authorId}")]
    public IActionResult GetAuthor(Guid authorId)
    {
      return _service.GetAuthor(authorId).Match(
          ok => Ok(ok),
          errors => Problem(errors.First().Description)
          );
    }

    [HttpDelete("{authorId}")]
    public IActionResult DeleteAuthor(Guid authorId)
    {
      return _service.DeleteAuthor(authorId).Match(
          ok => Ok("author deleted successfully"),
          errors => Problem(errors.First().Description)
          );
    }

    [HttpPut("{authorId}")]
    public IActionResult UpdateAuthor(Guid authorId, AuthorDto authorUpdateDto)
    {

      return _service.UpdateAuthor(authorId, authorUpdateDto).Match(
          ok => Ok("author updated successfully"),
          errors => Problem(errors.First().Description)
          );
    }

    [HttpGet("{authorId}/review")]
    public IActionResult GetAuthorReviews(Guid authorId, [FromQuery] PaginationFilter paginationFilter)
    {
      return _service.GetAuthorReviews(authorId, paginationFilter).Match(
          ok => Ok(ok),
          errors => Problem(errors.First().Description)
          );
    }

    [HttpGet("{authorId}/books")]
    public IActionResult GetAuthorBooks(Guid authorId, [FromQuery] PaginationFilter paginationFilter)
    {
      return _service.GetAuthorBooks(authorId, paginationFilter).Match(
          ok => Ok(ok),
          errors => Problem(errors.First().Description)
          );
    }

    [HttpGet("{authorId}/report")]
    public IActionResult GetAuthorReports(Guid authorId, [FromQuery] PaginationFilter paginationFilter)
    {
      return _service.GetAuthorReports(authorId, paginationFilter).Match(
          ok => Ok(ok),
          errors => Problem(errors.First().Description)
          );
    }
  }
}
