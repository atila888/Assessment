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
    public class ContactInfoRepository : IContactInfoRepository
	{
		private readonly ApplicationContext _dbcontext;
		public ContactInfoRepository(ApplicationContext dbContext)
		{
			_dbcontext = dbContext;
		}
		public async Task<int> PhoneCountWithLocation(string location)
		{
			var result = await _dbcontext.Set<ContactInfo>().Where(x => x.ContactType ==(int)ContactType.Phone && x.Content == location).CountAsync();
			return result;
		}
		public async Task<int> PersonCountWithLocation(string location)
		{
			var result = await _dbcontext.Set<ContactInfo>().Where(x => x.ContactType==(int)ContactType.Location &&x.Content==location).CountAsync();
			return result;
		}
	}
}
