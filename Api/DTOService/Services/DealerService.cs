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

namespace VolvoFinalProject.Api.DTOService.Services
{

    /// Service class responsible for handling operations related to the Dealer entity.
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _repository;
        private readonly IMapper _mapper;

        public DealerService(IDealerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new Dealer entity using the provided DTO.
        /// </summary>
        /// <param name="entity">DTO containing the information for the new Dealer.</param>
        /// <returns>DTO representing the added Dealer.</returns>
        public async Task<DealerDTO> AddEntity(DealerDTO entity)
        {
            var Dealer = _mapper.Map<Dealer>(entity);
            var IncludedDealer = await _repository.AddEntity(Dealer);
            return _mapper.Map<DealerDTO>(IncludedDealer);
        }

        public async Task DeleteEntity(int id)
        {
            var existingDealer = await _repository.GetOneEntity(id);

            if (existingDealer == null)
            {
                throw new ErrorViewModel("Dealer Not Found", $"Dealer with Id {id} not found.");
            }

            DealerDTO? deletedDealerDTO = null;

            try
            {
                await _repository.DeleteEntity(id);
                deletedDealerDTO = _mapper.Map<DealerDTO>(existingDealer);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Deleting Dealer", ex.Message);
            }  
        }

        public async Task<ICollection<DealerDTO>> GetAllEntity()
        {
            var Dealers = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<DealerDTO>>(Dealers);
        }

        public async Task<DealerDTO> GetOneEntity(int id)
        {
            var Dealer = await _repository.GetOneEntity(id);
            return _mapper.Map<DealerDTO>(Dealer);
        }
        
        public async Task<DealerDTO> UpdateEntity(int id, DealerDTO entity)
        {
            var dealer = _mapper.Map<Dealer>(entity);
            var updatedDealer = await _repository.UpdateEntity(id, dealer);
            return _mapper.Map<DealerDTO>(updatedDealer);
        }      
    }
}