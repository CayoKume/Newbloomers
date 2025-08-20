using Application.Core.Interfaces;
using Application.Core.Services;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Application.Core.Handlers
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
