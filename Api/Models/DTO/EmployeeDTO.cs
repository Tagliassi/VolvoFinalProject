using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.RepositoryInterfaces;
using VolvoFinalProject.Api.Models.Enum;

namespace VolvoFinalProject.Api.Models.DTO
{
    public class EmployeeDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int EmployeeID { get; set; }
        [ForeignKey("DealerID")] 
        public int DealerFK { get; set; }
        [ForeignKey("ContactID")] 
        public int ContactFK { get; set; }
        public float Salary { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        [Required]
        public EnumEmployees Employees { get; set; } 
    }
}