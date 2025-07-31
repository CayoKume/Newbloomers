using Domain.Core.Interfaces;
using Application.Core.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Core.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var _exceptionHandlers = context.RequestServices.GetServices<IExceptionHandler>();

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var handler = _exceptionHandlers
                    .OrderBy(h => h.GetType() == typeof(ExceptionHandler) ? 1 : 0) // Garante que o ExceptionHandler seja o último
                    .First(h => h.CanHandle(ex));

                await handler.HandleAsync(context, ex);
            }
        }
    }
}
