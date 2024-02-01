using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VolvoFinalProject;
using VolvoFinalProject.Api.Models.Enum;

namespace VolvoFinalProject.Api.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int EmployeeID { get; set; }
        [ForeignKey("DealerID")] 
        public int DealerFK { get; set; }
        [ForeignKey("ServiceID")]  
        public int ServiceFK { get; set; }
        [ForeignKey("ContactID")] 
        public int ContactFK { get; set; }
        public float Salary { get; set; }
        [Required]
        public float BaseSalary { get; set; }
        public float Commission { get; set; }
        [MaxLength(11)]
        [Required]
        public string? CPF { get; set; } = null!;
        [MaxLength(100)]
        public string? Name { get; set; } = null!;
        [MaxLength(50)]
        [Required]
        public EnumEmployees Employees { get; set; } 
    }
}