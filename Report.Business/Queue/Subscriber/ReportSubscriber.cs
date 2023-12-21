using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Report.Business.Queue.Core;
using Report.Business.Settings;
using Report.Repository.Entities;
using Report.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business.Queue.Subscriber
{
	public class ReportSubscriber : MessageConsumer<ReportLookup>
	{
		private readonly PostSetting _postSetting;

		public ReportSubscriber(IRabbitMqService rabbitMqService
			, IOptions<PostSetting> options
            ):base( rabbitMqService)
		{
			_postSetting = options.Value;

        }

		public override async Task HandleMessage(ReportLookup reportLookup)
		{
			Console.WriteLine("Log : RabbitMQ kuyruğu okundu");
			try
			{
                var client = new HttpClient();
                client.BaseAddress = new Uri(_postSetting.BaseAdress);
                var result = await client.PostAsync(_postSetting.PostUrl, reportLookup, new JsonMediaTypeFormatter());
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
			catch (Exception ex)
			{
                Console.WriteLine("Post işleminde hata. Hata Detayları :" + ex.Message);
			}
		}
	}
}
