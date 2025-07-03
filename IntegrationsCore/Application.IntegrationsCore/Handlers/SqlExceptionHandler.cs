using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Application.IntegrationsCore.Handlers
{
    public class SqlExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<SqlExceptionHandler> _logger;

        public SqlExceptionHandler(ILogger<SqlExceptionHandler> logger) =>
            _logger = logger;

        public bool CanHandle(Exception exception) => exception is SQLCommandException;

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            var ex = (SQLCommandException)exception;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorDetails = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Ocorreu um erro ao executar um comando SQL.",
                ErrorCode = "SQL_ERROR",
                Details = ex.Message,
                Stage = ex.Stage.ToString(),
                Command = ex.CommandSQL
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorDetails));
        }
    }
}
