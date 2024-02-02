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
            var Parts = _mapper.Map<Parts>(entity);
            var IncludedParts = await _repository.AddEntity(Parts);
            return _mapper.Map<PartsDTO>(IncludedParts);
        }

        public async Task DeleteEntity(int id)
        {
            var existingParts= await _repository.GetOneEntity(id);

            if (existingParts == null)
            {
                throw new ErrorViewModel("Parts Not Found", $"Parts with Id {id} not found.");
            }

            try
            {
                await _repository.DeleteEntity(id);

                var deletedPartsDTO = _mapper.Map<PartsDTO>(existingParts);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Deleting Parts", $"{ex.Message}");
            }
        }

        public async Task<ICollection<PartsDTO>> GetAllEntity()
        {
            var Parts = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<PartsDTO>>(Parts);
        }

        public async Task<PartsDTO> GetOneEntity(int id)
        {
            var Parts = await _repository.GetOneEntity(id);
            return _mapper.Map<PartsDTO>(Parts);
        }

        public async Task<PartsDTO> UpdateEntity(int id, PartsDTO entity)
        {
            var Parts = _mapper.Map<Parts>(entity);
            var UptadedParts = await _repository.UpdateEntity(Parts.PartID, Parts);
            return _mapper.Map<PartsDTO>(UptadedParts);
        }
    }
}