using Microsoft.EntityFrameworkCore;
using Report.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.DBContext
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
		public DbSet<ReportLookup> Person { get; set; }
	}
}
