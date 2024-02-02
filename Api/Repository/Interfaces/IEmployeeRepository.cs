using VolvoFinalProject;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<IEnumerable<Service>> GetServicesByEmployee(int employeeId);
    }
}