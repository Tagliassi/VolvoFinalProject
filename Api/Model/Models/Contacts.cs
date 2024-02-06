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
    public class Contacts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactsID { get; set; }

        [Required(ErrorMessage = "O número do endereço é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número do endereço deve ser maior que zero.")]
        public int AddressNumber { get; set; }

        [EmailAddress(ErrorMessage = "O email fornecido não é válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [RegularExpression(@"^\d{8,11}$", ErrorMessage = "O número de telefone deve conter entre 8 e 11 dígitos.")]
        public string TelephoneNumber { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "O valor máximo para a rua é de 100 caracteres.")]
        public string Street { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "O valor máximo para a cidade é de 100 caracteres.")]
        public string City { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "O valor máximo para o bairro é de 100 caracteres.")]
        public string Neighborhood { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "O valor máximo para o estado é de 100 caracteres.")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "O CEP deve conter exatamente 8 dígitos.")]
        public string CEP { get; set; } = string.Empty;

        public EnumTelephoneType TelephoneType { get; set; }
    }
}