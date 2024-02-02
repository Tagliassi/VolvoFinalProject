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
    public class BillService : IBillService
    {
        private readonly IBillRepository _repository;
        private readonly IMapper _mapper;

        public BillService(IBillRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BillDTO> AddEntity(BillDTO entity)
        {
            var Bill = _mapper.Map<Bill>(entity);
            var IncludedBill = await _repository.AddEntity(Bill);
            return _mapper.Map<BillDTO>(IncludedBill);
        }

        public async Task DeleteEntity(int id)
        {
            var existingBill = await _repository.GetOneEntity(id);

            if (existingBill == null)
            {
                throw new ErrorViewModel("Bill Not Found", $"Bill with Id {id} not found.");
            }

            try
            {
                await _repository.DeleteEntity(id);

                //map the deleted entity to a DTO and return it
                var deletedBill = _mapper.Map<BillDTO>(existingBill);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Deleting Bill", $"{ex.Message}");
            }
        }

        public async Task<ICollection<BillDTO>> GetAllEntity()
        {
            var Bills = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<BillDTO>>(Bills);
        }

        public async Task<BillDTO> GetOneEntity(int id)
        {
            var Bills = await _repository.GetOneEntity(id);
            return _mapper.Map<BillDTO>(Bills);
        }

        public async Task<BillDTO> UpdateEntity(int id, BillDTO entity)
        {
            var Bill = _mapper.Map<Bill>(entity);
            var UptadedBill = await _repository.UpdateEntity(Bill.BillID, Bill);
            return _mapper.Map<BillDTO>(UptadedBill);
        }
    }
}