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
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int ServiceID { get; set; }
        [ForeignKey("PartID")]
        public int PartFK { get; set; }
        [ForeignKey("EmployeeID")]
        public int EmployeeFK { get; set; }
        [ForeignKey("CustomerID")]
        public int CustomerFK { get; set; }
        [ForeignKey("VehicleID")]
        public int VehicleFK { get; set; }
        [ForeignKey("CategoryServiceID")]
        public int CategoryServiceFK { get; set; }        
        public DateTime? Date { get; set; }
        public EnumSituation Situation { get; set; } 
    }
}