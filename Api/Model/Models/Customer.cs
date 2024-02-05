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
        public int ServiceFK { get; set; }
        public int BillFK { get; set; }
        public int ContactFK { get; set; }
        public int VehicleFK { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(18)]
        [Required]
        public string CPF { get; set; } = string.Empty;
        [ForeignKey("ServiceFK")]
        public Service? Service { get; set; }
        [ForeignKey("BillFK")]
        public Bill? Bill { get; set; }
        [ForeignKey("ContactFK")]
        public Contacts? Contacts { get; set; }
        [ForeignKey("VehicleFK")]
        public Vehicle? Vehicle { get; set; }
        
        public ICollection<Bill>? Bills { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
