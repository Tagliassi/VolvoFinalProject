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
            var employee = await _context.Employees
                .Where(e => e.DealerFK == dealerId)
                .ToListAsync();

            if (employee != null){
                return employee;
            }

            throw new ErrorViewModel("Employee Not Found", $"Employee not found at DealerID {dealerId}");
        }
        
        public async Task<Dealer> AddEntity(Dealer entity)
        {
            await _context.Set<Dealer>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Dealer>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Dealer>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Dealer Not Found", $"Dealer with Id {id} not found.");
        }

        public async Task<ICollection<Dealer>> GetAllEntity()
        {
            var entities = await _context.Set<Dealer>().ToListAsync<Dealer>();
            return entities;
        }

        public async Task<Dealer> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Dealer>()  
                .Include("Contact")
                .Include("Service")
                .Include("Employee")
                .Include("Customer")     
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