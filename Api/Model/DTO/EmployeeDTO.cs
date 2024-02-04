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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        [ForeignKey("DealerID")] 
        public int DealerFK { get; set; }
        [ForeignKey("ContactID")] 
        public int ContactFK { get; set; }
        public float Salary { get; set; }
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tipo do funcionário é obrigatório.")]
        public EnumEmployees Employees { get; set; } 
    }
}