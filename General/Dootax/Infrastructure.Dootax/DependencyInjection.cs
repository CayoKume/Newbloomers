using Application.Dootax.Interfaces;
using Application.Dootax.Services;
using Domain.Dootax.Interfaces.Apis;
using Domain.Dootax.Interfaces.Repositorys;
using Infrastructure.Dootax.Api;
using Infrastructure.Dootax.Repositorys.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dootax
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedDootaxServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("DootaxAPI", client =>
            {
                //HOMOLOG
                //https://hom.app.dootax.com.br

                client.BaseAddress = new Uri("https://app.dootax.com.br");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IDootaxService, DootaxService>();
            services.AddScoped<IDootaxRepository, DootaxRepository>();

            return services;
        }
    }
}
