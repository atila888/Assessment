using Newtonsoft.Json;
using Report.Repository.Entities;
using Report.Test.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Report.Test.IntegrationTest
{
    public class ReportControllerTest : IClassFixture<IntegrationWebApplicationFactory<Startup>>
    {
        private readonly IntegrationWebApplicationFactory<Startup> _factory;

        public ReportControllerTest(IntegrationWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("Report/api/get-report-list")]
        public async Task Get_People(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.True(response.IsSuccessStatusCode);
            string responseStr = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<List<ReportLookup>>(responseStr);

            Assert.NotNull(responseObject);
            Assert.True(responseObject.Count > 0);
        }
    }
}
