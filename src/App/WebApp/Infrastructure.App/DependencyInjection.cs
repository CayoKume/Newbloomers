using Application.WebApp.Interfaces.Api;
using Application.WebApp.Interfaces.Services;
using Infrastructure.WebApp.Api;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Infrastructure.WebApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();

            if (System.Diagnostics.Debugger.IsAttached)
            {
                services.AddHttpClient("MiniWMS", client =>
                {
                    //client.BaseAddress = new Uri("http://localhost:5143/NewBloomers/BloomersInvoiceIntegrations/MiniWms/");
                    client.BaseAddress = new Uri("https://localhost:7113/NewBloomers/BloomersInvoiceIntegrations/MiniWms/");
                    client.Timeout = new TimeSpan(0, 2, 0);
                });
            }
            else
            {
                services.AddHttpClient("MiniWMS", client =>
                {
                    client.BaseAddress = new Uri("https://webservices.newbloomers.com.br:7072/NewBloomers/BloomersInvoiceIntegrations/MiniWms/");
                    client.Timeout = new TimeSpan(0, 2, 0);
                });
            }

            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ICancellationRequestService, CancellationRequestService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDeliveryListService, DeliveryListService>();
            services.AddScoped<IExecuteCancellationService, ExecuteCancellationService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ILabelsService, LabelsService>();
            services.AddScoped<IPickingService, PickingService>();

            return services;
        }
    }
}
