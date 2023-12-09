using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Business.Queue.Core
{
	public class MessageProducer : IMessageProducer
	{
		private readonly IRabbitMqService _rabbitMqService;
		public MessageProducer(IRabbitMqService rabbitMqService)
		{
			_rabbitMqService = rabbitMqService;
		}
		public void SendMessage<T>(T message)
		{
			var connection = _rabbitMqService.CreateChannel();
			var channel = connection.CreateModel();

			channel.QueueDeclare("report");

			var json = JsonConvert.SerializeObject(message);
			var body = Encoding.UTF8.GetBytes(json);
			channel.BasicPublish(exchange: "", routingKey: "report", body: body);
		}
	}
}
