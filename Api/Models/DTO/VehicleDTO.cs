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
    public class VehicleDTO
    {    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int VehicleID { get; set; }
        [ForeignKey("CustomerID")]
        public int CustomerFK { get; set; }
        [ForeignKey("serviceID")]
        public int ServiceFK { get; set; }
        [Required]
        public int ChassisNumber { get; set; }  
        [Required]
        public int Year { get; set; }  
        public double Value { get; set; }
        [Required]
        public double Kilometrage { get; set; }
        [MaxLength(100)]        
        [Required]
        public string Model { get; set; } = string.Empty;
        [MaxLength(50)]   
        [Required]     
        public string Color { get; set; } = string.Empty; 
        [MaxLength(20)]   
        [Required]     
        public string SystemVersion { get; set; } = string.Empty;
    }
}
