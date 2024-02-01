using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.RepositoryInterfaces;

namespace VolvoFinalProject.Api.Models.DTO
{
    public class CustomerDTO 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
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
    }
}