using Report.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Manager.Interface
{
	public interface IReportManager
	{
		Task<List<ReportLookup>> GetReportList();
		Task<List<ReportContent>> GetReportListDetail(int id);

    }
}
