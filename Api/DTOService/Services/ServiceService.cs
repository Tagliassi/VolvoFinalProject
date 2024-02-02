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
using VolvoFinalProject.Api.Model.Models.Enum;

namespace VolvoFinalProject.Api.DTOService.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceDTO> UpdateServiceStatus(int id, EnumSituation newStatus)
        {
            // Obtenha o serviço existente pelo ID
            var existingService = await _repository.GetOneEntity(id);

            if (existingService == null)
            {
                throw new ErrorViewModel("Service Not Found", $"Service with Id {id} not found.");
            }

            // Atualize o status do serviço
            existingService.Situation = newStatus;

            try
            {
                // Atualize o serviço no repositório
                var updatedService = await _repository.UpdateEntity(existingService.ServiceID, existingService);

                // Mapeie o serviço atualizado para um DTO e retorne
                return _mapper.Map<ServiceDTO>(updatedService);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Updating Service Status", $"{ex.Message}");
            }
        }

        public async Task<ServiceDTO> AddEntity(ServiceDTO entity)
        {
            var Service = _mapper.Map<Service>(entity);
            var IncludedService = await _repository.AddEntity(Service);
            return _mapper.Map<ServiceDTO>(IncludedService);
        }

        public async Task DeleteEntity(int id)
        {
            var existingService= await _repository.GetOneEntity(id);

            if (existingService == null)
            {
                throw new ErrorViewModel("Service Not Found", $"Service with Id {id} not found.");
            }

            try
            {
                await _repository.DeleteEntity(id);

                var deletedServiceDTO = _mapper.Map<ServiceDTO>(existingService);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Deleting Service", $"{ex.Message}");
            }
        }

        public async Task<ICollection<ServiceDTO>> GetAllEntity()
        {
            var Services = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<ServiceDTO>>(Services);
        }

        public async Task<ServiceDTO> GetOneEntity(int id)
        {
            var Service = await _repository.GetOneEntity(id);
            return _mapper.Map<ServiceDTO>(Service);
        }

        public async Task<ServiceDTO> UpdateEntity(int id, ServiceDTO entity)
        {
            var Service = _mapper.Map<Service>(entity);
            var UptadedService = await _repository.UpdateEntity(Service.ServiceID, Service);
            return _mapper.Map<ServiceDTO>(UptadedService);
        }
    }
}