using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Model.DTO
{
    // Classe que representa um DTO (Data Transfer Object) para a entidade Dealer
    public class DealerDTO 
    {
        public int DealerID { get; set; }
        public int ContactFK { get; set; }
        public string CNPJ { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Contacts? Contacts { get; set; }
    }
}