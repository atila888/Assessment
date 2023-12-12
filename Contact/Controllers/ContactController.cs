using Contact.Business.Manager.Interface;
using Contact.Repository.Entities;
using Contact.Repository.Models.Request;
using Contact.Repository.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Contact.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ContactController : ControllerBase
	{
		private readonly IContactManager _contactManager;
		private readonly IReportManager _reportManager;
		public ContactController(IContactManager contactManager, IReportManager reportManager)
		{
			_contactManager = contactManager;
			_reportManager = reportManager;
		}
		[HttpPost("api/add-new-person")]
		public async Task<bool> AddNewPerson(PersonRequest person)
		{
			var result = await _contactManager.AddNewPerson(person);
			return result;
		}
		[HttpPost("api/delete-person")]
		public async Task<bool> DeletePerson(int id)
		{
			var result = await _contactManager.DeletePerson(id);
			return result;
		}
		[HttpPost("api/add-contact-info")]
		public async Task<bool> AddContactInfo(ContactRequest contactRequest)
		{
			var result = await _contactManager.AddContactInfo(contactRequest);
			return result;
		}
		[HttpPost("api/delete-contact-info")]
		public async Task<bool> DeleteContactInfo(int id)
		{
			var result = await _contactManager.DeleteContactInfo(id);
			return result;
		}
		[HttpGet("api/get-people")]
		public async Task<List<Person>> GetPeople()
		{
			var result = await _contactManager.GetPeople();
			return result;
		}
		[HttpGet("api/get-person-info/{id}")]
		public async Task<PersonContactInfoResponse> GetPersonInfo(int id)
		{
			var result = await _contactManager.GetPersonInfo(id);
			return result;
		}
		[HttpGet("api/get-location-report/{location}")]
		public async Task<bool> GetLocationReport(string location)
		{
			var result = await _reportManager.GetLocationReport(location);
			return result;
		}
	}
}
