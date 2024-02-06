using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerFK { get; set; }

        [Required(ErrorMessage = "O número do chassi é obrigatório.")]
        public int ChassisNumber { get; set; }

        [Required(ErrorMessage = "O ano do veículo é obrigatório.")]
        public int Year { get; set; }

        public double Value { get; set; }

        [Required(ErrorMessage = "A quilometragem do veículo é obrigatória.")]
        public double Kilometrage { get; set; }

        [Required(ErrorMessage = "O modelo do veículo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O valor máximo para o modelo é de 100 caracteres.")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cor do veículo é obrigatória.")]
        [MaxLength(50, ErrorMessage = "O valor máximo para a cor é de 50 caracteres.")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "A versão do sistema é obrigatória.")]
        [MaxLength(20, ErrorMessage = "O valor máximo para a versão do sistema é de 20 caracteres.")]
        public string SystemVersion { get; set; } = string.Empty;

        public virtual Customer? Customer { get; set; }
    }
}