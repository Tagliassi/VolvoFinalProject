using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolvoFinalProject.Api.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public void Commit();
        public void RollBack();
    }
}