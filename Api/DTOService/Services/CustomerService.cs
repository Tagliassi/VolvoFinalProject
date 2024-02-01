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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public Task<CustomerDTO> AddEntity(CustomerDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CustomerDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> UpdateEntity(int id, CustomerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}