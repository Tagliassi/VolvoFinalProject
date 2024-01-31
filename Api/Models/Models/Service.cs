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
        [ForeignKey("CostumerID")]
        public int CostumerFK { get; set; }
        [ForeignKey("VehicleID")]
        public int VehicleFK { get; set; }
        [ForeignKey("CategoryServiceID")]
        public int CategoryServiceFK { get; set; }        
        public DateTime? Date { get; set; }
    }

    public enum Situation
    {
        [Description("Concluído")]
        Done = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Cancelado")]
        Canceled = 3
    }
}