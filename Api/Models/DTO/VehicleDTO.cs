using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Interfaces;

namespace VolvoFinalProject.Api.Models.DTO
{
    public class VehicleDTO : IDTO<VehicleDTO>
    {
        public VehicleDTO CreateEntity()
        {
            throw new NotImplementedException();
        }
    }
}