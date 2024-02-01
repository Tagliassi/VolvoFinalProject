using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Interfaces;
using VolvoFinalProject.Api.Models.Enum;

namespace VolvoFinalProject.Api.Models.DTO
{
    public class ServiceDTO : IDTO<Service>
    {
        public int ServiceID { get; set; }
        public int PartFK { get; set; }
        public int EmployeeFK { get; set; }
        public int CostumerFK { get; set; }
        public int VehicleFK { get; set; }
        public int CategoryServiceFK { get; set; }
        public DateTime? Date { get; set; }
        public EnumSituation Services { get; set; }

        public ServiceDTO() { }

        public ServiceDTO(Service service)
        {
            ServiceID = service.ServiceID;
            PartFK = service.PartFK;
            EmployeeFK = service.EmployeeFK;
            CostumerFK = service.CostumerFK;
            VehicleFK = service.VehicleFK;
            CategoryServiceFK = service.CategoryServiceFK;
            Date = service.Date;
            Services = service.Services;
        }

        public Service CreateEntity()
        {
            return new Service
            {
                // Mapeamento inverso das propriedades
                PartFK = this.PartFK,
                EmployeeFK = this.EmployeeFK,
                CostumerFK = this.CostumerFK,
                VehicleFK = this.VehicleFK,
                CategoryServiceFK = this.CategoryServiceFK,
                Date = this.Date,
                Services = this.Services
            };
        }
    }
}