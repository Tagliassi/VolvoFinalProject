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
    public class Dealer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DealerID { get; set; }
        [ForeignKey("ContactsID")] 
        public int? ContactFK { get; set; }
        [ForeignKey("ServiceID")]  
        public int? ServiceFK { get; set; }
        [ForeignKey("EmployeeID")] 
        public int? EmployeeFK { get; set; }
        [ForeignKey("CustomerID")] 
        public int? CustomerFK { get; set; }   
        [MaxLength(18)]
        [Required]
        public string CNPJ { get; set; } = string.Empty;
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}