using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Model.Models.Enum;
using VolvoFinalProject.Api.DTOService.Services;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.DTO;

namespace VolvoFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ServiceService _serviceService;

        private readonly IUnitOfWork _unitOfWork;

        public ServiceController(IMapper mapper, ServiceService serviceService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _serviceService = serviceService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Service
        // Get all services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAllServices()
        {
            var services = await _serviceService.GetAllEntity();
            var serviceDTOs = _mapper.Map<IEnumerable<ServiceDTO>>(services);
            _unitOfWork.Commit();
            return Ok(serviceDTOs);
        }

        // GET: api/Service/5
        // Get a specific service by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetServiceById(int id)
        {
            var service = await _serviceService.GetOneEntity(id);
            var serviceDTO = _mapper.Map<ServiceDTO>(service);
            _unitOfWork.Commit();
            return Ok(serviceDTO);
        }

        // POST: api/Service
        // Add a new service
        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> AddService([FromBody] ServiceDTO serviceDTO)
        {
            var addedService = await _serviceService.AddEntity(serviceDTO);
            var addedServiceDTO = _mapper.Map<ServiceDTO>(addedService);
            //return CreatedAtAction(nameof(GetServiceById), new { id = addedServiceDTO.ServiceID }, addedServiceDTO);
            _unitOfWork.Commit();
            return Ok(addedServiceDTO);
        }

        // PUT: api/Service/5
        // Update an existing service by ID
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceDTO>> UpdateService(int id, [FromBody] ServiceDTO serviceDTO)
        {
            var updatedService = await _serviceService.UpdateEntity(id, serviceDTO);
            var updatedServiceDTO = _mapper.Map<ServiceDTO>(updatedService);
            _unitOfWork.Commit();
            return Ok(updatedServiceDTO);
        }

        // DELETE: api/Service/5
        // Delete a service by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}