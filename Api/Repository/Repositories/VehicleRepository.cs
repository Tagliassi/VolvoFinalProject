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
    public class VehicleRepository : IVehicleRepository
    {
        private ProjectContext _context;

        public async Task<ICollection<Vehicle>> GetVehicleByKmAndSystemVersion(int km, string systemVersion)
        {
            var vehicle = await _context.Vehicles
                .Where(v => v.Kilometrage == km && v.SystemVersion == systemVersion )
                .ToListAsync();

            if (vehicle != null){
                return vehicle;
            }

            throw new ErrorViewModel("Vehicle Not Found", $"Vehicle with km {km} System Version {systemVersion} not found.");
        }

        public VehicleRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> AddEntity(Vehicle entity)
        {
            await _context.Set<Vehicle>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Vehicle>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Vehicle>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Vehicle Not Found", $"Vehicle with Id {id} not found.");
        }

        public async Task<ICollection<Vehicle>> GetAllEntity()
        {
            var entities = await _context.Set<Vehicle>().ToListAsync<Vehicle>();
            return entities;
        }

        public async Task<Vehicle> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Vehicle>()
                .Include("Customer")
                .Include("Service")
                .SingleAsync(w => w.VehicleID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Vehicle Not Found", $"Vehicle with Id {id} not found.");
        }

        public async Task<Vehicle> UpdateEntity(int id, Vehicle entity)
        {
            var oldEntity = await _context.Set<Vehicle>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Vehicle>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Vehicle Not Found", $"Vehicle with Id {id} not found.");
        }
    }
}