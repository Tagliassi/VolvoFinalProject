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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<EmployeeDTO> AddEntity(EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EmployeeDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDTO> UpdateEntity(int id, EmployeeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}