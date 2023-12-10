using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Report.Business.Queue.Core
{
	public abstract class MessageConsumer<T>:BackgroundService
	{
		private readonly IModel _model;
		private readonly IConnection _connection;
		public MessageConsumer(IRabbitMqService rabbitMqService)
		{
			_connection = rabbitMqService.CreateChannel();
			_connection = rabbitMqService.CreateChannel();
			_model = _connection.CreateModel();
			_model.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
			_model.ExchangeDeclare("UserExchange", ExchangeType.Fanout, durable: true, autoDelete: false);
			_model.QueueBind(_queueName, "UserExchange", string.Empty);
		}
		const string _queueName = "User";
		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();
			var consumer = new AsyncEventingBasicConsumer(_model);
			consumer.Received += ConsumerReceived;
			_model.BasicConsume("", false, consumer);

			return Task.CompletedTask;
		}
		private async Task ConsumerReceived(object sender, BasicDeliverEventArgs @event)
		{
			try
			{
				if (@event.Body.Length > 5)
				{
					var message =
						Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(@event.Body.ToArray()));
					await HandleMessage(message);
				}
				_model.BasicAck(@event.DeliveryTag, false);
			}
			catch{ }
		}
		public abstract Task HandleMessage(T message);
		public override void Dispose()
		{
			if (_model != null)
			{
				_model.Close();
				_model.Dispose();
			}
			base.Dispose();
		}
	}
}
