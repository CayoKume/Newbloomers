using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Models.Exceptions
{
    public class InternalException : Exception
    {
        public EnumStages stage { get; private set; }
        public EnumError Error { get; private set; }
        public EnumMessageLevel MessageLevel { get; private set; }
        public string Message { get; private set; }
        public string ExceptionMessage { get; private set; }

        public InternalException() { }

        public InternalException(
            EnumStages stage,
            string message,
            EnumError error,
            EnumMessageLevel level
        )
        {
            this.stage = stage;
            Error = error;
            MessageLevel = level;
            Message = message;
        }

        public InternalException(
            EnumStages stage,
            string message,
            EnumError error,
            EnumMessageLevel level,
            string exceptionMessage
        )
        {
            this.stage = stage;
            Error = error;
            MessageLevel = level;
            Message = message;
            ExceptionMessage = exceptionMessage;
        }
    }
}
