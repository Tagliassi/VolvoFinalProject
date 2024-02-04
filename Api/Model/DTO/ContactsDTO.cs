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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactsID { get; set; }
        public int AddressNumber { get; set; }  
        [MaxLength(11, ErrorMessage = "O valor máximo para o telefone é de 11 caracteres.")]
        [Required]
        public string TelephoneNumber { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "O valor máximo para a rua é de 100 caracteres.")]
        public string Street { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "O valor máximo para a cidade é de 100 caracteres.")]
        public string City { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "O valor máximo para o bairro é de 100 caracteres.")] 
        public string Neighborhood { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "O valor máximo para o estado é de 100 caracteres.")]
        public string State { get; set; } = string.Empty;
        [MaxLength(08, ErrorMessage = "O valor máximo para o CEP é de 08 caracteres.")]
        [Required]
        public string CEP { get; set; } = string.Empty;
        public EnumTelephoneType Telephone { get; set; }    
    }
}