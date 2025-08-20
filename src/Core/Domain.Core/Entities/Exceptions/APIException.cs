using Domain.Core.Enums;

namespace Domain.Core.Entities.Exceptions
{
    public class APIException : ExceptionBase
    {
        public string? APIRequestResponse { get; private set; }

        public APIException(
            string message,
            string exceptionMessage,
            string apiRequestResponse
        ) : base(Error: EnumError.EndPointException, MessageLevel: EnumMessageLevel.Error, Message: message, ExceptionMessage: exceptionMessage)
        {
            APIRequestResponse = apiRequestResponse;
        }
    }
}
