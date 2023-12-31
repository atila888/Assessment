﻿using Contact.Repository.Entities;
using Contact.Repository.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Repository.Interface
{
	public interface IPersonRepository
	{
		Task AddNewPerson(Person person);
		Task DeletePerson(int id);
		Task<List<Person>> GetPeople();
		Task<Person> GetPersonInfo(int id);
	}
}
