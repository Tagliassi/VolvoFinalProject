using System.ComponentModel;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models.Enum  
{    
    public enum EnumSituation
    {
        [Description("Concluído")]
        Done = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Cancelado")]
        Canceled = 3
    }
}