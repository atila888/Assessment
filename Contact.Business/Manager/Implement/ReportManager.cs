using Contact.Business.Manager.Interface;
using Contact.Repository.Entities;
using Contact.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Manager.Implement
{
	public class ReportManager : IReportManager
	{
		private readonly IReportRepository _reportRepository;
		public ReportManager(IReportRepository reportRepository)
		{
			_reportRepository= reportRepository;
		}
		public async Task<bool> GetLocationReport(string location)
		{
			try
			{
				ReportLookup reportLookup=new ReportLookup();
				reportLookup.Location = location;
				reportLookup.Statu = "Hazırlanıyor";
				await _reportRepository.GetLocationReport(reportLookup);


				return true;
			}
			catch 
			{

				return false;
			}
		}
	}
}
