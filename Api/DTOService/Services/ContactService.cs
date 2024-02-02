using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Exceptions;
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

        public Task<ContactsDTO> AddEntity(ContactsDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ContactsDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<ContactsDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ContactsDTO> UpdateEntity(int id, ContactsDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}