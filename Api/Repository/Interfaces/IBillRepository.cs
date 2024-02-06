using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Interfaces
{
    public interface IBillRepository : IBaseRepository<Bill>
    {
        Task<IEnumerable<Service>> GetServicesOfBill(int serviceFKid);
    }
}