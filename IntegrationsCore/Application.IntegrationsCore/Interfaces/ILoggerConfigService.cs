using Domain.IntegrationsCore.Entities.Enums;

namespace Application.IntegrationsCore.Interfaces
{
    public interface ILoggerConfigService
    {
        EnumIdDomain Domain { get; set; }
        EnumIdLogLevel Level { get; set; }
        string AppName { get; set; }
    }
}