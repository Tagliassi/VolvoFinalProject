using VolvoFinalProject;
using VolvoFinalProject.Api.Model.DTO;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.DTOService.Interfaces
{
    public interface IBillService : IBaseService<BillDTO>
    {
        Task<double> CalculateBill(Bill bill);
    }
}