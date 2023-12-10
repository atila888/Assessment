using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Entities
{
	public class ReportContent
	{
		[Key]
		public int IdReportContent { get; set; }
		public string Location { get; set; }
		public int PersonCount { get; set; }
		public int PhoneCount { get; set; }
	}
}
