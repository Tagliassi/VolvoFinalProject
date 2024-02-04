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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> AddEntity(CustomerDTO entity)
        {
            var customer = _mapper.Map<Customer>(entity);

            if (customer == null)
            {
                throw new Exception("Error mapping CustomerDTO to Customer entity.");
            }

            var includedCustomer = await _repository.AddEntity(customer);

            if (includedCustomer == null)
            {
                throw new Exception("Error adding Customer entity to the repository.");
            }

            return _mapper.Map<CustomerDTO>(includedCustomer);
        }

        public async Task DeleteEntity(int id)
        {
            var existingCustomer = await _repository.GetOneEntity(id);

            if (existingCustomer == null)
            {
                throw new ErrorViewModel("Customer Not Found", $"Customer with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            var deletedCustomerDTO = _mapper.Map<CustomerDTO>(existingCustomer);

            if (deletedCustomerDTO == null)
            {
                throw new Exception("Error mapping deleted Customer entity to CustomerDTO.");
            }
        }

        public async Task<ICollection<CustomerDTO>> GetAllEntity()
        {
            var customers = await _repository.GetAllEntity();

            if (customers == null)
            {
                throw new Exception("Error getting all Customer entities from the repository.");
            }

            return _mapper.Map<ICollection<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> GetOneEntity(int id)
        {
            var customer = await _repository.GetOneEntity(id);

            if (customer == null)
            {
                throw new ErrorViewModel("Customer Not Found", $"Customer with Id {id} not found.");
            }

            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> UpdateEntity(int id, CustomerDTO entity)
        {
            var customer = _mapper.Map<Customer>(entity);

            if (customer == null)
            {
                throw new Exception("Error mapping CustomerDTO to Customer entity.");
            }

            var updatedCustomer = await _repository.UpdateEntity(id, customer);

            if (updatedCustomer == null)
            {
                throw new Exception("Error updating Customer entity in the repository.");
            }

            return _mapper.Map<CustomerDTO>(updatedCustomer);
        }
    }
}