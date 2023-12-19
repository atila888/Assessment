using Contact.Business.Manager.Interface;
using Contact.Repository.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportManager _reportManager;
        public ReportController(IReportManager reportManager)
        {
            _reportManager = reportManager;
        }
        [HttpPost("api/exec-location-report")]
        public async Task<bool> ExecLocationReport(ReportLookup reportLookup)
        {
            var result = await _reportManager.ExecLocationReport(reportLookup);
            return result;
        }
    }
}
