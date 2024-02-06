using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models.Enum;

namespace VolvoFinalProject.Api.Model.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }

        [ForeignKey("Dealer")]
        public int DealerFK { get; set; }

        [ForeignKey("Employees")]
        public int EmployeeFK { get; set; }

        [Required(ErrorMessage = "O valor do serviço é obrigatório.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "A data do serviço é obrigatória.")]
        public DateTime Date { get; set; }

        public EnumSituation Situation { get; set; }

        public virtual Dealer? Dealer { get; set; }
    }
}