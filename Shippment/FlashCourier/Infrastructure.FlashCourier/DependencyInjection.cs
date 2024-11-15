using Application.FlashCourier.Interfaces;
using Application.FlashCourier.Services;
using Domain.FlashCourier.Interfaces.Api;
using Domain.FlashCourier.Interfaces.Repository;
using Infrastructure.FlashCourier.Api;
using Infrastructure.FlashCourier.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.FlashCourier.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedFlashCourierServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("FlashCourierAPI", client =>
            {
                //HOMOLOG
                //client.BaseAddress = new Uri("https://homolog.flashpegasus.com.br/FlashPegasus/rest");

                client.BaseAddress = new Uri("https://webservice.flashpegasus.com.br/FlashPegasus/rest");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IFlashCourierService, FlashCourierService>();
            services.AddScoped<IFlashCourierRepository, FlashCourierRepository>();

            return services;
        }
    }
}
