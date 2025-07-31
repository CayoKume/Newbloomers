using Application.Core.Interfaces;
using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Application.Core.Handlers
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerService _logger;

        public ExceptionHandler(ILoggerService logger) =>
            (_logger) = (logger);

        // Este é o "catch-all" handler, então ele sempre pode lidar, mas deve ser o último a ser verificado.
        public bool CanHandle(Exception exception) => true;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            _logger.AddMessage(
                message: exception.Message,
                exceptionMessage: exception.StackTrace
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
                Message = exception.Message,
                ExceptionMessage = exception.StackTrace
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}
