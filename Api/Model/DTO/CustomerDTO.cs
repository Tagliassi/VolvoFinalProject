using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class CustomerDTO 
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
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        [Required (ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(18, ErrorMessage = "O valor máximo para o CPF é de 18 caracteres.")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF { get; set; } = string.Empty;
    }
}