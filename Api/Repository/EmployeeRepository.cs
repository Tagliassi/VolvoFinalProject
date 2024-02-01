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
    public class EmployeeRepository : IEmployeeRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public EmployeeRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Employee> AddEntity(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Employee>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEntity(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}