using System.ComponentModel;

namespace Domain.Enums
{
    public enum EDistribuitorStatus
    {
        [Description("Ativo")]
        A = 1,

        [Description("Inativo")]
        I = -1
    }
}
