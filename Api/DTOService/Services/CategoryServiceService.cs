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
    public class CategoryServiceService : ICategoryServiceService
    {       
        private readonly ICategoryServiceRepository _repository;
        private readonly IMapper _mapper;

        public CategoryServiceService(ICategoryServiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public Task<CategoryServiceDTO> AddEntity(CategoryServiceDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CategoryServiceDTO>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryServiceDTO> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryServiceDTO> UpdateEntity(int id, CategoryServiceDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}