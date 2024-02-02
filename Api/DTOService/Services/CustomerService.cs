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

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> AddEntity(CustomerDTO entity)
        {
            var Customer = _mapper.Map<Customer>(entity);
            var IncludedCustomer = await _repository.AddEntity(Customer);
            return _mapper.Map<CustomerDTO>(IncludedCustomer);
        }
        
       public async Task DeleteEntity(int id)
        {
            var existingCustomer= await _repository.GetOneEntity(id);

            if (existingCustomer == null)
            {
                throw new ErrorViewModel("Customer Not Found", $"Customer with Id {id} not found.");
            }

            try
            {
                await _repository.DeleteEntity(id);

                var deletedCustomerDTO = _mapper.Map<CustomerDTO>(existingCustomer);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Deleting Customer", $"{ex.Message}");
            }
        }

        public async Task<ICollection<CustomerDTO>> GetAllEntity()
        {
            var Customers = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<CustomerDTO>>(Customers);
        }

        public async Task<CustomerDTO> GetOneEntity(int id)
        {
            var Customer = await _repository.GetOneEntity(id);
            return _mapper.Map<CustomerDTO>(Customer);
        }

        public async Task<CustomerDTO> UpdateEntity(int id, CustomerDTO entity)
        {
            var Customer = _mapper.Map<Customer>(entity);
            var UptadedCustomer = await _repository.UpdateEntity(Customer.CustomerID, Customer);
            return _mapper.Map<CustomerDTO>(UptadedCustomer);
        }
    }
}