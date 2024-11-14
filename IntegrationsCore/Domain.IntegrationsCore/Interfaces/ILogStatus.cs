using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogStatus
    {
        short? IdLogStatus { get; set; }
        int? IdLogMsg { get; set; }
        EnumIdApp IdApp { get; set; }
        EnumIdLogLevel IdLogLevel { get; set; }
        EnumIdDomain IdDomain { get; set; }
        string Msg { get; set; }
        string? Detail { get; set; }
        short? CountErrors { get; set; }
        int? LastIdLogMsg { get; set; }
        DateTime LastUpdateOn { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        string LastUpdateUser { get; set; }
    }
}