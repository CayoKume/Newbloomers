using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Entities.Exceptions
{
    public class ExceptionBase : Exception
    {
        public string? ExceptionMessage { get; private set; }
        public EnumError Error { get; private set; }
        public EnumMessageLevel MessageLevel { get; private set; }

        public ExceptionBase(EnumError Error, EnumMessageLevel MessageLevel, string Message, string ExceptionMessage) : base (message: Message)
        {
            this.ExceptionMessage = ExceptionMessage;
            this.Error = Error;
            this.MessageLevel = MessageLevel;
        }
    }
}
