using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.DTOService.Services;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {       
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor to initialize dependencies
        public EmployeeController(IMapper mapper, IEmployeeService employeeService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _employeeService = employeeService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Employee
        // Get all employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEntity();
            var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            _unitOfWork.Commit();
            return Ok(employeeDTOs);
        }

        // GET: api/Employee/5
        // Get a specific employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetOneEntity(id);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            _unitOfWork.Commit();
            return Ok(employeeDTO);
        }

        // GET: api/Employee/5/salary
        [HttpGet("{id}/salary")]
        public async Task<IActionResult> GetEmployeeSalary(int id)
        {
            var employee = await _employeeService.GetOneEntity(id); 

            if (employee == null)
            {
                return NotFound(); 
            }

            var salary = await _employeeService.CalculateSalary(employee);

            employee.Salary = salary;

            return Ok(employee);
        }

        // POST: api/Employee
        // Add a new employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            var addedEmployee = await _employeeService.AddEntity(employeeDTO);
            var addedEmployeeDTO = _mapper.Map<EmployeeDTO>(addedEmployee);
            //return CreatedAtAction(nameof(GetEmployeeById), new { id = addedEmployeeDTO.EmployeeID }, addedEmployeeDTO);
            _unitOfWork.Commit();
            return Ok(addedEmployeeDTO);
        }

        // PUT: api/Employee/5
        // Update an existing employee by ID
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            var updatedEmployee = await _employeeService.UpdateEntity(id, employeeDTO);
            var updatedEmployeeDTO = _mapper.Map<EmployeeDTO>(updatedEmployee);
            _unitOfWork.Commit();
            return Ok(updatedEmployeeDTO);
        }

        // DELETE: api/Employee/5
        // Delete a employee by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}