using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            var existingService = await _repository.GetOneEntity(id);

            if (existingService == null)
            {
                throw new ErrorViewModel("Service Not Found", $"Service with Id {id} not found.");
            }

            existingService.Situation = newStatus;

            var updatedService = await _repository.UpdateEntity(existingService.ServiceID, existingService);

            if (updatedService == null)
            {
                throw new Exception("Error mapping updated Service to DTO.");
            }

            return _mapper.Map<ServiceDTO>(updatedService);
        }

        public async Task<ServiceDTO> AddEntity(ServiceDTO entity)
        {
            var service = _mapper.Map<Service>(entity);
            var includedService = await _repository.AddEntity(service);
            return _mapper.Map<ServiceDTO>(includedService);
        }

        public async Task DeleteEntity(int id)
        {
            var existingService = await _repository.GetOneEntity(id);

            if (existingService == null)
            {
                throw new ErrorViewModel("Service Not Found", $"Service with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            // Exceção se o mapeamento resultar em null?
            var deletedServiceDTO = _mapper.Map<ServiceDTO>(existingService);
            
        }

        public async Task<ICollection<ServiceDTO>> GetAllEntity()
        {
            var services = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<ServiceDTO>>(services);
        }

        public async Task<ServiceDTO> GetOneEntity(int id)
        {
            var service = await _repository.GetOneEntity(id);
            return _mapper.Map<ServiceDTO>(service);
        }

        public async Task<ServiceDTO> UpdateEntity(int id, ServiceDTO entity)
        {
            var service = _mapper.Map<Service>(entity);
            var updatedService = await _repository.UpdateEntity(service.ServiceID, service);

            if (updatedService == null)
            {
                throw new Exception("Error mapping updated Service to DTO.");
            }

            return _mapper.Map<ServiceDTO>(updatedService);
        }
    }
}