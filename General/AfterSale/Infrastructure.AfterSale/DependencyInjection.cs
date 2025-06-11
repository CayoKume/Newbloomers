using Application.AfterSale.Interfaces;
using Application.AfterSale.Services;
using Domain.AfterSale.Interfaces.Api;
using Domain.AfterSale.Interfaces.Repositorys;
using Infrastructure.AfterSale.Api;
using Infrastructure.AfterSale.Repositorys;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.AfterSale.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedAfterSaleServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("AfterSaleAPI", client =>
            {
                client.BaseAddress = new Uri("https://api.send4.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IAfterSaleService, AfterSaleService>();
            services.AddScoped<IAfterSaleRepository, AfterSaleRepository>();

            return services;
        }
    }
}
