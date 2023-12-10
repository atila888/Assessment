using Report.Repository.DBContext;
using Report.Repository.Models;
using Report.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repository.Implement
{
	public class ReportContentRepository : IReportContentRepository
	{
		private readonly ApplicationContext _dbcontext;
		public ReportContentRepository(ApplicationContext dbContext)
		{
			_dbcontext = dbContext;
		}
		public async Task AddReportContent(ReportContent reportContent)
		{
			await _dbcontext.Set<ReportContent>().AddAsync(reportContent);
			await _dbcontext.SaveChangesAsync();
		}
	}
}
