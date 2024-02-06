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
        public int PartID { get; set; }

        [ForeignKey("CategoryService")]
        public int CategoryServiceFK { get; set; }

        [Required(ErrorMessage = "A quantidade de peças é obrigatória.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O valor do peça é obrigatório.")]
        public float Value { get; set; }

        [Required(ErrorMessage = "A disponibilidade da peça é obrigatória.")]
        public string Availabity { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome da peça é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome da peça é de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A localização da peça é obrigatória.")]
        [MaxLength(50, ErrorMessage = "O valor máximo para a localização da peça é de 50 caracteres.")]
        public string Location { get; set; } = string.Empty;

        public virtual CategoryService? CategoryService { get; set; }
    }
}