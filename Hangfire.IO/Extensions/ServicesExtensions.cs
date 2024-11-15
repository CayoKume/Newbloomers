using Hangfire.SqlServer;
using Infrastructure.IntegrationsCore.DependencyInjection;
using Infrastructure.LinxCommerce.DependencyInjection;
using Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection;
using Infrastructure.TotalExpress.DependencyInjection;
using Infrastructure.FlashCourier.DependencyInjection;

namespace Hangfire.IO.Extensions
{
    public static class ServicesExtensions
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            var serverName = builder.Configuration.GetSection("ConfigureServer").GetSection("ServerName").Value;
            var connectionstring = builder.Configuration.GetConnectionString("Connection").Replace("[catalog]", "GENERAL").Replace("[database]", "GENERAL");

            builder.Services.AddScopedSQLServerConnection();

            builder.Services.AddScopedLinxCommerceServices();
            builder.Services.AddScopedLinxMicrovixServices();
            builder.Services.AddScopedB2CLinxMicrovixServices();
            builder.Services.AddScopedFlashCourierServices();
            builder.Services.AddScopedTotalExpressServices();

            builder.Services.AddHangfireService(connectionstring, serverName);

            return builder;
        }

        public static IServiceCollection AddHangfireService(this IServiceCollection services, string? connectionstring, string? serverName)
        {
            services.AddHangfire(configuration => configuration
                .UseFilter(new AutomaticRetryAttribute { Attempts = 0 })

                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionstring, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer(options =>
            {
                options.WorkerCount = 50;
                options.ServerName = serverName;
                options.Queues = new[] { serverName.ToLower() };
            });

            return services;
        }
    }
}
