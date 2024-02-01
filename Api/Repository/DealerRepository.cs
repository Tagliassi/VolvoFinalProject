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
    public class DealerRepository : IDealerRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public DealerRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Dealer> AddEntity(Dealer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Dealer>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Dealer> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Dealer> UpdateEntity(int id, Dealer entity)
        {
            throw new NotImplementedException();
        }
    }
}