using BookStoreApi.Dto;
using BookStoreApi.Filters;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IReportService
  {
    ErrorOr<Created> CreateReport(Guid userId, ReportCreationDto report);

    ErrorOr<List<ReportDto>> GetReports(PaginationFilter paginationFilter);

    ErrorOr<ReportDto> GetReport(Guid reportId);

    ErrorOr<Deleted> DeleteReport(Guid reportId);

    ErrorOr<Updated> UpdateReport(Guid reportId, ReportDto updateReportDto);
  }
}
