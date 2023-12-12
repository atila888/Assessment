using Contact.Repository.Entities;
using Contact.Repository.Models.Request;
using Contact.Repository.Models.Response;
using Contact.Test.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Contact.Test.IntegrationTest
{
	public class ContactControllerTests : IClassFixture<IntegrationWebApplicationFactory<Startup>>
	{
		private readonly IntegrationWebApplicationFactory<Startup> _factory;

		private readonly string name = "Ömer";
		private readonly string surname= "Atila";
		private readonly string corparete= "Profe";

		private readonly int idperson = 1;
		private readonly int contacttype = 1;
		private readonly string Content = "0123 456 78 90";

		public ContactControllerTests(IntegrationWebApplicationFactory<Startup> factory)
		{
			_factory= factory;
		}
		[Theory]
		[InlineData("Contact/api/add-new-person")]
		public async Task Add_New_Peson(string url)
		{
			var client = _factory.CreateClient();
			var data = new PersonRequest { Name = name,SurName=surname,Corparete=corparete };
			var json = JsonConvert.SerializeObject(data);
			var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

			var response = await client.PostAsync(url, content);
			response.EnsureSuccessStatusCode();
			Xunit.Assert.True(response.IsSuccessStatusCode);
			string responseStr = await response.Content.ReadAsStringAsync();
			var responseObject = JsonConvert.DeserializeObject<bool>(responseStr);

			Xunit.Assert.True(responseObject);
		}
		[Theory]
		[InlineData("Contact/api/delete-person")]
		public async Task Delete_Peson(string url)
		{
			var client = _factory.CreateClient();
			var data = 1;
			var json = JsonConvert.SerializeObject(data);
			var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

			var response = await client.PostAsync(url, content);
			response.EnsureSuccessStatusCode();
			Xunit.Assert.True(response.IsSuccessStatusCode);
			string responseStr = await response.Content.ReadAsStringAsync();
			var responseObject = JsonConvert.DeserializeObject<bool>(responseStr);

			Xunit.Assert.True(responseObject);
		}
		[Theory]
		[InlineData("Contact/api/add-contact-info")]
		public async Task Add_Contact_Info(string url)
		{
			var client = _factory.CreateClient();
			var data = new ContactRequest { IdPerson=idperson, ContactType=contacttype, Content= Content };
			var json = JsonConvert.SerializeObject(data);
			var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

			var response = await client.PostAsync(url, content);
			response.EnsureSuccessStatusCode();
			Xunit.Assert.True(response.IsSuccessStatusCode);
			string responseStr = await response.Content.ReadAsStringAsync();
			var responseObject = JsonConvert.DeserializeObject<bool>(responseStr);

			Xunit.Assert.True(responseObject);
		}
		[Theory]
		[InlineData("Contact/api/delete-contact-info")]
		public async Task Delete_Contact_Info(string url)
		{
			var client = _factory.CreateClient();
			var data = 1;
			var json = JsonConvert.SerializeObject(data);
			var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

			var response = await client.PostAsync(url, content);
			response.EnsureSuccessStatusCode();
			Xunit.Assert.True(response.IsSuccessStatusCode);
			string responseStr = await response.Content.ReadAsStringAsync();
			var responseObject = JsonConvert.DeserializeObject<bool>(responseStr);

			Xunit.Assert.True(responseObject);
		}
		[Theory]
		[InlineData("Contact/api/get-people")]
		public async Task Get_People(string url)
		{
			var client = _factory.CreateClient();

			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			Xunit.Assert.True(response.IsSuccessStatusCode);
			string responseStr = await response.Content.ReadAsStringAsync();
			var responseObject = JsonConvert.DeserializeObject<List<Person>>(responseStr);

			Xunit.Assert.NotNull(responseObject);
			Xunit.Assert.True(responseObject.Count > 0);
		}
		[Theory]
		[InlineData("Contact/api/get-person-info/1")]
		public async Task Get_Person_Info(string url)
		{
			var client = _factory.CreateClient();

			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			Xunit.Assert.True(response.IsSuccessStatusCode);
			string responseStr = await response.Content.ReadAsStringAsync();
			var responseObject = JsonConvert.DeserializeObject<PersonContactInfoResponse>(responseStr);

			Xunit.Assert.NotNull(responseObject);
		}
		[Theory]
		[InlineData("Contact/api/get-location-report/Kayseri")]
		public async Task Get_Location_Info(string url)
		{
			var client = _factory.CreateClient();

			var response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			Xunit.Assert.True(response.IsSuccessStatusCode);
			string responseStr = await response.Content.ReadAsStringAsync();
			var responseObject = JsonConvert.DeserializeObject<bool>(responseStr);

			Xunit.Assert.True(responseObject);
		}
	}
}
