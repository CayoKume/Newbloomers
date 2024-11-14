using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface IError
    {
        EnumIdError IdError { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        EnumIdLogLevel IdLogLevel { get; set; }
        string? Resolution { get; set; }
        string LastUpdateUser { get; set; }
        DateTime LastUpdateOn { get; set; }

        public bool? RequireUserAction { get; set; }
        public bool? IsError { get; set; }
        public byte? EmergencyLevel { get; set; }
        public string? ActionInf { get; set; }
    }
}