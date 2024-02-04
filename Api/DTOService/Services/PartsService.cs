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
    public class PartsService : IPartsService
    {
        private readonly IPartsRepository _repository;
        private readonly IMapper _mapper;

        public PartsService(IPartsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PartsDTO> AddEntity(PartsDTO entity)
        {
            var parts = _mapper.Map<Parts>(entity);

            if (parts == null)
            {
                throw new Exception("Error mapping PartsDTO to Parts entity.");
            }

            var includedParts = await _repository.AddEntity(parts);

            if (includedParts == null)
            {
                throw new Exception("Error adding Parts entity to the repository.");
            }

            return _mapper.Map<PartsDTO>(includedParts);
        }

        public async Task DeleteEntity(int id)
        {
            var existingParts = await _repository.GetOneEntity(id);

            if (existingParts == null)
            {
                throw new ErrorViewModel("Parts Not Found", $"Parts with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            var deletedPartsDTO = _mapper.Map<PartsDTO>(existingParts);

            if (deletedPartsDTO == null)
            {
                throw new Exception("Error mapping deleted Parts entity to PartsDTO.");
            }
        }

        public async Task<ICollection<PartsDTO>> GetAllEntity()
        {
            var parts = await _repository.GetAllEntity();

            if (parts == null)
            {
                throw new Exception("Error getting all Parts entities from the repository.");
            }

            return _mapper.Map<ICollection<PartsDTO>>(parts);
        }

        public async Task<PartsDTO> GetOneEntity(int id)
        {
            var parts = await _repository.GetOneEntity(id);

            if (parts == null)
            {
                throw new ErrorViewModel("Parts Not Found", $"Parts with Id {id} not found.");
            }

            return _mapper.Map<PartsDTO>(parts);
        }

        public async Task<PartsDTO> UpdateEntity(int id, PartsDTO entity)
        {
            var parts = _mapper.Map<Parts>(entity);

            if (parts == null)
            {
                throw new Exception("Error mapping PartsDTO to Parts entity.");
            }

            var updatedParts = await _repository.UpdateEntity(parts.PartID, parts);

            if (updatedParts == null)
            {
                throw new Exception("Error updating Parts entity in the repository.");
            }

            return _mapper.Map<PartsDTO>(updatedParts);
        }
    }
}