using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Entities.Errors
{
    public class LogStatus
    {
        public short? IdLogStatus { get; set; }
        public int? IdLogMsg { get; set; }
        public EnumIdApp IdApp { get; set; }
        public EnumIdLogLevel IdLogLevel { get; set; }
        public EnumIdDomain IdDomain { get; set; }
        public string Msg { get; set; } = "";
        public string? Detail { get; set; }
        public short? CountErrors { get; set; }
        public int? LastIdLogMsg { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public string LastUpdateUser { get; set; } = "";
    }
}

