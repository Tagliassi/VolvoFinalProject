using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject;
using VolvoFinalProject.Api.DTOService.Interfaces;
using VolvoFinalProject.Api.Model.DTO;
using AutoMapper;

namespace VolvoFinalProject.Api.DTOService.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<VehicleDTO> AddEntity(VehicleDTO entity)
        {
            var Vehicle = _mapper.Map<Vehicle>(entity);
            var IncludedVehicle = await _repository.AddEntity(Vehicle);
            return _mapper.Map<VehicleDTO>(IncludedVehicle);
        }

        public async Task DeleteEntity(int id)
        {
            var existingVehicle = await _repository.GetOneEntity(id);

            if (existingVehicle == null)
            {
                throw new ErrorViewModel("Vehicle Not Found", $"Vehicle with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            var deletedVehicleDTO = _mapper.Map<VehicleDTO>(existingVehicle);

            if (deletedVehicleDTO == null)
            {
                throw new Exception("Error mapping deleted Vehicle to DTO.");
            }
        }

        public async Task<ICollection<VehicleDTO>> GetAllEntity()
        {
            var Vehicles = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<VehicleDTO>>(Vehicles);
        }

        public async Task<VehicleDTO> GetOneEntity(int id)
        {
            var Vehicle = await _repository.GetOneEntity(id);
            return _mapper.Map<VehicleDTO>(Vehicle);
        }

        public async Task<VehicleDTO> UpdateEntity(int id, VehicleDTO entity)
        {
            var Vehicle = _mapper.Map<Vehicle>(entity);
            var UpdatedVehicle = await _repository.UpdateEntity(id, Vehicle);

            if (UpdatedVehicle == null)
            {
                throw new Exception("Error updating Vehicle entity.");
            }

            return _mapper.Map<VehicleDTO>(UpdatedVehicle);
        }
    }
}