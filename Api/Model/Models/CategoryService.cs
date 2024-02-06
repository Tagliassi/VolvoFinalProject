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
    public class CategoryService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryServiceID { get; set; }

        [ForeignKey("Service")]
        public int ServiceFK { get; set; }

        [Required(ErrorMessage = "O tempo de execução é obrigatório.")]
        public int ExecutionTime { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(100, ErrorMessage = "O valor máximo para a descrição é 100 caracteres.")]
        public EnumCategoryService Category { get; set; }

        [JsonIgnore]
        public virtual Service? Service { get; set; }
    }
}