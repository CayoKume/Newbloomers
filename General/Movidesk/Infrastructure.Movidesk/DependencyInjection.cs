using Application.Movidesk.Interfaces;
using Application.Movidesk.Services;
using Domain.Movidesk.Interfaces.Apis;
using Domain.Movidesk.Interfaces.Repositorys;
using Infrastructure.Movidesk.Api;
using Infrastructure.Movidesk.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Movidesk
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedMovideskServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("MovideskAPI", client =>
            {
                client.BaseAddress = new Uri("https://api.movidesk.com/public/v1/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IMovideskService, MovideskService>();
            services.AddScoped<IMovideskRepository, MovideskRepository>();

            return services;
        }
    }
}
