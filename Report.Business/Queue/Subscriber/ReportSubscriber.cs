using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Report.Business.Helper;
using Report.Business.Queue.Core;
using Report.Business.Settings;
using Report.Repository.Entities;
using Report.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
			try
			{
				await HTTPClientWrapper<ReportLookup>.PostAsync(_postSetting.PostUrl,reportLookup);
            }
			catch (Exception)
			{

				throw;
			}
		}
	}
}
