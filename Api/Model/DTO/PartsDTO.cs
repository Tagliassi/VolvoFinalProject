using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Repository.Interfaces;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class PartsDTO
    {
        public int PartID { get; set; }        
        public int Quantity { get; set; }        
        public float Value { get; set; }        
        public bool Availabity { get; set; }          
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}