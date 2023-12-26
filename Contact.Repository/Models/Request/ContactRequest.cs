using Contact.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Models.Request
{
	public class ContactRequest
	{
		public int IdPerson { get; set; }
		public ContactType ContactType { get; set; }
		public string Content { get; set; }
	}
}
