using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Models.Exceptions
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
            Stage = stage;
            Error = EnumError.SQLCommand;
            MessageLevel = EnumMessageLevel.Error;
            Message = message;
            ExceptionMessage = exceptionMessage;
            CommandSQL = commandSQL;
        }
    }
}
