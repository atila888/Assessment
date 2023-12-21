using Microsoft.AspNetCore.Mvc;
using Report.Business.Manager.Interface;
using Report.Repository.Entities;

namespace Report.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ReportController : ControllerBase
	{
		private readonly IReportManager _reportManager;
		public ReportController(IReportManager reportManager)
		{
			_reportManager= reportManager;
		}
		[HttpGet("api/get-report-list")]
		public async Task<List<ReportLookup>> GetReportList()
		{
			var result = await _reportManager.GetReportList();
			return result;
		}
        [HttpGet("api/get-report-list-detail/{id}")]
        public async Task<List<ReportContent>> GetReportListDetail(int id)
        {
            var result = await _reportManager.GetReportListDetail(id);
            return result;
        }
    }
}
