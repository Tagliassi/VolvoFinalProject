using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models
{
    public class Dealer
    {
        [Key]
        public int DealerID { get; set; }
        public int ContactFK { get; set; }
        public int ServiceFK { get; set; }
        public int EmployeeFK { get; set; }
        public int CustomerFK { get; set; }   
        [MaxLength(18, ErrorMessage = "O valor máximo para o CNPJ é de 18 caracteres.")]
        public string CNPJ { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
        [ForeignKey("ContactFK")] 
        public Contacts? Contacts { get; set; }
        [ForeignKey("ServiceFK")]  
        public Service? Service { get; set; }
        [ForeignKey("EmployeeFK")] 
        public Employee? Employee { get; set; }
        [ForeignKey("CustomerFK")]   
        public Customer? Customer { get; set; } 
        public ICollection<Employee>? Employees { get; set; }
    }
}