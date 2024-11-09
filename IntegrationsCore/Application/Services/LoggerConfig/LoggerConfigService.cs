
using IntegrationsCore.Domain.Entities.Enums;

namespace Bloomers.Core.Auditoria.Infrastructure.Logger
{
    public class LoggerConfigService : ILoggerConfigService
    {
        public EnumIdDomain Domain { get; set; } = EnumIdDomain.Debug;
        public EnumIdLogLevel Level { get; set; }
        public string AppName { get; set; } = "";
    }
}