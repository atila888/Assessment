using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Queue.Core
{
	public class RabbitMqService : IRabbitMqService
	{
		private readonly RabbitMqConfiguration _configuration;
		public RabbitMqService(IOptions<RabbitMqConfiguration> options)
		{
			_configuration = options.Value;
		}
		public IConnection CreateChannel()
		{
			ConnectionFactory connection = new ConnectionFactory()
			{
				UserName = _configuration.Username,
				Password = _configuration.Password,
				HostName = _configuration.HostName,
				Ssl = { ServerName= _configuration.HostName }
			};
			connection.DispatchConsumersAsync = true;
			var channel = connection.CreateConnection();
			return channel;
		}
	}
}
