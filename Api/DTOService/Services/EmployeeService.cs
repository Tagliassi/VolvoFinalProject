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

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> AddEntity(EmployeeDTO entity)
        {
            var Employee = _mapper.Map<Employee>(entity);
            var IncludedEmployee = await _repository.AddEntity(Employee);
            return _mapper.Map<EmployeeDTO>(IncludedEmployee);
        }

        public async Task<ICollection<EmployeeDTO>> GetAllEntity()
        {
            var Employees = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<EmployeeDTO>>(Employees);
        }

        public async Task<EmployeeDTO> GetOneEntity(int id)
        {
            var Employee = await _repository.GetOneEntity(id);
            return _mapper.Map<EmployeeDTO>(Employee);
        }

        public async Task<EmployeeDTO> UpdateEntity(int id, EmployeeDTO entity)
        {
            var Employee = _mapper.Map<Employee>(entity);
            var UptadedEmployee = await _repository.UpdateEntity(Employee.EmployeeID, Employee);
            return _mapper.Map<EmployeeDTO>(UptadedEmployee);
        }
    }
}