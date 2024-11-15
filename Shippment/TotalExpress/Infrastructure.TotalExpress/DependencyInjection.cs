using Application.TotalExpress.Interfaces;
using Application.TotalExpress.Services;
using Domain.TotalExpress.Interfaces.Api;
using Domain.TotalExpress.Interfaces.Repository;
using Infrastructure.TotalExpress.Api;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.TotalExpress.Repository;

namespace Infrastructure.TotalExpress.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedTotalExpressServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("TotalExpressAPI", client =>
            {
                client.BaseAddress = new Uri("https://apis.totalexpress.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });
            services.AddHttpClient("TotalExpressEdiAPI", client =>
            {
                client.BaseAddress = new Uri("https://edi.totalexpress.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<ITotalExpressService, TotalExpressService>();
            services.AddScoped<ITotalExpressRepository, TotalExpressRepository>();

            return services;
        }
    }
}
