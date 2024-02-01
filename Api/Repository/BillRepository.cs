using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Interfaces;
using VolvoFinalProject.Api.Models;
using VolvoFinalProject.Exceptions;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Repository
{
    public class BillRepository : IBillRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public BillRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Bill> AddEntity(Bill entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Bill>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Bill> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Bill> UpdateEntity(int id, Bill entity)
        {
            throw new NotImplementedException();
        }
    }
}