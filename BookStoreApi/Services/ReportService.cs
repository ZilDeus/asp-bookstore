using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.Entities;
using BookStoreApi.Presistence;
using ErrorOr;

namespace BookStoreApi.Services
{
  public class ReportService : IReportService
  {

    private readonly BookStoreDbContext _context;
    private readonly Mapper mapper;

    public ReportService(BookStoreDbContext context)
    {
      _context = context;
      mapper = MappingConfig.InitializeAutomapper();
    }

    public ErrorOr<Created> CreateReport(Guid userId, ReportCreationDto report)
    {
      var r = new Report();
      r.Content = report.Content;
      r.Book = _context.Books.Find(report.Book);
      _context.Reports.Add(r);
      _context.SaveChanges();
      return new Created();
    }

    public ErrorOr<Deleted> DeleteReport(Guid reportId)
    {
      _context.Reports.Remove(_context.Reports.Find(reportId));
      _context.SaveChanges();
      return new Deleted();
    }

    public ErrorOr<ReportDto> GetReport(Guid reportId)
    {
      return mapper.Map<ReportDto>(_context.Reports.Find(reportId));
    }

    public ErrorOr<List<ReportDto>> GetReports()
    {
      return mapper.Map<List<ReportDto>>(_context.Reports.ToList());
    }

    public ErrorOr<Updated> UpdateReport(Guid reportId, ReportDto updateReportDto)
    {
      var r = _context.Reports.Find(reportId);
      r.Content = updateReportDto.Content;
      _context.Reports.Update(r);
      _context.SaveChanges();
      return new Updated();
    }
  }
}
