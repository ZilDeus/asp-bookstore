using BookStoreApi.Dto;
using BookStoreApi.Filters;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IReviewService
  {
    ErrorOr<Created> CreateReview(Guid userId, ReviewCreationDto review);

    ErrorOr<List<ReviewDto>> GetReviews(PaginationFilter paginationFilter);

    ErrorOr<ReviewDto> GetReview(Guid reviewId);

    ErrorOr<Deleted> DeleteReview(Guid reviewId);

    ErrorOr<Updated> UpdateReview(Guid reviewId, ReviewDto updateReviewDto);
  }
}
