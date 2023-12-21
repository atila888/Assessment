using Microsoft.EntityFrameworkCore;
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
        public async Task<List<ReportContent>> GetReportListDetail(int id)
        {
            var result = await _dbcontext.Set<ReportContent>().Where(x => x.IdReportContent == id).ToListAsync();
            return result;
        }
    }
}
