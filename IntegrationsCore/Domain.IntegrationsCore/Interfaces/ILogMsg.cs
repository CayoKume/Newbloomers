
using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogMsg
    {
        int? IdLogMsg { get; set; }
        EnumIdApp IdApp { get; set; } 
        EnumIdLogLevel IdLogLevel { get; set; }
        EnumIdDomain IdDomain { get; set; }
        EnumIdError IdError { get; set; }
        EnumIdSteps IdStep { get; set; }
        string? TextLog { get; set; }
        string? ValueKeyFields { get; set; }
        bool Checked { get; set; } 
        string AppName { get; set; } 
        string LastUpdateUser { get; set; } 
        DateTime LastUpdateOn { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        IList<ILogMsgsDetail> LogMsgDetails { get; set; }
        IList<ILogStatus> LogStatus { get; set; }
    }
}



