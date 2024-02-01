using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.RepositoryInterfaces;
using VolvoFinalProject.Api.Models;
using VolvoFinalProject.Exceptions;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Repository
{
    public class BillRepository : IBillRepository
    {
        private readonly ProjectContext _context;
        private bool disposed = false;

        public BillRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Bill> AddEntity(Bill bill)
        {
            await _context.Set<Bill>().AddAsync(bill);
            return bill; 
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