using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;
using Serilog;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly ProjectContext _context;

        public BillRepository(ProjectContext context)
        {
            _context = context;
        }

        // Add a new Bill entity to the database
        public async Task<Bill> AddEntity(Bill entity)
        {
            await _context.Set<Bill>().AddAsync(entity);
            await _context.SaveChangesAsync();  
            return entity;
        }

        // Delete a Bill entity from the database based on its ID
        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Bill>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Bill>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Retrieve all Bill entities from the database
        public async Task<ICollection<Bill>> GetAllEntity()
        {
            var entities = await _context.Set<Bill>().ToListAsync<Bill>();
            return entities;
        }

        // Retrieve a specific Bill entity from the database based on its ID
        public async Task<Bill> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Bill>()
                .Include("Customers")
                .Include("Services")
                .SingleAsync(w => w.BillID == id);

            if (entity != null)
            {
                return entity;
            }

            // Throw an exception if the Bill entity with the specified ID is not found
            throw new ErrorViewModel("Bill Not Found", $"Bill with Id {id} not found.");
        }

        // Update a Bill entity in the database based on its ID
        public async Task<Bill> UpdateEntity(int id, Bill entity)
        {
            var oldEntity = await _context.Set<Bill>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Bill>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync(); 
                return entity;
            }

            // Throw an exception if the Bill entity with the specified ID is not found
            throw new ErrorViewModel("Bill Not Found", $"Bill with Id {id} not found.");
        }
        
        public async Task<IEnumerable<Service>> GetServicesOfBill(int serviceFKid)
        {
            var services = await _context.Services
                .Where(s => s.ServiceID == serviceFKid)
                .ToListAsync();

            return services;
        }
    }
}