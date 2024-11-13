using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Entities.Errors
{
    public class Error
    {
        public EnumIdError IdError { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public EnumIdLogLevel IdLogLevel { get; set; }
        public string? Resolution { get; set; }
        public string LastUpdateUser { get; set; } = "";
        public DateTime LastUpdateOn { get; set; }

        public bool? RequireUserAction { get; set; }
        public bool? IsError { get; set; }
        public byte? EmergencyLevel { get; set; }
        public string? ActionInf { get; set; }
    }
}

