using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Entities.Exceptions
{
    public class SQLCommandException : ExceptionBase
    {
        public string? CommandSQL { get; private set; }

        public SQLCommandException(
            string message,
            string exceptionMessage,
            string commandSQL
        ) : base(Error: EnumError.SQLCommand, MessageLevel: EnumMessageLevel.Error, Message: message, ExceptionMessage: exceptionMessage)
        {
            CommandSQL = commandSQL;
        }
    }
}
