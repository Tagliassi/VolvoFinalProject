using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace VolvoFinalProject
{
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int ContactsID { get; set; }
        public int AddressNumber { get; set; }  
        public string? Email { get; set; } = null!;
        [MaxLength(11)]
        [Required]
        public string? TelephoneNumber { get; set; } = null!;
        [MaxLength(100)]
        public string? Street { get; set; } = null!;
        [MaxLength(100)]
        public string? City { get; set; } = null!;
        [MaxLength(100)] 
        public string? Neighborhood { get; set; } = null!;
        [MaxLength(100)]
        public string? State { get; set; } = null!;
        [MaxLength(08)]
        [Required]
        public string? CEP { get; set; } = null!;
        public EnumTelephoneType Telephone { get; set; }     
    }
}
