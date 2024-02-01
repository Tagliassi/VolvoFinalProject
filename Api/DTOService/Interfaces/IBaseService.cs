using VolvoFinalProject;

namespace VolvoFinalProject.Api.DTOService.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<ICollection<T>> GetAllEntity();
        Task<T> GetOneEntity(int id);
        Task<T> AddEntity(T entity);
        Task<T> UpdateEntity(int id, T entity);
        Task DeleteEntity(int id);
    }
}