using Domain.IntegrationsCore.Enums;

namespace Domain.IntegrationsCore.Entities.Exceptions
{
    public class GeneralException : ExceptionBase
    {
        public GeneralException(string message, string exceptionMessage)
            : base(Error: EnumError.Exception, MessageLevel: EnumMessageLevel.Error, Message: message, ExceptionMessage: exceptionMessage) { }
    }
}
