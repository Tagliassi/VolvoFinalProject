using System.ComponentModel;

namespace VolvoFinalProject
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

