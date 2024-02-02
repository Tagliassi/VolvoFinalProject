using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using AutoMapper;

namespace VolvoFinalProject.Api.DTOService.Services
{
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _repository;
        private readonly IMapper _mapper;

        public ContactsService(IContactsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ContactsDTO> AddEntity(ContactsDTO entity)
        {
            var Contacts = _mapper.Map<Contacts>(entity);
            var IncludedContacts = await _repository.AddEntity(Contacts);
            return _mapper.Map<ContactsDTO>(IncludedContacts);
        }

        public async Task DeleteEntity(int id)
        {
            var existingContacts = await _repository.GetOneEntity(id);

            if (existingContacts == null)
            {
                throw new ErrorViewModel("Contacts Not Found", $"Contacts with Id {id} not found.");
            }

            try
            {
                await _repository.DeleteEntity(id);

                //map the deleted entity to a DTO and return it
                var deletedContacts = _mapper.Map<ContactsDTO>(existingContacts);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Deleting Contacts", $"{ex.Message}");
            }
        }

        public async Task<ICollection<ContactsDTO>> GetAllEntity()
        {
            var Contacts = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<ContactsDTO>>(Contacts);
        }

        public async Task<ContactsDTO> GetOneEntity(int id)
        {
            var Contacts = await _repository.GetOneEntity(id);
            return _mapper.Map<ContactsDTO>(Contacts);
        }

        public async Task<ContactsDTO> UpdateEntity(int id, ContactsDTO entity)
        {
            var Contacts = _mapper.Map<Contacts>(entity);
            var UptadedContacts = await _repository.UpdateEntity(Contacts.ContactsID, Contacts);
            return _mapper.Map<ContactsDTO>(UptadedContacts);
        }
    }
}