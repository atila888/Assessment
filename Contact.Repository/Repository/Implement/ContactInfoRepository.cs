using Contact.Repository.Entities;
using Contact.Repository.Models;
using Contact.Repository.Models.Request;
using Contact.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Repository.Implement
{
    public class ContactInfoRepository : IContactInfoRepository
	{
		private readonly ApplicationContext _dbcontext;
		public ContactInfoRepository(ApplicationContext dbContext)
		{
			_dbcontext = dbContext;
		}
		public async Task AddContactInfo(ContactInfo contactInfo)
		{
			await _dbcontext.Set<ContactInfo>().AddAsync(contactInfo);
			await _dbcontext.SaveChangesAsync();
		}
		public async Task DeleteContactInfo(int id)
		{
			await _dbcontext.Set<ContactInfo>().Where(x => x.IdContactInfo == id).ExecuteDeleteAsync();
			await _dbcontext.SaveChangesAsync();
		}
		public async Task<List<ContactInfo>> GetPersonContactInfo(int idPerson)
		{
			var result = await _dbcontext.Set<ContactInfo>().Where(x => x.IdPerson == idPerson).ToListAsync();
			return result;
		}
        public async Task<int> PhoneCountWithLocation(string location)
        {
            var result = await _dbcontext.Set<ContactInfo>().Where(x => x.ContactType == (int)ContactType.Phone && x.Content == location).CountAsync();
            return result;
        }
        public async Task<int> PersonCountWithLocation(string location)
        {
            var result = await _dbcontext.Set<ContactInfo>().Where(x => x.ContactType == (int)ContactType.Location && x.Content == location).CountAsync();
            return result;
        }
    }
}
