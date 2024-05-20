using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using ErrorOr;

namespace BookStoreApi.Services
{
  public class AuthorService : IAuthorService
  {
    private readonly BookStoreDbContext _context;
    private readonly Mapper mapper;

    public AuthorService(BookStoreDbContext context)
    {
      _context = context;
      mapper = MappingConfig.InitializeAutomapper();
    }

    public ErrorOr<Created> CreateAuthor(AuthorCreationDto author)
    {
      var a = new Author();
      a.Name = author.Name;
      a.City = author.City;
      a.Country = author.Country;
      a.BirthYear = author.BirthYear;
      _context.Authors.Add(a);
      _context.SaveChanges();
      return new Created();
    }

    public ErrorOr<Deleted> DeleteAuthor(Guid authorId)
    {
      _context.Authors.Remove(_context.Authors.Find(authorId));
      _context.SaveChanges();
      return new Deleted();
    }

    public ErrorOr<AuthorDto> GetAuthor(Guid authorId)
    {
      return mapper.Map<AuthorDto>(_context.Authors.Find(authorId));
    }

    public ErrorOr<List<BookDto>> GetAuthorBooks(Guid authorId)
    {
      return mapper.Map<List<BookDto>>(_context.Authors.Find(authorId).Books.ToList());
    }

    public ErrorOr<List<ReportDto>> GetAuthorReports(Guid authorId)
    {
      return mapper.Map<List<ReportDto>>(_context.Authors.Find(authorId).Reports.ToList());
    }

    public ErrorOr<List<ReviewDto>> GetAuthorReviews(Guid authorId)
    {
      return mapper.Map<List<ReviewDto>>(_context.Authors.Find(authorId).Reviews.ToList());
    }

    public ErrorOr<List<AuthorDto>> GetAuthors()
    {
      return mapper.Map<List<AuthorDto>>(_context.Authors.ToList());
    }

    public ErrorOr<Updated> UpdateAuthor(Guid authorId, AuthorDto author)
    {
      var a = _context.Authors.Find(authorId);
      a.Name = author.Name;
      a.City = author.City;
      a.Country = author.Country;
      _context.Authors.Update(a);
      _context.SaveChanges();
      return new Updated();
    }
  }
}
