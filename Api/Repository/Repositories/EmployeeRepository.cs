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
    public class EmployeeRepository : IEmployeeRepository
    {
        private ProjectContext _context;

        public EmployeeRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetServicesByEmployee(int employeeId)
        {
            var service = await _context.Services
                .Where(s => s.EmployeeFK == employeeId)
                .ToListAsync();

            if (service != null){
                return service;
            }

            throw new ErrorViewModel("Employee Not Found", $"Employee with Id {employeeId} not found.");
        }

        public async Task<Employee> AddEntity(Employee entity)
        {
            await _context.Set<Employee>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Employee>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Employee>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Employee Not Found", $"Employee with Id {id} not found.");
        }

        public async Task<Employee> DeleteEntity(Employee employe)
        {
            var entity = await _context.Set<Employee>().FindAsync(employe);
            if (entity != null)
            {
                _context.Set<Employee>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Employee Not Found", $"Employee {employe} not found.");
        }

        public async Task<ICollection<Employee>> GetAllEntity()
        {
            var entities = await _context.Set<Employee>().ToListAsync<Employee>();
            return entities;
        }

        public async Task<Employee> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Employee>()
                .Include("Contact")
                .Include("Dealer")
                .Include("Service")
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