using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class VehicleDTO
    {    
        public int VehicleID { get; set; }
        public int CustomerFK { get; set; }
        public int ChassisNumber { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }
        public double Kilometrage { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string SystemVersion { get; set; } = string.Empty;
    }
}
