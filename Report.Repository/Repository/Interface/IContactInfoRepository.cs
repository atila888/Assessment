using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Repository.Repository.Interface
{
	public interface IContactInfoRepository
	{
		Task<int> PhoneCountWithLocation(string location);
		Task<int> PersonCountWithLocation(string location);
	}
}
