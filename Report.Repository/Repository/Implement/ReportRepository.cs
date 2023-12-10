using Microsoft.EntityFrameworkCore;
using Report.Repository.DBContext;
using Report.Repository.Entities;
using Report.Repository.Models;
using Report.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repository.Implement
{
	public class ReportRepository : IReportRepository
	{
		private readonly ApplicationContext _dbcontext;
		public ReportRepository(ApplicationContext dbContext) 
		{
			_dbcontext = dbContext;
		}

		public async Task<List<ReportLookup>> GetReportList()
		{
			var result = await _dbcontext.Set<ReportLookup>().ToListAsync();
			return result;
		}
		public async Task UpdateReportLookup(ReportLookup reportLookup)
		{
			var result =await _dbcontext.Set<ReportLookup>().SingleOrDefaultAsync(x=>x.id== reportLookup.id);
			result.Statu = "Tamamlandı";
			await _dbcontext.SaveChangesAsync();
		}
	}
}
