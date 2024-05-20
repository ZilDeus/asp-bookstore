using BookStoreApi.Dto;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
  [Route("/api/[controller]")]
  public class BookController : ControllerBase
  {

    private readonly IBookService _service;

    public BookController(BookService service)
    {
      _service = service;
    }

    [HttpPost]
    public IActionResult AddBook(BookCreationDto book)
    {
      return _service.CreateBook(book).Match(
          created => Ok("book added successfully"),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
      return _service.GetBooks().Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{bookId}")]
    public IActionResult GetBook(Guid bookId)
    {
      return _service.GetBook(bookId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpDelete("{bookId}")]
    public IActionResult DeleteBook(Guid bookId)
    {
      return _service.DeleteBook(bookId).Match(
          ok => Ok("book deleted successfully"),
          errors => Problem(errors.ToString())
          );
    }

    [HttpPut("{bookId}")]
    public IActionResult UpdateBook(Guid bookId, BookDto bookUpdateDto)
    {
      return _service.UpdateBook(bookId, bookUpdateDto).Match(
          ok => Ok("book updated successfully"),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{bookId}/review")]
    public IActionResult GetBookReviews(Guid bookId)
    {
      return _service.GetBookReviews(bookId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

    [HttpGet("{bookId}/report")]
    public IActionResult GetBookReports(Guid bookId)
    {
      return _service.GetBookReviews(bookId).Match(
          ok => Ok(ok),
          errors => Problem(errors.ToString())
          );
    }

  }
}

