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
        /// <summary>
        /// Yeni Kişi Ekleme
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/add-new-person
        ///     {
        ///       "name": "Ömer",
        ///       "surName": "Atila",
        ///       "corparete": "Rise Technology"       
        ///     }
        /// </remarks>
        /// <param name="PersonRequest"></param>       
        [HttpPost("api/add-new-person")]
		public async Task<bool> AddNewPerson(PersonRequest person)
		{
			var result = await _contactManager.AddNewPerson(person);
			return result;
		}
        /// <summary>
        /// Kişi Silme
        /// </summary>
        /// <param name="id"></param>
        [HttpPost("api/delete-person")]
		public async Task<bool> DeletePerson(int id)
		{
			var result = await _contactManager.DeletePerson(id);
			return result;
		}
        /// <summary>
        /// Kişiye Contact Bilgisi Ekleme
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/add-contact-info
        ///     {
        ///       "idPerson": 1,
        ///       "contactType": 1, //Phone=1,Mail=2,Location=3
        ///       "content": "02161234567"      
        ///     }
        /// </remarks>
        /// <param name="ContactRequest"></param>
        [HttpPost("api/add-contact-info")]
		public async Task<bool> AddContactInfo(ContactRequest contactRequest)
		{
			var result = await _contactManager.AddContactInfo(contactRequest);
			return result;
		}
        /// <summary>
        /// Contact Bilgisi Silme
        /// </summary>
        /// <param name="id"></param>
        [HttpPost("api/delete-contact-info")]
		public async Task<bool> DeleteContactInfo(int id)
		{
			var result = await _contactManager.DeleteContactInfo(id);
			return result;
		}
        /// <summary>
        /// Tüm Kişilerin Listesini Çekme
        /// </summary>
        /// <returns>Kişileri Liste olarak döner</returns>
        // GET: api/get-people
        [HttpGet("api/get-people")]
		public async Task<List<Person>> GetPeople()
		{
			var result = await _contactManager.GetPeople();
			return result;
		}
        /// <summary>
        /// Bir Kişiye bağlı kişi bilgileri ve Contact bilgileri çekme
        /// </summary>
        /// <returns>Kişi bilgilerini ve Contact bilgilerini döner</returns>
        // GET: api/get-person-info/{id}
        [HttpGet("api/get-person-info/{id}")]
		public async Task<PersonContactInfoResponse> GetPersonInfo(int id)
		{
			var result = await _contactManager.GetPersonInfo(id);
			return result;
		}
        /// <summary>
        /// Kişinin locationa bağlı rapor bilgilerini hazırlamak için endpoint
        /// </summary>
        /// <returns>RabbitMQ kuyruğuna atıldıysa true döner</returns>
        // GET: api/get-location-report/{location}
        [HttpGet("api/get-location-report/{location}")]
		public async Task<bool> GetLocationReport(string location)
		{
			var result = await _reportManager.GetLocationReport(location);
			return result;
		}
	}
}
