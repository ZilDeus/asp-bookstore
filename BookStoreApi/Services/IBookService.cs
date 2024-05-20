using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IBookService
  {
    ErrorOr<Created> CreateBook(BookCreationDto book);

    ErrorOr<List<BookDto>> GetBooks();

    ErrorOr<BookDto> GetBook(Guid bookId);

    ErrorOr<Deleted> DeleteBook(Guid bookId);

    ErrorOr<Updated> UpdateBook(Guid bookId, BookDto updateBookDto);

    ErrorOr<List<ReviewDto>> GetBookReviews(Guid bookId);

    ErrorOr<List<ReportDto>> GetBookReports(Guid bookId);
  }
}
