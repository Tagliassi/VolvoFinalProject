using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Interfaces
{
    public interface IDealerRepository : IBaseRepository<Dealer>
    {
        Task<ICollection<Employee>> GetEmployeesByDealer(int dealerId);
    }
}