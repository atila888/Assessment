using Contact.Repository.Entities;
using Contact.Repository.Models;
using Contact.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
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
        public async Task UpdateReportLookup(ReportLookup reportLookup)
        {
            var result = await _dbcontext.Set<ReportLookup>().SingleOrDefaultAsync(x => x.IdReportLookup == reportLookup.IdReportLookup);
            result.Statu = "Tamamlandı";
            await _dbcontext.SaveChangesAsync();
        }
    }
}
