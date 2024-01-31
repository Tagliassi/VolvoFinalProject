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
     public class CategoryService
    {
        public CategoryService()
        {
            Parts = new HashSet<Parts>();
        }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int CategoryServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public int ServiceFK { get; set; }
        public int ExecutionTime { get; set; }
        public double Value { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Description { get; set; } = null!; 
        public ICollection<Parts> Parts { get; set; }  
    }

    public enum EnumCategoryService
    {
        [Description("Troca de Óleo")]
        OilChange = 1,
        [Description("Alinhamento")]
        Alignment = 2,
        [Description("Balanceamento")]
        Balancing = 3,
        [Description("Geometria")]
        Geometry = 4,
        [Description("Revisões Programadas")]
        ScheduledRevisions = 5,
        [Description("Substituição de Peça")]
        PartReplacement = 6,
        [Description("Atualizações de software")]
        SoftwareUpdates = 7,
        [Description("Atualizações de I-shift")]
        IShiftUpadate = 8
    }
}