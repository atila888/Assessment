using Contact.Business.Manager.Interface;
using Contact.Repository.Entities;
using Contact.Repository.Models.Request;
using Contact.Repository.Models.Response;
using Contact.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Manager.Implement
{
	/// <summary>
	/// Her metodun ilk adımı validasyon işlemi olacak
	/// Automapper kütüphanesi kullanılabilir.
	/// </summary>
	public class ContactManager : IContactManager
	{
		private readonly IPersonRepository _personRepository;
		private readonly IContactInfoRepository _contactInfoRepository;
		public ContactManager(IPersonRepository personRepository, IContactInfoRepository contactInfoRepository) 
		{
			_personRepository= personRepository;
			_contactInfoRepository= contactInfoRepository;
		}	
		public async Task<bool> AddNewPerson(PersonRequest person)
		{
			try
			{
				//Automapper Kullanılabilirdi.
				Person personEntity=new Person();
				personEntity.Name = person.Name;
				personEntity.SurName = person.SurName;
				personEntity.Corparete=person.Corparete;

				await _personRepository.AddNewPerson(personEntity);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> DeletePerson(int id)
		{
			try
			{
				await _personRepository.DeletePerson(id);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> AddContactInfo(ContactRequest contactRequest)
		{
			try
			{
				//Automapper Kullanılabilirdi.
				ContactInfo contactInfo = new ContactInfo();
				contactInfo.IdPerson=contactRequest.IdPerson;
				contactInfo.ContactType=contactRequest.ContactType;
				contactInfo.Content=contactRequest.Content;

				await _contactInfoRepository.AddContactInfo(contactInfo);
				return true;
			}
			catch
			{

				return false;
			}
		}
		public async Task<bool> DeleteContactInfo(int id)
		{
			try
			{
				await _contactInfoRepository.DeleteContactInfo(id);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<List<Person>> GetPeople()
		{
			return await _personRepository.GetPeople();
		}
		public async Task<PersonContactInfoResponse> GetPersonInfo(int id)
		{
			var person = await _personRepository.GetPersonInfo(id);
			var contactInfo = await _contactInfoRepository.GetPersonContactInfo(person.id);

			PersonContactInfoResponse personContactInfoResponse = new PersonContactInfoResponse();
			personContactInfoResponse.person = person;
			personContactInfoResponse.contacInfos = contactInfo;

			return personContactInfoResponse;
		}
	}
}
