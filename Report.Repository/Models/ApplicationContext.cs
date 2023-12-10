using Microsoft.EntityFrameworkCore;
using Report.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
		public virtual DbSet<Person> Person { get; set; }
		public virtual DbSet<ReportLookup> ReportLookup { get; set; }
		public virtual DbSet<ContactInfo> ContactInfo { get; set; }
		public virtual DbSet<ReportContent> ReportContent { get; set; }
	}
}
