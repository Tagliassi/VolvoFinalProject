using VolvoFinalProject;
using VolvoFinalProject.Api.Model.DTO;


namespace VolvoFinalProject.Api.DTOService.Interfaces
{
    public interface IEmployeeService : IBaseService<EmployeeDTO>
    {
        Task<ICollection<EmployeeDTO>> GetAllEntity();
        Task<EmployeeDTO> GetOneEntity(int id);
        Task<EmployeeDTO> AddEntity(EmployeeDTO entity);
        Task<EmployeeDTO> UpdateEntity(int id, EmployeeDTO entity);
        Task DeleteEntity(EmployeeDTO entity);
    }
}