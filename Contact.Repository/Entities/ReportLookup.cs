﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Repository.Entities
{
	public class ReportLookup
	{
		[Key]
		public int IdReportLookup { get; set; }
		public string Location { get; set; }
		public DateTime RequestDate { get; set; }
		public string Statu { get; set; }
	}
}
