using Contact.Repository.DBContext;
using Contact.Repository.Entities;
using Contact.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Repository.Implement
{
	public class ReportRepository : IReportRepository
	{
		private readonly ApplicationContext _dbcontext;
		public ReportRepository(ApplicationContext dbContext)
		{
			_dbcontext = dbContext;
		}
		public async Task GetLocationReport(ReportLookup reportLookup)
		{
			await _dbcontext.Set<ReportLookup>().AddAsync(reportLookup);
			await _dbcontext.SaveChangesAsync();
		}
	}
}
