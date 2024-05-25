using BookStoreApi.Dto;
using BookStoreApi.Filters;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IBookService
  {
    ErrorOr<Created> CreateBook(BookCreationDto book);

    ErrorOr<List<BookDto>> GetBooks(PaginationFilter paginationFilter);

    ErrorOr<BookDto> GetBook(Guid bookId);

    ErrorOr<Deleted> DeleteBook(Guid bookId);

    ErrorOr<Updated> UpdateBook(Guid bookId, BookDto updateBookDto);

    ErrorOr<List<ReviewDto>> GetBookReviews(Guid bookId, PaginationFilter paginationFilter);

    ErrorOr<List<ReportDto>> GetBookReports(Guid bookId, PaginationFilter paginationFilter);
  }
}
