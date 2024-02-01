using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Repository.Interfaces
{
    public interface ICategoryServiceRepository : IBaseRepository<CategoryService>
    {
        Task<ICollection<Parts>> GetPartsByCategoryService(int CategoryServiceId);
    }
}