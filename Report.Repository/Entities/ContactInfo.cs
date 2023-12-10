using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Entities
{
	public class ContactInfo
	{
		[Key]
		public int IdContactInfo { get; set; }
		public int IdPerson { get; set; }
		public int ContactType { get; set; }
		public string Content { get; set; }

	}
	public enum ContactType
	{
		Phone = 1,
		Mail = 2,
		Location = 3
	}
}
