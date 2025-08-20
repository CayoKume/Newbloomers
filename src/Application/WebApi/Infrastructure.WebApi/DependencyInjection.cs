using Application.WebApi.Interfaces.Apis;
using Domain.WebApi.Interfaces.Repositorys;
using Application.WebApi.Interfaces.Services;
using Application.WebApi.Services;
using Infrastructure.WebApi.Api;
using Infrastructure.WebApi.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using Application.WebApi.Handlers.Commands;
using Application.WebApi.Interfaces.Handlers.Commands;

namespace Infrastructure.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedWmsServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("Labelary", client =>
            {
                client.BaseAddress = new Uri("http://api.labelary.com/v1/printers/8dpmm/labels/4x6/0/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IAttendanceCommandHandler, AttendanceCommandHandler>();

            services.AddScoped<ICancellationRequestService, CancellationRequestService>();
            services.AddScoped<ICancellationRequestRepository, CancellationRequestRepository>();
            services.AddScoped<ICancellationRequestCommandHandler, CancellationRequestCommandHandler>();

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyCommandHandler, CompanyCommandHandler>();

            services.AddScoped<IDeliveryListService, DeliveryListService>();
            services.AddScoped<IDeliveryListRepository, DeliveryListRepository>();
            services.AddScoped<IDeliveryListCommandHandler, DeliveryListCommandHandler>();

            services.AddScoped<IExecuteCancellationService, ExecuteCancellationService>();
            services.AddScoped<IExecuteCancellationRepository, ExecuteCancellationRepository>();
            services.AddScoped<IExecuteCancellationCommandHandler, ExecuteCancellationCommandHandler>();

            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IHomeCommandHandler, HomeCommandHandler>();

            services.AddScoped<ILabelsService, LabelsService>();
            services.AddScoped<ILabelsRepository, LabelsRepository>();
            services.AddScoped<ILabelsCommandHandler, LabelsCommandHandler>();

            services.AddScoped<IPickingService, PickingService>();
            services.AddScoped<IPickingRepository, PickingRepository>();
            services.AddScoped<IPickingCommandHandler, PickingCommandHandler>();

            return services;
        }
    }
}
