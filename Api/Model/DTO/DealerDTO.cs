using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Model.DTO
{
    // Classe que representa um DTO (Data Transfer Object) para a entidade Dealer
    public class DealerDTO 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int DealerID { get; set; }
        [ForeignKey("ContactsID")] 
        public int? ContactFK { get; set; }
        [ForeignKey("ServiceID")]  
        public int? ServiceFK { get; set; }
        [ForeignKey("EmployeeID")] 
        public int? EmployeeFK { get; set; }
        [ForeignKey("CustomerID")] 
        public int? CustomerFK { get; set; }   
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
    }
}