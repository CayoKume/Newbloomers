using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Exceptions
{
    public class SQLCommandException : Exception
    {
        public EnumStages Stage { get; private set; }
        public EnumError Error { get; private set; }
        public EnumMessageLevel MessageLevel { get; private set; }
        public string Message { get; private set; }
        public string ExceptionMessage { get; private set; }
        public string CommandSQL { get; private set; }

        public SQLCommandException() { }

        public SQLCommandException(
            EnumStages stage,
            string message,
            string exceptionMessage,
            string commandSQL
        )
        {
            this.Stage = stage;
            this.Error = EnumError.SQLCommand;
            this.MessageLevel = EnumMessageLevel.Error;
            this.Message = message;
            this.ExceptionMessage = exceptionMessage;
            this.CommandSQL = commandSQL;
        }
    }
}
