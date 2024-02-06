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

        [ForeignKey("Contact")]
        public int ContactFK { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [MaxLength(18, ErrorMessage = "O valor máximo para o CNPJ é de 18 caracteres.")]
        public string CNPJ { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual Contacts? Contacts { get; set; }
    }
}