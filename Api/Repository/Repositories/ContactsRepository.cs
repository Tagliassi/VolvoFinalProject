using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private ProjectContext _context;

        public ContactsRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Contacts> AddEntity(Contacts entity)
        {
            await _context.Set<Contacts>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteEntity(int id)
        {
            var entity = await _context.Set<Contacts>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<Contacts>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Contacts>> GetAllEntity()
        {
            return await _context.Set<Contacts>().ToListAsync<Contacts>();
        }

        public async Task<Contacts> GetOneEntity(int id)
        {
            var entity = await _context
                .Set<Contacts>()
                .SingleAsync(w => w.ContactsID == id);

            if (entity != null)
            {
                return entity;
            }

            throw new ErrorViewModel("Contact Not Found", $"Contact with Id {id} not found.");
        }

        public async Task<Contacts> UpdateEntity(int id, Contacts entity)
        {
            var oldEntity = await _context.Set<Contacts>().FindAsync(id);
            if (oldEntity != null)
            {
                _context.Entry<Contacts>(oldEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            throw new ErrorViewModel("Contact Not Found", $"Contact with Id {id} not found.");
        }
    }
}