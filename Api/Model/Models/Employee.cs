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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [ForeignKey("Dealer")]
        public int DealerFK { get; set; }

        [ForeignKey("Contact")]
        public int ContactFK { get; set; }

        public double Salary { get; set; }

        [Required(ErrorMessage = "O salário base é obrigatório.")]
        public double BaseSalary { get; set; }

        public double Commission { get; set; }

        [MaxLength(11, ErrorMessage = "O valor máximo para o CPF é de 11 caracteres.")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O tipo do funcionário é obrigatório.")]
        public EnumEmployees Employees { get; set; }

        [JsonIgnore]
        public virtual Dealer? Dealer { get; set; }
        
        [JsonIgnore]
        public virtual Contacts? Contacts { get; set; }
    }
}