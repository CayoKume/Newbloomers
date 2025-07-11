using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Application.IntegrationsCore.Handlers
{
    public class GeneralExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerService _logger;

        public GeneralExceptionHandler(ILoggerService logger) =>
            (_logger) = (logger);

        public bool CanHandle(Exception exception) => exception is GeneralException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var ex = (GeneralException)exception;

            _logger.AddMessage(
                message: ex.Message,
                exceptionMessage: ex.ExceptionMessage
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Title = "Unable to integrate the records.",
                ErrorCode = "UNEXPECTED_ERROR",
                Message = ex.Message,
                ExceptionMessage = ex.ExceptionMessage
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}
