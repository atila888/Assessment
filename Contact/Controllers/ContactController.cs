using Contact.Business.Manager.Interface;
using Contact.Repository.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ContactController : ControllerBase
	{
		private readonly IContactManager _contactManager;
		public ContactController(IContactManager contactManager)
		{
			_contactManager = contactManager;
		}
		[HttpPost("api/add-new-person")]
		public async Task<bool> AddNewPerson(PersonRequest person)
		{
			var result = await _contactManager.AddNewPerson(person);
			return result;
		}
		[HttpPost("api/delete-person")]
		public async Task<IActionResult> DeletePerson(int id)
		{
			return StatusCode(200);
		}
		[HttpPost("api/add-contact-info")]
		public async Task<IActionResult> AddContactInfo(ContactRequest contactRequest)
		{
			return StatusCode(200);
		}
		[HttpPost("api/delete-contact-info")]
		public async Task<IActionResult> DeleteContactInfo(int id)
		{
			return StatusCode(200);
		}
		[HttpGet("api/get-people")]
		public async Task<IActionResult> GetPeople()
		{
			return StatusCode(200);
		}
		[HttpGet("api/get-person-info")]
		public async Task<IActionResult> GetPersonInfo(int id)
		{
			return StatusCode(200);
		}
	}
}
