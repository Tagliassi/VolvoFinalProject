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