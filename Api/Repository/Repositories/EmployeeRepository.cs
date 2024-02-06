using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ProjectContext _context;

        public EmployeeRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetServicesByEmployee(int employeeId)
        {
            var services = await _context.Services
                .Where(s => s.EmployeeFK == employeeId)
                .ToListAsync();

            return services;
        }

        public async Task<Employee> AddEntity(Employee entity)
        {
            await _context.Set<Employee>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Employee>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Employee>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Employee>> GetAllEntity()
        {
            return await _context.Set<Employee>().ToListAsync<Employee>();
        }

        public async Task<Employee> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Employee>()
                .Include("Contact")
                .Include("Dealers")
                .SingleAsync(w => w.EmployeeID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Employee Not Found", $"Employee with Id {id} not found.");
        }

        public async Task<Employee> UpdateEntity(int id, Employee entity)
        {
            var oldEntity = await _context.Set<Employee>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Employee>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Employee Not Found", $"Employee with Id {id} not found.");
        }
    }
}