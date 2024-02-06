using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        [ForeignKey("Contact")]
        public int ContactFK { get; set; }

        [ForeignKey("Dealer")]
        public int DealerFK { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O valor máximo para o nome é de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [MaxLength(18, ErrorMessage = "O valor máximo para o CPF é de 18 caracteres.")]
        public string CPF { get; set; } = string.Empty;

        public virtual Contacts? Contacts { get; set; }
        public virtual Dealer? Dealer { get; set; }
    }
}
