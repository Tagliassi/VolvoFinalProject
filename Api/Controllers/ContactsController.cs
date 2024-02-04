using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactsService _contactService;
        private readonly IUnitOfWork _unitOfWork;

        public ContactsController(IMapper mapper, IContactsService contactService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _contactService = contactService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactsDTO>>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllEntity();
            var contactDTOs = _mapper.Map<IEnumerable<ContactsDTO>>(contacts);
            _unitOfWork.Commit();
            return Ok(contactDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactsDTO>> GetContactById(int id)
        {
            var contact = await _contactService.GetOneEntity(id);
            var contactDTO = _mapper.Map<ContactsDTO>(contact);
            _unitOfWork.Commit();
            return Ok(contactDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ContactsDTO>> AddContact([FromBody] ContactsDTO contactDTO)
        {
            var addedContact = await _contactService.AddEntity(contactDTO);
            var addedContactDTO = _mapper.Map<ContactsDTO>(addedContact);
            _unitOfWork.Commit();
            return Ok(addedContactDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactsDTO>> UpdateContact(int id, [FromBody] ContactsDTO contactDTO)
        {
            var updatedContact = await _contactService.UpdateEntity(id, contactDTO);
            var updatedContactDTO = _mapper.Map<ContactsDTO>(updatedContact);
            _unitOfWork.Commit();
            return Ok(updatedContactDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}