using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class CategoryServiceRepository : ICategoryServiceRepository
    {
        private ProjectContext _context;

        public CategoryServiceRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Parts>> GetPartsByCategoryService(int CategoryServiceId)
        {
            try
            {
                var categoryService = await _context.CategoryServices
                    .Include(cs => cs.Parts)
                    .FirstOrDefaultAsync(cs => cs.CategoryServiceID == CategoryServiceId);

                if (categoryService != null)
                {
                    return categoryService.Parts.ToList();
                }

                return new List<Parts>();
                throw new ErrorViewModel("Parts Not Found", $"Parts with Id {CategoryServiceId} not found.");
            }
            catch (Exception ex)
            {
                throw new ErrorViewModel("Error Found", $"Error: {ex.Message}");
            }
        }

        public async Task<CategoryService> AddEntity(CategoryService entity)
        {
            await _context.Set<CategoryService>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<CategoryService>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<CategoryService>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Service category Not Found", $"Service category with Id {id} not found.");
        }

        public async Task<ICollection<CategoryService>> GetAllEntity()
        {
            var entities = await _context.Set<CategoryService>().ToListAsync<CategoryService>();
            return entities;
        }

        public async Task<CategoryService> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<CategoryService>()
                .Include("Service")
                .SingleAsync(w => w.CategoryServiceID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Service category Not Found", $"Service category with Id {id} not found.");
        }

        public async Task<CategoryService> UpdateEntity(int id, CategoryService entity)
        {
            var oldEntity = await _context.Set<CategoryService>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<CategoryService>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Service category Found", $"Service category with Id {id} not found.");
        }
    }
}