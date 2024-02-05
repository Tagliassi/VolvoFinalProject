using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class CustomerDTO 
    {
        public int CustomerID { get; set; }
        public int ServiceFK { get; set; }
        public int BillFK { get; set; }
        public int ContactFK { get; set; }
        public int VehicleFK { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
    }
}