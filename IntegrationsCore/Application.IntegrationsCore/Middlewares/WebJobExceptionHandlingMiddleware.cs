using Application.IntegrationsCore.Handlers;
using Domain.IntegrationsCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IntegrationsCore.Middlewares
{
    public class WebJobExceptionHandlingMiddleware
    {
        private readonly IServiceProvider _services;

        public WebJobExceptionHandlingMiddleware(IServiceProvider services) =>
            _services = services;

        public async Task ExecuteAsync(Func<Task> func)
        {
            var context = new DefaultHttpContext { RequestServices = _services };

            try
            {
                await func();
            }
            catch (Exception ex)
            {
                var handlers = context.RequestServices.GetServices<IExceptionHandler>();

                var handler = handlers
                    .OrderBy(h => h.GetType() == typeof(ExceptionHandler) ? 1 : 0)
                    .First(h => h.CanHandle(ex));

                await handler.HandleAsync(context, ex);
            }
        }
    }
}
