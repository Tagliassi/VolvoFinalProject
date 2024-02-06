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
    public class VehicleController : ControllerBase
    {       
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;

        private readonly IVehicleRepository _vehicleRepository;

        private readonly IUnitOfWork _unitOfWork;

        // Constructor to initialize dependencies
        public VehicleController(IMapper mapper, IVehicleService vehicleService,IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _vehicleService = vehicleService;
            _unitOfWork = unitOfWork;
            _vehicleRepository = vehicleRepository;
        }

        // GET: api/Vehicle
        // Get all vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllEntity();
            var vehicleDTOs = _mapper.Map<IEnumerable<VehicleDTO>>(vehicles);
            _unitOfWork.Commit();
            return Ok(vehicleDTOs);
        }

        // GET: api/Vehicle/5
        // Get a specific vehicle by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDTO>> GetVehicleById(int id)
        {
            var vehicle = await _vehicleService.GetOneEntity(id);
            var vehicleDTO = _mapper.Map<VehicleDTO>(vehicle);
            _unitOfWork.Commit();
            return Ok(vehicleDTO);
        }

        // GET: api/Vehicle/kilometers?Kilometrage=50000&SystemVersion=VOLVO FH16 D13A
        [HttpGet("kilometers")]
        public async Task<ActionResult> GetVehicleByKmAndSystemVersion(
            [FromQuery] int Kilometrage,
            [FromQuery] string SystemVersion
        )
        {
            var vehicle = await _vehicleRepository.GetVehicleByKmAndSystemVersion(Kilometrage, SystemVersion);
            return Ok(vehicle);
        }

        // POST: api/Vehicle
        // Add a new vehicle
        [HttpPost]
        public async Task<ActionResult<VehicleDTO>> AddVehicle([FromBody] VehicleDTO vehicleDTO)
        {
            var addedVehicle = await _vehicleService.AddEntity(vehicleDTO);
            var addedVehicleDTO = _mapper.Map<VehicleDTO>(addedVehicle);
            //return CreatedAtAction(nameof(GetVehicleById), new { id = addedVehicleDTO.VehicleID }, addedVehicleDTO);
            _unitOfWork.Commit();
            return Ok(addedVehicleDTO);
        }

        // PUT: api/Vehicle/5
        // Update an existing vehicle by ID
        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleDTO>> UpdateVehicle(int id, [FromBody] VehicleDTO vehicleDTO)
        {
            var updatedVehicle = await _vehicleService.UpdateEntity(id, vehicleDTO);
            var updatedVehicleDTO = _mapper.Map<VehicleDTO>(updatedVehicle);
            _unitOfWork.Commit();
            return Ok(updatedVehicleDTO);
        }

        // DELETE: api/Vehicle/5
        // Delete a vehicle by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            await _vehicleService.DeleteEntity(id);
            _unitOfWork.Commit();
            return NoContent();
        }
    }
}