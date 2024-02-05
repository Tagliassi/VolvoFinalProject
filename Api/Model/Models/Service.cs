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
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }        
        public int PartFK { get; set; }       
        public int EmployeeFK { get; set; }        
        public int CustomerFK { get; set; } 
        public int VehicleFK { get; set; }
        public int CategoryServiceFK { get; set; }         
        public double Value { get; set; }  
        [Required(ErrorMessage = "A data do serviço é obrigatória.")]     
        public DateTime? Date { get; set; }
        public EnumSituation Situation { get; set; } 
        [ForeignKey("PartsFK")]
        public Parts? Parts { get; set; }
        [ForeignKey("EmployeeFK")]
        public Employee? Employee { get; set; }
        [ForeignKey("CustomerFK")]
        public Customer? Customer { get; set; }
        [ForeignKey("VehicleFK")]
        public Vehicle? Vehicle { get; set; }
        [ForeignKey("CategoryServiceFK")]
        public CategoryService? CategoryService { get; set; } 
        public ICollection<CategoryService>? CategoryServices { get; set; }
        public ICollection<Customer>? Customers { get; set; }
        public ICollection<Employee>? Employees { get; set; } 
    }
}