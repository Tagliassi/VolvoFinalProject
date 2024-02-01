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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<ServiceDTO> AddEntity(ServiceDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ServiceDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDTO> UpdateEntity(int id, ServiceDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}