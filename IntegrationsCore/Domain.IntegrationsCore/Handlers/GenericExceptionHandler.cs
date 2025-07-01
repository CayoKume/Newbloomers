using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.IntegrationsCore.Handlers
{
    public class GenericExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GenericExceptionHandler> _logger;

        public GenericExceptionHandler(ILogger<GenericExceptionHandler> logger)
        {
            _logger = logger;
        }

        public bool CanHandle(Exception exception)
        {
            // Este é o "catch-all" handler, então ele sempre pode lidar,
            // mas deve ser o último a ser verificado.
            return true;
        }

        public async Task HandleAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Exceção genérica não tratada: {Message}", exception.Message);

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
