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
    public class ContactsRepository : IContactsRepository
    {
        private ProjectContext context;
        private bool disposed = false;

        public ContactsRepository(ProjectContext _context)
        {
            this.context = _context;
        }

        public Task<Contacts> AddEntity(Contacts entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Contacts>> GetAllEntity()
        {
            throw new NotImplementedException();
        }

        public Task<Contacts> GetOneEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Contacts> UpdateEntity(int id, Contacts entity)
        {
            throw new NotImplementedException();
        }
    }
}