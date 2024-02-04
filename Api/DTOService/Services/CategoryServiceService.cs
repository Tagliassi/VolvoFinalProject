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
            var categoryService = _mapper.Map<CategoryService>(entity);

            if (categoryService == null)
            {
                throw new Exception("Error mapping CategoryServiceDTO to CategoryService entity.");
            }

            var includedCategoryService = await _repository.AddEntity(categoryService);

            if (includedCategoryService == null)
            {
                throw new Exception("Error adding CategoryService entity to the repository.");
            }

            return _mapper.Map<CategoryServiceDTO>(includedCategoryService);
        }

        public async Task DeleteEntity(int id)
        {
            var existingCategoryService = await _repository.GetOneEntity(id);

            if (existingCategoryService == null)
            {
                throw new ErrorViewModel("CategoryService Not Found", $"CategoryService with Id {id} not found.");
            }

            await _repository.DeleteEntity(id);

            var deletedCategoryService = _mapper.Map<CategoryServiceDTO>(existingCategoryService);

            if (deletedCategoryService == null)
            {
                throw new Exception("Error mapping deleted CategoryService entity to CategoryServiceDTO.");
            }
        }

        public async Task<ICollection<CategoryServiceDTO>> GetAllEntity()
        {
            var categoryServices = await _repository.GetAllEntity();

            if (categoryServices == null)
            {
                throw new Exception("Error getting all CategoryService entities from the repository.");
            }

            return _mapper.Map<ICollection<CategoryServiceDTO>>(categoryServices);
        }

        public async Task<CategoryServiceDTO> GetOneEntity(int id)
        {
            var categoryService = await _repository.GetOneEntity(id);

            if (categoryService == null)
            {
                throw new ErrorViewModel("CategoryService Not Found", $"CategoryService with Id {id} not found.");
            }

            return _mapper.Map<CategoryServiceDTO>(categoryService);
        }

        public async Task<CategoryServiceDTO> UpdateEntity(int id, CategoryServiceDTO entity)
        {
            var categoryService = _mapper.Map<CategoryService>(entity);

            if (categoryService == null)
            {
                throw new Exception("Error mapping CategoryServiceDTO to CategoryService entity.");
            }

            var updatedCategoryService = await _repository.UpdateEntity(id, categoryService);

            if (updatedCategoryService == null)
            {
                throw new Exception("Error updating CategoryService entity in the repository.");
            }

            return _mapper.Map<CategoryServiceDTO>(updatedCategoryService);
        }
    }
}