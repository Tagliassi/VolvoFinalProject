using System.ComponentModel;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models.Enum  
{
    public enum EnumEmployees
    {
        [Description("Recepcionista")]
        Receptionist = 1,
        [Description("Gerenciador de inventário")]
        InventoryManager = 2,
        [Description("Engenheiro mecânico")]
        MechanicalEngineer = 3
    }
}