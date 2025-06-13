using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Models.Errors
{
    public class Message
    {
        public EnumStages? IdStage { get; private set; }
        public EnumMessageLevel? IdLogLevel { get; private set; }
        public bool? IsError { get; private set; }
        public EnumError? IdError { get; private set; }
        public Guid Execution { get; private set; }
        public string? Msg { get; private set; }
        public string? ExceptionMessage { get; private set; }
        public string? CommandSQL { get; private set; }

        public Message() { }

        /// <summary>
        /// Build an information message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="guidExecution"></param>
        public Message(string message, Guid guidExecution)
        {
            this.Msg = message;
            this.IdLogLevel = EnumMessageLevel.Information;
            this.IsError = false;
            this.Execution = guidExecution;
        }

        /// <summary>
        /// Build an error exception message with exception details occurred outside a stage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exceptionMessage"></param>
        /// <param name="execution"></param>
        public Message(string message, string exceptionMessage, Guid execution)
        {
            this.Msg = message;
            this.IsError = true;
            this.IdLogLevel = EnumMessageLevel.Error;
            this.ExceptionMessage = exceptionMessage;
            this.Execution = execution;
        }

        /// <summary>
        /// Build an message occurred in one stage without exception details
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="error"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="execution"></param>
        public Message(
            EnumStages stage,
            EnumError error,
            EnumMessageLevel logLevel,
            string message,
            Guid execution
        )
        {
            this.IdStage = stage;
            this.IdError = error;
            this.IdLogLevel = logLevel;
            this.IsError = false;
            this.Msg = message;
            this.Execution = execution;
        }

        /// <summary>
        /// Build an message occurred in one stage with exception details
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="error"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exceptionMessage"></param>
        /// <param name="execution"></param>
        public Message(
            EnumStages stage,
            EnumError error,
            EnumMessageLevel logLevel,
            string message,
            string exceptionMessage,
            Guid execution
        )
        {
            this.IdStage = stage;
            this.IdError = error;
            this.IdLogLevel = logLevel;
            this.IsError = true;
            this.Msg = message;
            this.ExceptionMessage = exceptionMessage;
            this.Execution = execution;
        }

        /// <summary>
        /// Build an message occurred in one repository stage with exception details and command sql tried to execute
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="error"></param>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        /// <param name="exceptionMessage"></param>
        /// <param name="commandSQL"></param>
        /// <param name="execution"></param>
        public Message(
            EnumStages stage,
            EnumError error,
            EnumMessageLevel logLevel,
            string message,
            string exceptionMessage,
            string commandSQL,
            Guid execution
        )
        {
            this.IdStage = stage;
            this.IdError = error;
            this.IdLogLevel = logLevel;
            this.IsError = true;
            this.Msg = message;
            this.ExceptionMessage = exceptionMessage;
            this.CommandSQL = commandSQL;
            this.Execution = execution;
        }
    }
}
