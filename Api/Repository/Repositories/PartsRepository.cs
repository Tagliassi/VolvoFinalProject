using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Exceptions;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class PartsRepository : IPartsRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public PartsRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Parts> AddEntity(Parts entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Parts>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Parts> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Parts> UpdateEntity(int id, Parts entity)
        {
            throw new NotImplementedException();
        }
    }
}