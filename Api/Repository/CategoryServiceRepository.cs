using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Interfaces;
using VolvoFinalProject.Api.Models;
using VolvoFinalProject.Exceptions;

namespace VolvoFinalProject.Api.Repository
{
    public class CategoryServiceRepository : ICategoryServiceRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public CategoryServiceRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<CategoryService> AddEntity(CategoryService entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CategoryService>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryService> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryService> UpdateEntity(int id, CategoryService entity)
        {
            throw new NotImplementedException();
        }
    }
}