﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Entities
{
	public class Person
	{
		[Key]
		public int IdPerson { get; set; }
		public string Name { get; set; }
		public string SurName { get; set; }
		public string Corparete { get; set; }
	}
}
