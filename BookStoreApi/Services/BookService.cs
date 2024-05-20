using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using ErrorOr;

namespace BookStoreApi.Services
{
  public class BookService : IBookService
  {

    private readonly BookStoreDbContext _context;
    private readonly Mapper mapper;

    public BookService(BookStoreDbContext context)
    {
      _context = context;
      mapper = MappingConfig.InitializeAutomapper();
    }

    public ErrorOr<Created> CreateBook(BookCreationDto book)
    {
      var b = new Book();
      b.Title = book.Title;
      b.Genre = book.Genre;
      b.Author = _context.Authors.Find(book.Author);
      b.PublishedAt = new DateOnly();
      _context.Books.Add(b);
      _context.SaveChanges();
      return new Created();
    }

    public ErrorOr<Deleted> DeleteBook(Guid bookId)
    {
      _context.Books.Remove(_context.Books.Find(bookId));
      _context.SaveChanges();
      return new Deleted();
    }

    public ErrorOr<BookDto> GetBook(Guid bookId)
    {
      return mapper.Map<BookDto>(_context.Books.Find(bookId));
    }

    public ErrorOr<List<ReportDto>> GetBookReports(Guid bookId)
    {
      return mapper.Map<List<ReportDto>>(_context.Books.Find(bookId).Reports.ToList());
    }

    public ErrorOr<List<ReviewDto>> GetBookReviews(Guid bookId)
    {
      return mapper.Map<List<ReviewDto>>(_context.Books.Find(bookId).Reviews.ToList());
    }

    public ErrorOr<List<BookDto>> GetBooks()
    {
      return mapper.Map<List<BookDto>>(_context.Books.ToList());
    }

    public ErrorOr<Updated> UpdateBook(Guid bookId, BookDto updateBookDto)
    {
      var b = _context.Books.Find(bookId);
      b.Title = updateBookDto.Title;
      b.Genre = updateBookDto.Genre;
      _context.Books.Update(b);
      _context.SaveChanges();
      return new Updated();
    }
  }
}
