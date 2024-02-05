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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DealerID { get; set; }
        public int ContactFK { get; set; }
        public int ServiceFK { get; set; }
        public int EmployeeFK { get; set; }
        public int CustomerFK { get; set; }   
        [MaxLength(18)]
        [Required]
        public string CNPJ { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
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