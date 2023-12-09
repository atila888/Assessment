using Contact.Repository.Entities;
using Contact.Repository.Models.Request;
using Contact.Repository.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Manager.Interface
{
	public interface IContactManager
	{
		Task<bool> AddNewPerson(PersonRequest person);
		Task<bool> DeletePerson(int id);
		Task<bool> AddContactInfo(ContactRequest contactRequest);
		Task<bool> DeleteContactInfo(int id);
		Task<List<Person>> GetPeople();
		Task<PersonContactInfoResponse> GetPersonInfo(int id);
	}
}
