using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Entities.Auditing
{
    public class Message
    {
        /// <summary>
        /// 
        /// </summary>
        public Int32? IdExecutionMessage { get; private set; }

        public EnumStages? IdStage { get; private set; }
        public EnumMessageLevel? IdLogLevel { get; private set; }
        public bool? IsError { get; private set; }
        public EnumError? IdError { get; private set; }
        public Guid? Execution { get; private set; }
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
            Msg = message;
            IdLogLevel = EnumMessageLevel.Information;
            IsError = false;
            Execution = guidExecution;
        }

        /// <summary>
        /// Build an error exception message with exception details occurred outside a stage
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exceptionMessage"></param>
        /// <param name="execution"></param>
        public Message(string message, string exceptionMessage, Guid execution)
        {
            Msg = message;
            IsError = true;
            IdLogLevel = EnumMessageLevel.Error;
            ExceptionMessage = exceptionMessage;
            Execution = execution;
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
            IdStage = stage;
            IdError = error;
            IdLogLevel = logLevel;
            IsError = false;
            Msg = message;
            Execution = execution;
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
            IdStage = stage;
            IdError = error;
            IdLogLevel = logLevel;
            IsError = true;
            Msg = message;
            ExceptionMessage = exceptionMessage;
            Execution = execution;
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
            IdStage = stage;
            IdError = error;
            IdLogLevel = logLevel;
            IsError = true;
            Msg = message;
            ExceptionMessage = exceptionMessage;
            CommandSQL = commandSQL;
            Execution = execution;
        }
    }
}
