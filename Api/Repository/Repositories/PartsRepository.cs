using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class PartsRepository : IPartsRepository
    {
        private ProjectContext _context;

        public PartsRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Parts> AddEntity(Parts entity)
        {
            await _context.Set<Parts>().AddAsync(entity);
            //await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Parts>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Parts>().Remove(entity);
                //await _context.SaveChangesAsync();
            }

            throw new ErrorViewModel("Part Not Found", $"Part with Id {id} not found.");
        }

        public async Task<ICollection<Parts>> GetAllEntity()
        {
            var entities = await _context.Set<Parts>().ToListAsync<Parts>();
            return entities;
        }

        public async Task<Parts> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Parts>()         
                .SingleAsync(w => w.PartID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Part Not Found", $"Part with Id {id} not found.");
        }

        public async Task<Parts> UpdateEntity(int id, Parts entity)
        {
            var oldEntity = await _context.Set<Parts>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Parts>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Part Not Found", $"Part with Id {id} not found.");
        } 
    }
}