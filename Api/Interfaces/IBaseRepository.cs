using VolvoFinalProject;

namespace VolvoFinalProject.Api.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllEntity();
        Task<T> GetOneEntity(int id);
        Task<T> AddEntity(T entity);
        Task<T> UpdateEntity(int id, T entity);
        Task DeleteEntity(int id);
    }
}