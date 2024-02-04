using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using AutoMapper;
using VolvoFinalProject.Api.Repository.Repositories;

namespace VolvoFinalProject.Api.DTOService.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _repository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public BillService(IBillRepository repository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // Calculate total bill for a customer based on services
        public async Task<double> CalculateBill(Customer customer)
        {
            var bill = 0.0;
            var services = await _customerRepository.GetServicesByCustomer(customer.CustomerID);
            foreach (var custService in services)
            {
                var value = custService.Value;
                bill += value;
            }
            return bill;
        }

        // Add a new Bill entity
        public async Task<BillDTO> AddEntity(BillDTO entity)
        {
            var bill = _mapper.Map<Bill>(entity);

            // Validate entity after mapping
            if (bill == null)
            {
                throw new Exception("Error mapping BillDTO to Bill entity.");
            }

            var includedBill = await _repository.AddEntity(bill);

            // Validate entity after addition
            if (includedBill == null)
            {
                throw new Exception("Error adding Bill entity to the repository.");
            }

            return _mapper.Map<BillDTO>(includedBill);
        }

        // Delete a Bill entity by ID
        public async Task DeleteEntity(int id)
        {
            var existingBill = await _repository.GetOneEntity(id);

            if (existingBill == null)
            {
                throw new ErrorViewModel("Bill Not Found", $"Bill with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            // Map the deleted entity to a DTO
            var deletedBill = _mapper.Map<BillDTO>(existingBill);

            // Validate entity after mapping
            if (deletedBill == null)
            {
                throw new Exception("Error mapping deleted Bill entity to BillDTO.");
            }
        }

        // Get all Bill entities
        public async Task<ICollection<BillDTO>> GetAllEntity()
        {
            var bills = await _repository.GetAllEntity();

            // Validate entity after retrieval
            if (bills == null)
            {
                throw new Exception("Error getting all Bill entities from the repository.");
            }

            return _mapper.Map<ICollection<BillDTO>>(bills);
        }

        // Get a specific Bill entity by ID
        public async Task<BillDTO> GetOneEntity(int id)
        {
            var bill = await _repository.GetOneEntity(id);

            if (bill == null)
            {
                throw new ErrorViewModel("Bill Not Found", $"Bill with Id {id} not found.");
            }

            return _mapper.Map<BillDTO>(bill);
        }

        // Update a Bill entity by ID
        public async Task<BillDTO> UpdateEntity(int id, BillDTO entity)
        {
            var bill = _mapper.Map<Bill>(entity);

            // Validate entity after mapping
            if (bill == null)
            {
                throw new Exception("Error mapping BillDTO to Bill entity.");
            }

            var updatedBill = await _repository.UpdateEntity(id, bill);

            // Validate entity after update
            if (updatedBill == null)
            {
                throw new Exception("Error updating Bill entity in the repository.");
            }

            return _mapper.Map<BillDTO>(updatedBill);
        }
    }
}