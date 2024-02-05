using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models.Enum;

namespace VolvoFinalProject.Api.Model.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public int DealerFK { get; set; }
        public int ServiceFK { get; set; }
        public int ContactFK { get; set; }
        public double Salary { get; set; }
        [Required]
        public double BaseSalary { get; set; }
        public double Commission { get; set; }
        [MaxLength(11, ErrorMessage = "O valor máximo para o CPF é de 11 caracteres.")]
        public string CPF { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tipo do funcionário é obrigatório.")]
        public EnumEmployees Employees { get; set; } 
        [ForeignKey("DealerFK")] 
        public Dealer? Dealer { get; set; }
        [ForeignKey("ServiceFK")]  
        public Service? Service { get; set; }
        [ForeignKey("ContactFK")] 
        public Contacts? Contacts { get; set; }

        public ICollection<Dealer>? Dealers { get; set; }
    }
}