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
    public class ServiceRepository : IServiceRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public ServiceRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Service> AddEntity(Service entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Service>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Service> UpdateEntity(int id, Service entity)
        {
            throw new NotImplementedException();
        }
    }
}