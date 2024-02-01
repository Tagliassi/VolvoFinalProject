using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.RepositoryInterfaces;
using VolvoFinalProject.Api.Models.Enum;
namespace VolvoFinalProject.Api.Models.DTO
{
    public class BillDTO
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