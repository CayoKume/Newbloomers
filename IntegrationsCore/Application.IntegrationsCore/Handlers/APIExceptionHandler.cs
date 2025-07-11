using Application.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Application.IntegrationsCore.Handlers
{
    public class APIExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerService _logger;

        public APIExceptionHandler(ILoggerService logger) =>
            (_logger) = (logger);

        public bool CanHandle(Exception exception) => exception is APIException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var ex = (APIException)exception;

            _logger.AddMessage(
                message: ex.Message,
                exceptionMessage: ex.ExceptionMessage,
                sqlCommand: ex.APIRequestResponse
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Title = "Ocorreu um erro ao consultar uma API.",
                ErrorCode = "API_ERROR",
                Message = ex.Message,
                ExceptionMessage = ex.ExceptionMessage,
                APIRequestResponse = ex.APIRequestResponse
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}
