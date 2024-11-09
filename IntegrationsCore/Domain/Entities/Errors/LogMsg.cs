using IntegrationsCore.Domain.Entities.Enums;

namespace IntegrationsCore.Domain.Entities.Errors
{
    public class LogMsg
    {
        public int? IdLogMsg { get; set; }
        public EnumIdApp IdApp { get; set; } = EnumIdApp.Undefined;
        public EnumIdLogLevel IdLogLevel { get; set; }
        public EnumIdDomain IdDomain { get; set; }
        public EnumIdError IdError { get; set; }
        public string? TextLog { get; set; }
        public string? ValueKeyFields { get; set; }
        public bool Checked { get; set; } = false;
        public string AppName { get; set; } = "";
        public string LastUpdateUser { get; set; } = "";
        public DateTime LastUpdateOn { get; set; } = DateTime.Now;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; } = DateTime.Now;
        public IList<LogMsgsDetail> LogMsgDetails { get; set; } = [];
        public IList<LogStatus> LogStatus { get; set; } = [];
    }
}

