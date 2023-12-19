using Contact.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Repository.Interface
{
    public interface IReportContentRepository
    {
        Task AddReportContent(ReportContent reportContent);
    }
}
