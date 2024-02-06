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
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerFK { get; set; }

        [ForeignKey("Service")]
        public int ServiceFK { get; set; }

        [Required(ErrorMessage = "O valor total é obrigatório.")]
        public double Amount { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Service? Service { get; set; }
    }
}