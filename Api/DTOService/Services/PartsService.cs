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
        public Task<PartsDTO> AddEntity(PartsDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PartsDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<PartsDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PartsDTO> UpdateEntity(int id, PartsDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}