using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Interfaces;

namespace Domain.IntegrationsCore.Entities.Errors
{
    public class LoggerConfig : ILoggerConfig
    {
        public EnumIdDomain Domain { get; set; } = EnumIdDomain.Debug;
        public EnumIdLogLevel Level { get; set; }
        public string AppName { get; set; } = "";
    }
}