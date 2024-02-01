using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.RepositoryInterfaces;
using VolvoFinalProject.Api.Models;
using VolvoFinalProject.Exceptions;

namespace VolvoFinalProject.Api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public CustomerRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Customer> AddEntity(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Customer>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateEntity(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}