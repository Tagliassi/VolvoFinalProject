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
        public CategoryService()
        {
            Parts = new HashSet<Parts>();
        }        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryServiceID { get; set; }
        public int ServiceFK { get; set; }
        public int ExecutionTime { get; set; }        
        [MaxLength(100)]
        [Required]
        public string Description { get; set; } = string.Empty;
        public EnumCategoryService Category { get; set; } 
        public ICollection<Parts> Parts { get; set; }
        [ForeignKey("ServiceFK")]
        public Service? Service { get; set; } 
    }
}