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
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleID { get; set; }        
        public int CustomerFK { get; set; }       
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
        [ForeignKey("CustomerFK")]
        public Customer? Customer { get; set; }
        [ForeignKey("ServiceFK")]
        public Service? Service { get; set; }
        public ICollection<Customer>? Customers { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}