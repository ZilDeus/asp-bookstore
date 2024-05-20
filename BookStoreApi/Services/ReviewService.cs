using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using ErrorOr;

namespace BookStoreApi.Services
{
  public class ReviewService : IReviewService
  {

    private readonly BookStoreDbContext _context;
    private readonly Mapper mapper;

    public ReviewService(BookStoreDbContext context)
    {
      _context = context;
      mapper = MappingConfig.InitializeAutomapper();
    }

    public ErrorOr<Created> CreateReview(Guid userId, ReviewCreationDto review)
    {
      var r = new Review();
      r.Score = review.Score;
      r.Content = review.Content;
      r.Book = _context.Books.Find(review.Book);
      _context.Reviews.Add(r);
      _context.SaveChanges();
      return new Created();
    }

    public ErrorOr<Deleted> DeleteReview(Guid reviewId)
    {
      _context.Reviews.Remove(_context.Reviews.Find(reviewId));
      _context.SaveChanges();
      return new Deleted();
    }

    public ErrorOr<ReviewDto> GetReview(Guid reviewId)
    {
      return mapper.Map<ReviewDto>(_context.Reviews.Find(reviewId));
    }

    public ErrorOr<List<ReviewDto>> GetReviews()
    {
      return mapper.Map<List<ReviewDto>>(_context.Reviews.ToList());
    }

    public ErrorOr<Updated> UpdateReview(Guid reviewId, ReviewDto updateReviewDto)
    {
      var r = _context.Reviews.Find(reviewId);
      r.Content = updateReviewDto.Content;
      r.Score = updateReviewDto.Score;
      _context.Reviews.Update(r);
      _context.SaveChanges();
      return new Updated();
    }
  }
}
