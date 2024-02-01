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
    public class Parts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int PartID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Value { get; set; }
        [Required]
        public bool Availabity { get; set; }  
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        [Required]
        public string Location { get; set; } = string.Empty;
    }
}