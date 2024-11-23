using Domain.IntegrationsCore.Entities.Enums;
namespace Domain.IntegrationsCore.Entities.Errors
{
    public class Message
    {
        public EnumSteps? IdStep { get; private set; }
        public EnumMessageLevel? IdLogLevel { get; private set; }
        public EnumError? IdError { get; private set; }
        public bool? IsError { get; private set; }
        public string? Msg { get; private set; }
        public string? ExceptionMessage { get; private set; }
        public string? CommandSQL { get; private set; }
        public Guid Execution { get; private set; }

        public Message() { }

        public Message(string message, Guid guidExecution)
        {
            this.Msg = message;
            this.Execution = guidExecution;
        }

        public Message(string message, string exceptionMessage, Guid guidExecution)
        {
            this.Msg = message;
            this.ExceptionMessage = exceptionMessage;
            this.Execution = guidExecution;
        }

        public Message(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message,
            Guid guidExecution
        )
        {
            this.IdStep = idStep;
            this.IdError = idError;
            this.IdLogLevel = idLogLevel;
            this.IsError = false;
            this.Msg = message;
            this.Execution = guidExecution;
        }

        public Message(
            EnumSteps idStep,
            EnumError idError,
            EnumMessageLevel idLogLevel,
            string message,
            string exceptionMessage,
            Guid guidExecution
        )
        {
            this.IdStep = idStep;
            this.IdError = idError;
            this.IdLogLevel = idLogLevel;
            this.IsError = true;
            this.Msg = message;
            this.ExceptionMessage = exceptionMessage;
            this.Execution = guidExecution;
        }

        public Message(
            EnumSteps idStep, 
            EnumError idError, 
            EnumMessageLevel idLogLevel,
            string message, 
            string exceptionMessage,
            string commandSQL,
            Guid guidExecution
        )
        {
            this.IdStep = idStep;
            this.IdError = idError;
            this.IdLogLevel = idLogLevel;
            this.IsError = true;
            this.Msg = message;
            this.ExceptionMessage = exceptionMessage;
            this.CommandSQL = commandSQL;
            this.Execution = guidExecution;
        }
    }
}
