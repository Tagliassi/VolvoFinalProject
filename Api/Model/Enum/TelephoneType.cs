using System.ComponentModel;
using VolvoFinalProject;

namespace VolvoFinalProject.Api.Model.Models.Enum  
{
    public enum EnumTelephoneType
    {
        [Description("Celular")]
        Mobile = 1,
        [Description("Residencial")]
        Residential = 2,
        [Description("Empresarial")]
        Bussiness = 3
    }
}