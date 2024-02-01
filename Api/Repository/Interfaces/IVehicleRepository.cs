using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Task<ICollection<Vehicle>> GetVehicleByKmAndSystemVersion(int km, string systemVersion);
    }
}