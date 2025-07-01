using Domain.IntegrationsCore.Handlers;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Domain.IntegrationsCore.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<IExceptionHandler> _exceptionHandlers; // Coleção de manipuladores

        public ExceptionHandlingMiddleware(RequestDelegate next, IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            _next = next;
            _exceptionHandlers = exceptionHandlers;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Tenta encontrar um manipulador específico para a exceção
                // Ordena para que o manipulador genérico seja o último a ser testado.
                var handler = _exceptionHandlers
                    .OrderBy(h => h.GetType() == typeof(GenericExceptionHandler) ? 1 : 0) // Garante que o GenericExceptionHandler seja o último
                    .FirstOrDefault(h => h.CanHandle(ex));

                if (handler != null)
                {
                    await handler.HandleAsync(context, ex);
                }
                else
                {
                    // Fallback caso não encontre nenhum handler (improvável se GenericExceptionHandler estiver presente)
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new { Message = "Erro desconhecido.", StatusCode = (int)HttpStatusCode.InternalServerError }));
                }
            }
        }
    }
}
