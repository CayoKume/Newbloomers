using Domain.IntegrationsCore.Entities.Enums;

namespace Domain.IntegrationsCore.Exceptions
{
    public class InternalException : Exception
    {
        public EnumSteps Step { get; private set; }
        public EnumError Error { get; private set; }
        public EnumMessageLevel MessageLevel { get; private set; }
        public string Message { get; private set; }
        public string ExceptionMessage { get; private set; }

        public InternalException() { }

        public InternalException(
            EnumSteps step,
            string message,
            EnumError error,
            EnumMessageLevel level
        )
        {
            this.Step = step;
            this.Error = error;
            this.MessageLevel = level;
            this.Message = message;
        }

        public InternalException(
            EnumSteps step,
            string message,
            EnumError error,
            EnumMessageLevel level,
            string exceptionMessage
        )
        {
            this.Step = step;
            this.Error = error;
            this.MessageLevel = level;
            this.Message = message;
            this.ExceptionMessage = exceptionMessage;
        }
    }
}
