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
        public int PartID { get; set; }
        [Required(ErrorMessage = "A quantidade de peças é obrigatória.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "O valor do peça é obrigatório.")]
        public float Value { get; set; }
       [Required(ErrorMessage = "A disponibilidade da peça é obrigatória.")]
        public bool Availabity { get; set; }  
        [MaxLength(100, ErrorMessage = " valor máximo para o nome da peça é de 100 caracteres.")]
        [Required(ErrorMessage = "O nome da peça é obrigatório.")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50, ErrorMessage = " valor máximo para a localização da peça é de 50 caracteres.")]
        [Required(ErrorMessage = "A localização da peça é obrigatória.")]
        public string Location { get; set; } = string.Empty;
    }
}