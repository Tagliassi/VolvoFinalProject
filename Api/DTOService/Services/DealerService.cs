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
    /// <summary>
    /// Service class responsible for handling operations related to the Dealer entity.
    /// </summary>
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
            var dealer = _mapper.Map<Dealer>(entity);

            if (dealer == null)
            {
                throw new Exception("Error mapping DealerDTO to Dealer entity.");
            }

            var includedDealer = await _repository.AddEntity(dealer);

            if (includedDealer == null)
            {
                throw new Exception("Error adding Dealer entity to the repository.");
            }

            return _mapper.Map<DealerDTO>(includedDealer);
        }

        public async Task DeleteEntity(int id)
        {
            var existingDealer = await _repository.GetOneEntity(id);

            if (existingDealer == null)
            {
                throw new ErrorViewModel("Dealer Not Found", $"Dealer with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            var deletedDealerDTO = _mapper.Map<DealerDTO>(existingDealer);

            if (deletedDealerDTO == null)
            {
                throw new Exception("Error mapping deleted Dealer entity to DealerDTO.");
            }
        }

        public async Task<ICollection<DealerDTO>> GetAllEntity()
        {
            var dealers = await _repository.GetAllEntity();

            if (dealers == null)
            {
                throw new Exception("Error getting all Dealer entities from the repository.");
            }

            return _mapper.Map<ICollection<DealerDTO>>(dealers);
        }

        public async Task<DealerDTO> GetOneEntity(int id)
        {
            var dealer = await _repository.GetOneEntity(id);

            if (dealer == null)
            {
                throw new ErrorViewModel("Dealer Not Found", $"Dealer with Id {id} not found.");
            }

            return _mapper.Map<DealerDTO>(dealer);
        }

        public async Task<DealerDTO> UpdateEntity(int id, DealerDTO entity)
        {
            var dealer = _mapper.Map<Dealer>(entity);

            if (dealer == null)
            {
                throw new Exception("Error mapping DealerDTO to Dealer entity.");
            }

            var updatedDealer = await _repository.UpdateEntity(id, dealer);

            if (updatedDealer == null)
            {
                throw new Exception("Error updating Dealer entity in the repository.");
            }

            return _mapper.Map<DealerDTO>(updatedDealer);
        }      
    }
}