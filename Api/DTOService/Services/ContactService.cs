using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            var contacts = _mapper.Map<Contacts>(entity);

            if (contacts == null)
            {
                throw new Exception("Error mapping ContactsDTO to Contacts entity.");
            }

            var includedContacts = await _repository.AddEntity(contacts);

            if (includedContacts == null)
            {
                throw new Exception("Error adding Contacts entity to the repository.");
            }

            return _mapper.Map<ContactsDTO>(includedContacts);
        }

        public async Task DeleteEntity(int id)
        {
            var existingContacts = await _repository.GetOneEntity(id);

            if (existingContacts == null)
            {
                throw new ErrorViewModel("Contacts Not Found", $"Contacts with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            var deletedContacts = _mapper.Map<ContactsDTO>(existingContacts);

            if (deletedContacts == null)
            {
                throw new Exception("Error mapping deleted Contacts entity to ContactsDTO.");
            }
        }

        public async Task<ICollection<ContactsDTO>> GetAllEntity()
        {
            var contacts = await _repository.GetAllEntity();

            if (contacts == null)
            {
                throw new Exception("Error getting all Contacts entities from the repository.");
            }

            return _mapper.Map<ICollection<ContactsDTO>>(contacts);
        }

        public async Task<ContactsDTO> GetOneEntity(int id)
        {
            var contacts = await _repository.GetOneEntity(id);

            if (contacts == null)
            {
                throw new ErrorViewModel("Contacts Not Found", $"Contacts with Id {id} not found.");
            }

            return _mapper.Map<ContactsDTO>(contacts);
        }

        public async Task<ContactsDTO> UpdateEntity(int id, ContactsDTO entity)
        {
            var contacts = _mapper.Map<Contacts>(entity);

            if (contacts == null)
            {
                throw new Exception("Error mapping ContactsDTO to Contacts entity.");
            }

            var updatedContacts = await _repository.UpdateEntity(id, contacts);

            if (updatedContacts == null)
            {
                throw new Exception("Error updating Contacts entity in the repository.");
            }

            return _mapper.Map<ContactsDTO>(updatedContacts);
        }
    }
}