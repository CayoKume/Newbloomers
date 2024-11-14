using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILoggerConfig
    {
        EnumIdDomain Domain { get; set; }
        EnumIdLogLevel Level { get; set; }
        string AppName { get; set; }
    }
}