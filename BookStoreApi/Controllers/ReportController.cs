using BookStoreApi.Dto;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ReportController : ControllerBase
  {
    private readonly IReportService _service;

    public ReportController(ReportService service)
    {
      _service = service;
    }

    [HttpPost]
    public IActionResult AddReport(Guid userId, ReportCreationDto report)
    {
      return _service.CreateReport(userId, report).Match(
          ok => Ok("report created successfully"),
          error => Problem(error.ToString())
          );
    }
    [HttpGet]
    public IActionResult GetReports()
    {
      return _service.GetReports().Match(
          ok => Ok(ok),
          error => Problem(error.ToString())
          );
    }

    [HttpDelete("{reportId}")]
    public IActionResult DeleteReport(Guid reportId)
    {
      return _service.DeleteReport(reportId).Match(
          ok => Ok("report delted successfully"),
          error => Problem(error.ToString())
          );
    }

    [HttpPut("{reportId}")]
    public IActionResult UpdateReport(Guid reportId, ReportDto reportUpdateDto)
    {

      return _service.UpdateReport(reportId, reportUpdateDto).Match(
          ok => Ok("report updated successfully"),
          error => Problem(error.ToString())
          );
    }
  }
}

