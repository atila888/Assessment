using Report.Business.Manager.Interface;
using Report.Business.Queue.Subscriber;
using Report.Repository.Entities;
using Report.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Manager.Implement
{
	public class ReportManager : IReportManager
	{
		private readonly IReportRepository _reportRepository;
		public ReportManager(IReportRepository reportRepository) 
		{
			_reportRepository= reportRepository;
		}
		public async Task<List<ReportLookup>> GetReportList()
		{
			var reportLookup = await _reportRepository.GetReportList();
			return reportLookup;
		}
	}
}
