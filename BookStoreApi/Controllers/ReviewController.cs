using BookStoreApi.Dto;
using BookStoreApi.Filters;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ReviewController : ControllerBase
  {

    private readonly IReviewService _service;

    public ReviewController(ReviewService service)
    {
      _service = service;
    }

    [HttpPost]
    public IActionResult AddReview(Guid userId, ReviewCreationDto review)
    {
      return _service.CreateReview(userId, review).Match(
          ok => Ok("review created successfully"),
          error => Problem(error.ToString())
          );
    }


    [HttpGet]
    public IActionResult GetReviews([FromQuery] PaginationFilter paginationFilter)
    {
      return _service.GetReviews(paginationFilter).Match(
          ok => Ok(ok),
          error => Problem(error.ToString())
          );
    }

    [HttpDelete("{reviewId}")]
    public IActionResult DeleteReview(Guid reviewId)
    {
      return _service.DeleteReview(reviewId).Match(
          ok => Ok("report delted successfully"),
          error => Problem(error.ToString())
          );
    }

    [HttpPut("{reviewId}")]
    public IActionResult UpdateReview(Guid reviewId, ReviewDto reviewUpdateDto)
    {

      return _service.UpdateReview(reviewId, reviewUpdateDto).Match(
          ok => Ok("report updated successfully"),
          error => Problem(error.ToString())
          );
    }
  }
}

