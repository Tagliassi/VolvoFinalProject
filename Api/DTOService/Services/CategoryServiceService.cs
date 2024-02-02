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
        
        public async Task<CategoryServiceDTO> AddEntity(CategoryServiceDTO entity)
        {
            var CategoryService = _mapper.Map<CategoryService>(entity);
            var IncludedCategoryService= await _repository.AddEntity(CategoryService);
            return _mapper.Map<CategoryServiceDTO>(IncludedCategoryService);
        }

        public async Task DeleteEntity(int id)
        {
            var existingCategoryService = await _repository.GetOneEntity(id);

            if (existingCategoryService == null)
            {
                throw new ErrorViewModel("CategoryService Not Found", $"CategoryService with Id {id} not found.");
            }

            try
            {
                await _repository.DeleteEntity(id);

                //map the deleted entity to a DTO and return it
                var deletedCategoryService = _mapper.Map<CategoryServiceDTO>(existingCategoryService);
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Deleting CategoryService", $"{ex.Message}");
            }
        }

        public async Task<ICollection<CategoryServiceDTO>> GetAllEntity()
        {
            var CategoryServices = await _repository.GetAllEntity();
            return _mapper.Map<ICollection<CategoryServiceDTO>>(CategoryServices);
        }

        public async Task<CategoryServiceDTO> GetOneEntity(int id)
        {
            var CategoryService = await _repository.GetOneEntity(id);
            return _mapper.Map<CategoryServiceDTO>(CategoryService);
        }

        public async Task<CategoryServiceDTO> UpdateEntity(int id, CategoryServiceDTO entity)
        {
            var CategoryService = _mapper.Map<CategoryService>(entity);
            var UptadedCategoryService = await _repository.UpdateEntity(CategoryService.CategoryServiceID, CategoryService);
            return _mapper.Map<CategoryServiceDTO>(UptadedCategoryService);
        }
    }
}