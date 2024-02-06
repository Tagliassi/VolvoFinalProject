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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<double> CalculateSalary(EmployeeDTO employee)
        {
            var salary = employee.BaseSalary;
            var services = await _repository.GetServicesByEmployee(employee.EmployeeID);

            foreach (var empService in services)
            {
                var value = empService.Value * employee.Commission;
                salary += value;
            }

            return salary;
        }

        public async Task<EmployeeDTO> AddEntity(EmployeeDTO entity)
        {
            var employee = _mapper.Map<Employee>(entity);

            if (employee == null)
            {
                throw new Exception("Error mapping EmployeeDTO to Employee entity.");
            }

            var includedEmployee = await _repository.AddEntity(employee);

            if (includedEmployee == null)
            {
                throw new Exception("Error adding Employee entity to the repository.");
            }

            return _mapper.Map<EmployeeDTO>(includedEmployee);
        }

        public async Task DeleteEntity(int id)
        {
            var existingEmployee = await _repository.GetOneEntity(id);

            if (existingEmployee == null)
            {
                throw new ErrorViewModel("Employee Not Found", $"Employee with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            var deletedEmployeeDTO = _mapper.Map<EmployeeDTO>(existingEmployee);

            if (deletedEmployeeDTO == null)
            {
                throw new Exception("Error mapping deleted Employee entity to EmployeeDTO.");
            }
        }

        public async Task<ICollection<EmployeeDTO>> GetAllEntity()
        {
            var employees = await _repository.GetAllEntity();

            if (employees == null)
            {
                throw new Exception("Error getting all Employee entities from the repository.");
            }

            return _mapper.Map<ICollection<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetOneEntity(int id)
        {
            var employee = await _repository.GetOneEntity(id);

            if (employee == null)
            {
                throw new ErrorViewModel("Employee Not Found", $"Employee with Id {id} not found.");
            }

            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<EmployeeDTO> UpdateEntity(int id, EmployeeDTO entity)
        {
            var employee = _mapper.Map<Employee>(entity);

            if (employee == null)
            {
                throw new Exception("Error mapping EmployeeDTO to Employee entity.");
            }

            var updatedEmployee = await _repository.UpdateEntity(employee.EmployeeID, employee);

            if (updatedEmployee == null)
            {
                throw new Exception("Error updating Employee entity in the repository.");
            }

            return _mapper.Map<EmployeeDTO>(updatedEmployee);
        }
    }
}