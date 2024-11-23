using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Exceptions
{
    public class SQLCommandException : Exception
    {
        public EnumSteps Step { get; private set; }
        public EnumError Error { get; private set; }
        public EnumMessageLevel MessageLevel { get; private set; }
        public string Message { get; private set; }
        public string ExceptionMessage { get; private set; }
        public string CommandSQL { get; private set; }

        public SQLCommandException() { }

        public SQLCommandException(
            EnumSteps step,
            string message,
            string exceptionMessage,
            string commandSQL
        )
        {
            this.Step = step;
            this.Error = EnumError.SQLCommand;
            this.MessageLevel = EnumMessageLevel.Error;
            this.Message = message;
            this.ExceptionMessage = exceptionMessage;
            this.CommandSQL = commandSQL;
        }
    }
}
