using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Model.Models;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class CustomerDTO 
    {
        public int CustomerID { get; set; }
        public int ContactFK { get; set; }    
        public int DealerFK { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public virtual Contacts? Contacts { get; set; }
        public virtual Dealer? Dealer { get; set; }
    }
}