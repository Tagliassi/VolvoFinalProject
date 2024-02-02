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
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _repository;
        private readonly IMapper _mapper;

        public DealerService(IDealerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public Task<DealerDTO> AddEntity(DealerDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DealerDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<DealerDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DealerDTO> UpdateEntity(int id, DealerDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}