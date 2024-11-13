using Application.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;

namespace Application.IntegrationsCore.Services
{
    public class LoggerConfigService : ILoggerConfigService
    {
        public EnumIdDomain Domain { get; set; } = EnumIdDomain.Debug;
        public EnumIdLogLevel Level { get; set; }
        public string AppName { get; set; } = "";
    }
}