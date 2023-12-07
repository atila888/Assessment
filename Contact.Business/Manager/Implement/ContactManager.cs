using Contact.Business.Manager.Interface;
using Contact.Repository.Entities;
using Contact.Repository.Models.Request;
using Contact.Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Manager.Implement
{
	public class ContactManager : IContactManager
	{
		private readonly IPersonRepository _personRepository;
		public ContactManager(IPersonRepository personRepository) 
		{
			_personRepository= personRepository;
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
	}
}
