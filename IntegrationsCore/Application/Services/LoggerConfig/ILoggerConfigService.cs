using IntegrationsCore.Domain.Entities.Enums;

namespace Bloomers.Core.Auditoria.Infrastructure.Logger
{
    public interface ILoggerConfigService
    {
        EnumIdDomain Domain { get; set; }
        EnumIdLogLevel Level { get; set; }
        string AppName { get; set; }
    }
}