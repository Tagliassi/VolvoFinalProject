using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolvoFinalProject;
using VolvoFinalProject.Api.Repository.Interfaces;
using VolvoFinalProject.Api.Model.Models.Enum;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Model.DTO
{
    public class CategoryServiceDTO 
    {
        public CategoryServiceDTO()
        {
            Parts = new HashSet<Parts>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public int ServiceFK { get; set; }
        public int ExecutionTime { get; set; }
        [MaxLength(100, ErrorMessage = "O valor máximo para a descrição é 100 caracteres.")]
        [Required (ErrorMessage = "A descrição é obrigatória.")]
        public string Description { get; set; } = string.Empty;
        public EnumCategoryService Category { get; set; } 
        public ICollection<Parts> Parts { get; set; }  
    }
}