using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Entities.Exceptions
{
    public class GeneralException : Exception
    {
        public EnumStages stage { get; private set; }
        public EnumError Error { get; private set; }
        public EnumMessageLevel MessageLevel { get; private set; }
        public string Message { get; private set; }
        public string ExceptionMessage { get; private set; }

        public GeneralException() { }

        public GeneralException(
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

        public GeneralException(
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
