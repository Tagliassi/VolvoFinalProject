using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace VolvoFinalProject
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
        public Role Role { get; set; } 
    }

    public enum Role
    {
        [Description("Recepcionista")]
        Receptionist = 1,
        [Description("Gerenciador de inventário")]
        InventoryManager = 2,
        [Description("Engenheiro mecânico")]
        MechanicalEngineer = 3
    }
}