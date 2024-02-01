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

        public BillService(IBillRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BillDTO> AddEntity(BillDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<BillDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<BillDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BillDTO> UpdateEntity(int id, BillDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

