using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models.Enum;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class ServiceDTO
    {
        public int ServiceID { get; set; }
        public int PartFK { get; set; }
        public int EmployeeFK { get; set; }
        public int CustomerFK { get; set; }
        public int VehicleFK { get; set; }
        public int CategoryServiceFK { get; set; } 
        public double Value { get; set; } 
        public DateTime? Date { get; set; }
        public EnumSituation Situation { get; set; } 
    }
}