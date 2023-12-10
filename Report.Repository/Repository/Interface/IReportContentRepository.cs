using Report.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repository.Interface
{
	public interface IReportContentRepository
	{
		Task AddReportContent(ReportContent reportContent);
	}
}
