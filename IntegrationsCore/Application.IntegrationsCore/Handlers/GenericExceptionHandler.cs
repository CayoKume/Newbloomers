using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Application.IntegrationsCore.Handlers
{
    public class GenericExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerService _loggerService;

        public GenericExceptionHandler(ILogger<GenericExceptionHandler> logger, ILoggerService loggerService) =>
            (_loggerService) = (loggerService);

        // Este é o "catch-all" handler, então ele sempre pode lidar, mas deve ser o último a ser verificado.
        public bool CanHandle(Exception exception) => true;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            _loggerService.AddMessage(
                stage: EnumStages.GetB2CCompanys,
                error: EnumError.Undefined,
                logLevel: EnumMessageLevel.Information,
                message: exception.Message,
                exceptionMessage: "exception.ExceptionMessage"
            );

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Um erro inesperado ocorreu. Por favor, tente novamente.",
                ErrorCode = "UNEXPECTED_ERROR",
                // Details = exception.Message // Remova em ambiente de produção para evitar expor detalhes internos
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}
