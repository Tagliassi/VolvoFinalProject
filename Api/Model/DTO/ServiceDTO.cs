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
    public class ServiceDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int ServiceID { get; set; }
        [ForeignKey("PartID")]
        public int PartFK { get; set; }
        [ForeignKey("EmployeeID")]
        public int EmployeeFK { get; set; }
        [ForeignKey("CostumerID")]
        public int CostumerFK { get; set; }
        [ForeignKey("VehicleID")]
        public int VehicleFK { get; set; }
        [ForeignKey("CategoryServiceID")]
        public int CategoryServiceFK { get; set; }        
        [Required(ErrorMessage = "A data do serviço é obrigatória.")]
        public DateTime? Date { get; set; }
        public EnumSituation Services { get; set; } 
    }
}