using Domain.Core.Enums;

namespace Domain.Core.Entities.Exceptions
{
    public class GeneralException : ExceptionBase
    {
        public GeneralException(string message, string exceptionMessage)
            : base(Error: EnumError.Exception, MessageLevel: EnumMessageLevel.Error, Message: message, ExceptionMessage: exceptionMessage) { }
    }
}
