using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VolvoFinalProject;
using VolvoFinalProject.Api.Models.Enum;

namespace VolvoFinalProject.Api.Models
{
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int ContactsID { get; set; }
        public int AddressNumber { get; set; }  
        public string Email { get; set; } = null!;
        [MaxLength(11)]
        [Required]
        public string TelephoneNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Street { get; set; } = string.Empty;
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;
        [MaxLength(100)] 
        public string Neighborhood { get; set; } = string.Empty;
        [MaxLength(100)]
        public string State { get; set; } = string.Empty;
        [MaxLength(08)]
        [Required]
        public string CEP { get; set; } = string.Empty;
        public EnumTelephoneType Telephone { get; set; }     
    }
}