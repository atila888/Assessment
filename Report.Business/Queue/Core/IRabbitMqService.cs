using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Queue.Core
{
	public interface IRabbitMqService
	{
		IConnection CreateChannel();
	}
}
