using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models.Enum;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public int DealerFK { get; set; }
        public int ContactFK { get; set; }
        public float Salary { get; set; }
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tipo do funcionário é obrigatório.")]
        public EnumEmployees Employees { get; set; } 
    }
}