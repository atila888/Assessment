using Contact.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Manager.Interface
{
	public interface IReportManager
	{
		Task<bool> GetLocationReport(string location);
		Task<bool> ExecLocationReport(ReportLookup reportLookup);

    }
}
