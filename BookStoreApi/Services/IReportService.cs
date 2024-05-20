using BookStoreApi.Dto;
using ErrorOr;

namespace BookStoreApi.Services
{
  public interface IReportService
  {
    ErrorOr<Created> CreateReport(Guid userId, ReportCreationDto report);

    ErrorOr<List<ReportDto>> GetReports();

    ErrorOr<ReportDto> GetReport(Guid reportId);

    ErrorOr<Deleted> DeleteReport(Guid reportId);

    ErrorOr<Updated> UpdateReport(Guid reportId, ReportDto updateReportDto);
  }
}
