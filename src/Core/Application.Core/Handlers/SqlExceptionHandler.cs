using Application.Core.Interfaces;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Application.Core.Handlers
{
    public class SqlExceptionHandler : IExceptionHandler
    {
        private readonly ILoggerService _logger;

        public SqlExceptionHandler(ILoggerService logger) =>
            (_logger) = (logger);

        public bool CanHandle(Exception exception) => exception is SQLCommandException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var ex = (SQLCommandException)exception;

            _logger.AddMessage(
                message: ex.Message,
                exceptionMessage: ex.ExceptionMessage,
                sqlCommand: ex.CommandSQL
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Title = "Ocorreu um erro ao executar um comando SQL.",
                ErrorCode = "SQL_ERROR",
                Message = ex.Message,
                ExceptionMessage = ex.ExceptionMessage,
                Command = ex.CommandSQL
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}
