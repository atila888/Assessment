using Contact.Repository.Entities;
using Contact.Repository.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Repository.Interface
{
	public interface IContactInfoRepository
	{
		Task AddContactInfo(ContactInfo contactInfo);
		Task DeleteContactInfo(int id);
		Task<List<ContactInfo>> GetPersonContactInfo(int idPerson);
		Task<int> PhoneCountWithLocation(string location);
        Task<int> PersonCountWithLocation(string location);

    }
}
