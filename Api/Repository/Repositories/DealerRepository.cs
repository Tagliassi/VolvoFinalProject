using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class DealerRepository : IDealerRepository
    {
        private ProjectContext _context;
        public DealerRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Employee>> GetEmployeesByDealer(int dealerId)
        {
            var employees = await _context.Employees
                .Where(e => e.DealerFK == dealerId)
                .ToListAsync();

            return employees;
        }

        public async Task<Dealer> AddEntity(Dealer entity)
        {
            await _context.Set<Dealer>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Dealer>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Dealer>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Dealer>> GetAllEntity()
        {
            return await _context.Set<Dealer>().ToListAsync<Dealer>();
        }

        public async Task<Dealer> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Dealer>()
                .Include("Contacts")
                .SingleAsync(w => w.DealerID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Dealer Not Found", $"Dealer with Id {id} not found.");
        }

        public async Task<Dealer> UpdateEntity(int id, Dealer entity)
        {
            var oldEntity = await _context.Set<Dealer>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Dealer>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Dealer Not Found", $"Dealer with Id {id} not found.");
        }
    }
}