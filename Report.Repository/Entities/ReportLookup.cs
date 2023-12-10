using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Entities
{
	public class ReportLookup
	{
		public int id { get; set; }
		public string Location { get; set; }
		public DateTime RequestDate {get;set;}
		public string Statu { get; set; }
	}
}
