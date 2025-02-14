using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Domain.IntegrationsCore.Interfaces;
using HangfireDashboard.Domain.Extensions;
using Infrastructure.DatabaseInit;
using Infrastructure.FlashCourier.DependencyInjection;
using Infrastructure.IntegrationsCore.Repositorys;
using Infrastructure.LinxCommerce.DependencyInjection;
using Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection;
using Infrastructure.TotalExpress.DependencyInjection;

namespace AzureJobs.Extensions
{
    public static class ServicesExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScopedSQLServerConnection();

                services.AddAuditServices();
                services.AddScopedLinxCommerceServices();
                services.AddScopedLinxMicrovixServices();
                services.AddScopedB2CLinxMicrovixServices();
                services.AddScopedFlashCourierServices();
                services.AddScopedTotalExpressServices();

                services.AddScopedDatabaseIniService();
                services.AddScopedB2CLinxMicrovixDatabaseInitServices();
                services.AddScopedLinxMicrovixDatabaseInitServices();
            });

            return builder;
        }

        public static IServiceCollection AddAuditServices(this IServiceCollection services)
        {
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<ILoggerService, LoggerService>();

            return services;
        }
    }
}
