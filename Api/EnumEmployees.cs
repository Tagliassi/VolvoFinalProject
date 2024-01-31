using System.ComponentModel;

namespace VolvoFinalProject
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
