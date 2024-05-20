using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IAuthorService
  {
    ErrorOr<Created> CreateAuthor(AuthorCreationDto author);

    ErrorOr<List<AuthorDto>> GetAuthors();

    ErrorOr<AuthorDto> GetAuthor(Guid authorId);

    ErrorOr<Deleted> DeleteAuthor(Guid authorId);

    ErrorOr<Updated> UpdateAuthor(Guid authorId, AuthorDto author);

    ErrorOr<List<BookDto>> GetAuthorBooks(Guid authorId);

    ErrorOr<List<ReviewDto>> GetAuthorReviews(Guid authorId);

    ErrorOr<List<ReportDto>> GetAuthorReports(Guid authorId);
  }
}
