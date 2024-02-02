using VolvoFinalProject;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Model.Models;


namespace VolvoFinalProject.Api.DTOService.Interfaces
{
    public interface IEmployeeService : IBaseService<EmployeeDTO>
    {
        Task<double> CalculateSalary(Employee employee, Service service);
    }
}