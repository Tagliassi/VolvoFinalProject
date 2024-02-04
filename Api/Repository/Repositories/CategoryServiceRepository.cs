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
            var categoryService = await _context.CategoryServices
                .Include(cs => cs.Parts)
                .FirstOrDefaultAsync(cs => cs.CategoryServiceID == CategoryServiceId);

            return categoryService?.Parts.ToList() ?? new List<Parts>();
        }

        public async Task<CategoryService> AddEntity(CategoryService entity)
        {
            await _context.Set<CategoryService>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<CategoryService>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<CategoryService>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ErrorViewModel("Service category Not Found", $"Service category with Id {id} not found.");
            }
        }

        public async Task<ICollection<CategoryService>> GetAllEntity()
        {
            return await _context.Set<CategoryService>().ToListAsync<CategoryService>();
        }

        public async Task<CategoryService> GetOneEntity(int id)
        {
            return await _context
                .Set<CategoryService>()
                .Include("Service")
                .SingleAsync(w => w.CategoryServiceID == id);
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

            throw new ErrorViewModel("Service category Not Found", $"Service category with Id {id} not found.");
        }
    }
}