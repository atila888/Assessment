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
        /// <summary>
        /// Sistemin Hazırladığı veya Hazırlayacağı Rapor Listesi
        /// </summary>
        /// <returns>Rapor Listesini döner</returns>
        // GET: api/get-report-list
        [HttpGet("api/get-report-list")]
		public async Task<List<ReportLookup>> GetReportList()
		{
			var result = await _reportManager.GetReportList();
			return result;
		}
        /// <summary>
        /// Sistemin Hazırladığı Rapor içeriği
        /// </summary>
        /// <returns>Rapor İçeriğini döner</returns>
        // GET: api/get-report-list-detail/{id}
        [HttpGet("api/get-report-list-detail/{id}")]
        public async Task<List<ReportContent>> GetReportListDetail(int id)
        {
            var result = await _reportManager.GetReportListDetail(id);
            return result;
        }
    }
}
