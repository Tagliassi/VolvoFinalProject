using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly ProjectContext _context;

        public BillRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Bill> AddEntity(Bill entity)
        {
            await _context.Set<Bill>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Bill>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Bill>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Employee Not Found", $"Bill with Id {id} not found.");
        }

        public async Task<ICollection<Bill>> GetAllEntity()
        {
            var entities = await _context.Set<Bill>().ToListAsync<Bill>();
            return entities;
        }

        public async Task<Bill> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Bill>()
                .Include("Customer")
                .Include("Service")
                .SingleAsync(w => w.BillID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Bill Not Found", $"Bill with Id {id} not found.");
        }

        public async Task<Bill> UpdateEntity(int id, Bill entity)
        {
            var oldEntity = await _context.Set<Bill>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Bill>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Bill Not Found", $"Bill with Id {id} not found.");
        }
    }
}