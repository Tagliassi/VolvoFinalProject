using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VolvoFinalProject
{
    public class Dealer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int DealerID { get; set; }
        [ForeignKey("ContactsID")] 
        public int ContactFK { get; set; }
        [ForeignKey("ServiceID")]  
        public int ServiceFK { get; set; }
        [ForeignKey("EmployeeID")] 
        public int EmployeeFK { get; set; }
        [ForeignKey("CostumerID")] 
        public int CostumerFK { get; set; }   
        [MaxLength(18)]
        [Required]
        public string? CNPJ { get; set; } = null!;
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; } = null!; 
    }
}