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
    public class ServiceRepository : IServiceRepository
    {
        private ProjectContext _context;
        public ServiceRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Service> AddEntity(Service entity)
        {
            await _context.Set<Service>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Service>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Service>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Service Not Found", $"Service with Id {id} not found.");
        }

        public async Task<ICollection<Service>> GetAllEntity()
        {
            var entities = await _context.Set<Service>().ToListAsync<Service>();
            return entities;
        }

        public async Task<Service> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Service>()
                .Include("Parts")
                .Include("Employee")
                .Include("Customer")
                .Include("Vehicle")
                .Include("CategoryService")
                .SingleAsync(w => w.ServiceID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Service Not Found", $"Service with Id {id} not found.");
        }

        public async Task<Service> UpdateEntity(int id, Service entity)
        {
            var oldEntity = await _context.Set<Service>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Service>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Service Not Found", $"Service with Id {id} not found.");
        } 
    }
}