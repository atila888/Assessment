using Contact.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Models.Response
{
	public class PersonContactInfoResponse
	{
		public Person person { get; set; }
		public List<ContactInfo> contacInfos { get; set; }
	}
}
