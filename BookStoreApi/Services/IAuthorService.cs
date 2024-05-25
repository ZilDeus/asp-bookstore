using BookStoreApi.Dto;
using BookStoreApi.Filters;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IAuthorService
  {
    ErrorOr<Created> CreateAuthor(AuthorCreationDto author);

    ErrorOr<List<AuthorDto>> GetAuthors(PaginationFilter paginationFilter);

    ErrorOr<AuthorDto> GetAuthor(Guid authorId);

    ErrorOr<Deleted> DeleteAuthor(Guid authorId);

    ErrorOr<Updated> UpdateAuthor(Guid authorId, AuthorDto author);

    ErrorOr<List<BookDto>> GetAuthorBooks(Guid authorId, PaginationFilter paginationFilter);

    ErrorOr<List<ReviewDto>> GetAuthorReviews(Guid authorId, PaginationFilter paginationFilter);

    ErrorOr<List<ReportDto>> GetAuthorReports(Guid authorId, PaginationFilter paginationFilter);
  }
}
