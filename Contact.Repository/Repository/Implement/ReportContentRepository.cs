using Contact.Repository.Entities;
using Contact.Repository.Models;
using Contact.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Repository.Implement
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
            try
            {
                await _dbcontext.Set<ReportContent>().AddAsync(reportContent);
                await _dbcontext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
