using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Services.Contacts.Entities;
using PhoneBookApp.Services.Contacts.Models;
using PhoneBookApp.Services.Contacts.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApp.Services.Contacts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> Get(Guid contactId)
        {
            if (contactId == Guid.Empty)
                return BadRequest();

            var contact = await _contactRepository.GetContactByIdAsync(contactId);
            if(contact == null)
                return NotFound();

            return Ok(new ContactItemDto() 
            { 
                Id = contact.Id, 
                FirstName = contact.FirstName, 
                LastName = contact.LastName, 
                PhoneNumber = contact.PhoneNumber 
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ContactQuery contactQuery)
        {
            var contacts = await _contactRepository.GetContactsAsync(contactQuery);

            var result = new ContactListResult()
            {
                ResultCount = contacts.Count(),
                Items = contacts.Select(c => new ContactItemDto()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    PhoneNumber = c.PhoneNumber
                }).ToList()
            };

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactEditDto contactDto)
        {
            if (!TryValidateModel(contactDto))
                return BadRequest();

            var contactEntity = new Contact() 
            { 
                Id = Guid.NewGuid(), 
                FirstName = contactDto.FirstName, 
                LastName = contactDto.LastName, 
                PhoneNumber = contactDto.PhoneNumber 
            };
            await _contactRepository.AddContactAsync(contactEntity);
            
            return Created($"/Contact/{contactEntity.Id}", contactEntity);
        }

        [HttpPut("{contactId}")]
        public async Task<IActionResult> Put([FromBody] ContactEditDto contactDto, Guid contactId)
        {
            if (!TryValidateModel(contactDto) || contactId == Guid.Empty)
                return BadRequest();

            var contactEntity = await _contactRepository.GetContactByIdAsync(contactId);

            if (contactEntity == null)
                return NotFound();

            contactEntity.PhoneNumber = contactDto.PhoneNumber;
            contactEntity.FirstName = contactDto.FirstName;
            contactEntity.LastName = contactDto.LastName;

            await _contactRepository.UpdateContactAsync(contactEntity);

            return NoContent();
           
        }

        [HttpDelete("{contactId}")]
        public async Task<IActionResult> Delete(Guid contactId)
        {
            await _contactRepository.DeleteContactAsync(contactId);
            return NoContent();
        }
    }
}
