using Domain.IntegrationsCore.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Domain.IntegrationsCore.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
