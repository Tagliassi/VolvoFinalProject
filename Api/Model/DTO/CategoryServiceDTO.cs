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

        public int CategoryServiceID { get; set; }
        public int ServiceFK { get; set; }
        public int ExecutionTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public EnumCategoryService Category { get; set; } 
        public ICollection<Parts> Parts { get; set; }  
    }
}