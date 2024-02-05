using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models.Enum;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class BillDTO
    {
        public int BillID { get; set; }
        public int CustomerFK { get; set; }
        public int ServiceFK { get; set; }
        [Required(ErrorMessage = "O valor total é obrigatório.")]
        public double Amount { get; set; }
    }
}