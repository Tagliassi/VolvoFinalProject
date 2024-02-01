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
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int BillID { get; set; }
        [ForeignKey("CustomerID")]
        public int CustomerFK { get; set; }
        [ForeignKey("ServiceID")]
        public int ServiceFK { get; set; }
        [Required]
        public double Amount { get; set; } 
    }
}