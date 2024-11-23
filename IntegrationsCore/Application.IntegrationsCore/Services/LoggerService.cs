using Application.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Errors;

namespace Application.IntegrationsCore.Services
{
    public class LoggerService : ILoggerService
    {
        public Log log { get; private set; }

        public ILoggerService AddLog(EnumJob job)
        {
            this.log ??= new Log(job: job); 

            return this;
        }

        public ILoggerService AddMessage(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message,
            string exceptionMessage,
            string commandSQL
        )
        {
            this.log?.Messages.Add(
                new Message(
                    idStep: idStep,
                    idError: idError,
                    idLogLevel: idLogLevel,
                    message: message,
                    exceptionMessage: exceptionMessage,
                    commandSQL: commandSQL,
                    guidExecution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message,
            string exceptionMessage
        )
        {
            this.log?.Messages.Add(
                new Message (
                    idStep: idStep,
                    idError: idError,
                    idLogLevel: idLogLevel,
                    message: message,
                    exceptionMessage: exceptionMessage,
                    guidExecution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message
        )
        {
            this.log?.Messages.Add(
                new Message(
                    idStep: idStep,
                    idError: idError,
                    idLogLevel: idLogLevel,
                    message: message,
                    guidExecution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(string message, string exceptionMessage)
        {
            this.log?.Messages.Add(
                new Message(
                    message: message,
                    exceptionMessage: exceptionMessage,
                    guidExecution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddMessage(string message)
        {
            this.log?.Messages.Add(
                new Message(
                    message: message,
                    guidExecution: this.log.Execution
                )
            );

            return this;
        }

        public ILoggerService AddRecord(string key, string xml)
        {
            this.log?.Records.Add(
                new Record(key: key, regXML: xml)
            );

            return this;
        }

        public ILoggerService SetLogEndDate()
        {
            if (this.log != null)
                this.log.EndDate = DateTime.Now;

            return this;
        }

        public ILoggerService Clear()
        {
            this.log?.Records.Clear();

            return this;
        }
    }
}


