using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ProjectContext _context;
        public CustomerRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetServicesByCustomer(int customerId)
        {
            var services = await _context.Services
                .Where(s => s.CustomerFK == customerId)
                .ToListAsync();

            if (services.Any())
            {
                return services;
            }

            throw new ErrorViewModel("Customer Not Found", $"Customer with Id {customerId} not found or has no services.");
        }

        public async Task<Customer> AddEntity(Customer entity)
        {
            await _context.Set<Customer>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Customer>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Customer>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Customer Not Found", $"Customer with Id {id} not found.");
        }

        public async Task<ICollection<Customer>> GetAllEntity()
        {
            return await _context.Set<Customer>().ToListAsync<Customer>();
        }

        public async Task<Customer> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Customer>()  
                .Include("Service")
                .Include("Bill")
                .Include("Contact")
                .Include("Vehicle")     
                .SingleAsync(w => w.CustomerID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Customer Not Found", $"Customer with Id {id} not found.");
        }

        public async Task<Customer> UpdateEntity(int id, Customer entity)
        {
            var oldEntity = await _context.Set<Customer>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Customer>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Customer Not Found", $"Customer with Id {id} not found.");
        }
    }
}