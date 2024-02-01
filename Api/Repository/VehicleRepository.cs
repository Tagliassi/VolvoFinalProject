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
    public class VehicleRepository : IVehicleRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public VehicleRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Vehicle> AddEntity(Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Vehicle>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Vehicle> UpdateEntity(int id, Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}