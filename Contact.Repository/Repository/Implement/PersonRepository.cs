using Contact.Repository.DBContext;
using Contact.Repository.Entities;
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
	public class PersonRepository : IPersonRepository
	{
		private readonly ApplicationContext _dbcontext;
		public PersonRepository(ApplicationContext dbContext)
		{
			_dbcontext= dbContext;
		}
		public async Task AddNewPerson(Person person)
		{
			await _dbcontext.Set<Person>().AddAsync(person);
			await _dbcontext.SaveChangesAsync();
		}
		public async Task DeletePerson(int id)
		{
			await _dbcontext.Set<Person>().Where(x=>x.id==id).ExecuteDeleteAsync();
			await _dbcontext.SaveChangesAsync();
		}

		public async Task<List<Person>> GetPeople()
		{
			var result=await _dbcontext.Set<Person>().ToListAsync();
			return result;
		}
		public async Task<Person> GetPersonInfo(int id)
		{
			var result =await _dbcontext.Set<Person>().SingleOrDefaultAsync(x => x.id == id);
			return result;
		}
	}
}
