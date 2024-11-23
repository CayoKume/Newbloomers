using Domain.IntegrationsCore.Entities.Enums;

namespace Application.IntegrationsCore.Interfaces
{
    public interface ILoggerService
    {
        public ILoggerService AddLog(EnumJob job);

        public ILoggerService AddMessage(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message,
            string exceptionMessage,
            string commandSQL
        );

        public ILoggerService AddMessage(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message,
            string exceptionMessage
        );

        public ILoggerService AddMessage(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message
        );

        public ILoggerService AddMessage(string message, string exceptionMessage);

        public ILoggerService AddMessage(string message);

        public ILoggerService AddRecord(string key, string xml);

        public ILoggerService SetLogEndDate();

        public ILoggerService Clear();
    }
}

