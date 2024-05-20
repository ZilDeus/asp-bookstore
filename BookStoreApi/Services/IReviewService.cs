using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IReviewService
  {
    ErrorOr<Created> CreateReview(Guid userId, ReviewCreationDto review);

    ErrorOr<List<ReviewDto>> GetReviews();

    ErrorOr<ReviewDto> GetReview(Guid reviewId);

    ErrorOr<Deleted> DeleteReview(Guid reviewId);

    ErrorOr<Updated> UpdateReview(Guid reviewId, ReviewDto updateReviewDto);
  }
}
