using Contact.Repository.Models.Request;
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
	}
}
