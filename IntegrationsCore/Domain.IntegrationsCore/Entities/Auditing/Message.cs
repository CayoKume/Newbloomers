using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Extensions;

namespace Domain.IntegrationsCore.Entities.Auditing
{
    public class Message
    {
        /// <summary>
        /// auto increment property created to be the primary key of the migration
        /// </summary>
        [SkipProperty]
        public Int32? IdExecutionMessage { get; private set; }

        /// <summary>
        /// this property is obsolet, and will die in the next major version
        /// </summary>
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
        /// Build an INFORMATION message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="guidExecution"></param>
        public Message(string Msg, Guid? guidExecution)
        {
            this.Msg = Msg;
            IdLogLevel = EnumMessageLevel.Information;
            IsError = false;
            Execution = guidExecution;
        }

        /// <summary>
        /// Build an ERROR exception message with exception details occurred
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exceptionMessage"></param>
        /// <param name="execution"></param>
        public Message(string message, string exceptionMessage, Guid? execution)
        {
            Msg = message;
            IsError = true;
            IdLogLevel = EnumMessageLevel.Error;
            ExceptionMessage = exceptionMessage;
            Execution = execution;
        }

        /// <summary>
        /// Build an ERROR message with sql command details occurred
        /// </summary>
        /// <param name="message"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="execution"></param>
        public Message(string message, string exceptionMessage, string sqlCommand, Guid? execution)
        {
            Msg = message;
            IsError = true;
            IdLogLevel = EnumMessageLevel.Error;
            ExceptionMessage = exceptionMessage;
            CommandSQL = sqlCommand;
            Execution = execution;
        }
    }
}
