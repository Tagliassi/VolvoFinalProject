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
        public int BillID { get; set; }
        public int CustomerFK { get; set; }
        public int ServiceFK { get; set; }
        [Required]
        public double Amount { get; set; } 
        [ForeignKey("CustomerFK")]
        public Customer? Customer { get; set; }
        [ForeignKey("ServiceFK")]
        public Service? Service { get; set; }
    }
}