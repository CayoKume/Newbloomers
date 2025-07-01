using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Domain.IntegrationsCore.Handlers
{
    public class InternalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<InternalExceptionHandler> _logger;

        public InternalExceptionHandler(ILogger<InternalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public bool CanHandle(Exception exception)
        {
            return exception is InternalException;
        }

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var ex = (InternalException)exception;
            _logger.LogError(ex, "InternalException capturada: {Message} - Stage: {Stage} - Error: {Error}", ex.Message, ""/*ex.Stage*/, ex.Error);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Ocorreu um erro interno inesperado.",
                ErrorCode = "INTERNAL_ERROR",
                Details = ex.Message,
                Stage = "",//ex.Stage.ToString(),
                ErrorType = ex.Error.ToString(),
                LogLevel = ""//ex.Level.ToString()
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}
