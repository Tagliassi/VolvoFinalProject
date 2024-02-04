using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [ForeignKey("ServiceID")]
        public int ServiceFK { get; set; }
        [ForeignKey("BillID")]
        public int BillFK { get; set; }
        [ForeignKey("ContactID")]
        public int ContactFK { get; set; }
        [ForeignKey("VehicleID")]
        public int VehicleFK { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(18)]
        [Required]
        public string CPF { get; set; } = string.Empty;
    }
}