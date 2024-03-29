using System.ComponentModel;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models.Enum  
{
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
        IShiftUpadate = 8,
        [Description("Serviço Extra")]
        ExtraService = 9,
        [Description("Recepcionar o Cliente")]
        WelcomeCustomer = 10,
        [Description("Validar a disponibilidade da peça")]
        PartAvailability = 11       
    }
}