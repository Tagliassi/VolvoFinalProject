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
    public class VehicleDTO
    {    
        public int VehicleID { get; set; }
        public int CustomerFK { get; set; }
        public int ServiceFK { get; set; }
        [Required(ErrorMessage = "O número do chassi é obrigatório.")]
        public int ChassisNumber { get; set; }  
        [Required(ErrorMessage = "O ano do veículo é obrigatório.")]
        public int Year { get; set; }  
        public double Value { get; set; }
        [Required(ErrorMessage = "A quilometragem do veículo é obrigatória.")]
        public double Kilometrage { get; set; }
        [MaxLength(100, ErrorMessage = "O valor máximo para o modelo é de 100 caracteres.")]        
        [Required(ErrorMessage = "O modelo do veículo é obrigatório.")]
        public string Model { get; set; } = string.Empty;
        [MaxLength(50, ErrorMessage = "O valor máximo para a cor é de 50 caracteres.")]   
        [Required(ErrorMessage = "A cor do veículo é obrigatória.")]     
        public string Color { get; set; } = string.Empty; 
        [MaxLength(20, ErrorMessage = "O valor máximo para a versão do sistema é de 20 caracteres.")]   
        [Required(ErrorMessage = "A versão do sistema é obrigatória.")]     
        public string SystemVersion { get; set; } = string.Empty;
    }
}
