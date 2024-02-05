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
        public int DealerID { get; set; }
        public int? ContactFK { get; set; }
        public int? ServiceFK { get; set; }
        public int? EmployeeFK { get; set; }
        public int? CustomerFK { get; set; }   
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
    }
}