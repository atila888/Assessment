using Contact.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Models
{
    public class ApplicationContext : DbContext
    {
		//dotnet ef migrations add v1.1 --project Contact.Repository --startup-project Contact
		//dotnet ef database update --project Contact.Repository --startup-project Contact
		//dotnet ef migrations remove --project Contact.Repository --startup-project Contact
		//dotnet ef migrations list --project Contact.Repository --startup-project Contact
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
		{
            this.Database.EnsureCreated();
        }

        public virtual DbSet<Person> Person { get; set; }
		public virtual DbSet<ReportLookup> ReportLookup { get; set; }
		public virtual DbSet<ContactInfo> ContactInfo { get; set; }
		public virtual DbSet<ReportContent> ReportContent { get; set; }
	}

}
