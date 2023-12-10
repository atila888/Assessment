using Report.Repository.Entities;
using Report.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repository.Interface
{
	public interface IReportRepository
	{
		Task<List<ReportLookup>> GetReportList();
		Task UpdateReportLookup(ReportLookup reportLookup);
	}
}
