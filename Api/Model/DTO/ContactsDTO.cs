using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models.Enum;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class ContactsDTO
    {
        public int ContactsID { get; set; }
        public int AddressNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public EnumTelephoneType TelephoneType { get; set; }   
    }
}