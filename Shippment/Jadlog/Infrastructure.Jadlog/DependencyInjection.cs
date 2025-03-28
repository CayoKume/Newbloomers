using Domain.Jadlog.Interfaces.Api;
using Infrastructure.Jadlog.Api;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Jadlog
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedAfterSaleServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("JadlogAPI", client =>
            {
                client.BaseAddress = new Uri("https://www.jadlog.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });
            services.AddHttpClient("JadlogTechAPI", client =>
            {
                client.BaseAddress = new Uri("https://prd-traffic.jadlogtech.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            //services.AddScoped<IAfterSaleService, AfterSaleService>();
            //services.AddScoped<IAfterSaleRepository, AfterSaleRepository>();

            return services;
        }
    }
}
