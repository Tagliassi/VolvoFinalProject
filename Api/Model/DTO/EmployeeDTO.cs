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
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public int DealerFK { get; set; }
        public int ContactFK { get; set; }
        public double Salary { get; set; }
        public double BaseSalary { get; set; }
        public double Commission { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public EnumEmployees Employees { get; set; }
    }
}