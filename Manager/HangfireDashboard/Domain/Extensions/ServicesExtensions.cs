using Hangfire;
using Hangfire.SqlServer;
using Infrastructure.LinxMicrovix.Outbound.WebService;

namespace HangfireDashboard.Domain.Extensions
{
    public static class ServicesExtensions
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            var serverName = builder.Configuration.GetSection("ConfigureServer").GetSection("ServerName").Value;
            var connectionstring = builder.Configuration.GetConnectionString("Connection").Replace("[catalog]", "GENERAL").Replace("[database]", "GENERAL");

            builder.Services.AddScopedSQLServerConnection();

            //builder.Services.AddScopedLinxCommerceServices();
            //builder.Services.AddScopedLinxMicrovixServices();
            builder.Services.AddScopedB2CLinxMicrovixServices();
            //builder.Services.AddScopedFlashCourierServices();
            //builder.Services.AddScopedTotalExpressServices();

            builder.Services.AddHangfireService(connectionstring, serverName);

            return builder;
        }

        //public static IServiceCollection AddScopedLinxCommerceServices(this IServiceCollection services)
        //{
        //    services.AddScoped(typeof(ILinxCommerceRepositoryBase<>), typeof(LinxCommerceRepositoryBase<>));
        //    services.AddScoped<LinxCommerce.Infrastructure.Api.IAPICall, LinxCommerce.Infrastructure.Api.APICall>();
        //    services.AddHttpClient("LinxCommerceAPI", client =>
        //    {
        //        client.BaseAddress = new Uri("https://misha.layer.core.dcg.com.br");
        //        client.Timeout = new TimeSpan(0, 20, 0);
        //    });

        //    services.AddScoped<ISKUService, SKUService>();
        //    services.AddScoped<ISKURepository, SKURepository>();

        //    return services;
        //}

        //public static IServiceCollection AddScopedLinxMicrovixServices(this IServiceCollection services)
        //{
        //    services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
        //    services.AddScoped(typeof(ILinxMicrovixRepositoryBase<>), typeof(LinxMicrovixRepositoryBase<>));
        //    services.AddScoped<LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.IAPICall, LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.APICall>();

        //    services.AddScoped<ILinxVendedoresService, LinxVendedoresService>();
        //    services.AddScoped<ILinxVendedoresRepository, LinxVendedoresRepository>();

        //    services.AddScoped<ILinxProdutosCodBarService, LinxProdutosCodBarService>();
        //    services.AddScoped<ILinxProdutosCodBarRepository, LinxProdutosCodBarRepository>();

        //    return services;
        //}



        //public static IServiceCollection AddScopedTotalExpressServices(this IServiceCollection services)
        //{
        //    services.AddScoped<TotalExpress.Infrastructure.Api.IAPICall, TotalExpress.Infrastructure.Api.APICall>();
        //    services.AddHttpClient("TotalExpressAPI", client =>
        //    {
        //        client.BaseAddress = new Uri("https://apis.totalexpress.com.br/");
        //        client.Timeout = new TimeSpan(0, 20, 0);
        //    });
        //    services.AddHttpClient("TotalExpressEdiAPI", client =>
        //    {
        //        client.BaseAddress = new Uri("https://edi.totalexpress.com.br/");
        //        client.Timeout = new TimeSpan(0, 20, 0);
        //    });

        //    services.AddScoped<ITotalExpressService, TotalExpressService>();
        //    services.AddScoped<ITotalExpressRepository, TotalExpressRepository>();

        //    return services;
        //}

        //public static IServiceCollection AddScopedFlashCourierServices(this IServiceCollection services)
        //{
        //    services.AddScoped<FlashCourier.Infrastructure.Api.IAPICall, FlashCourier.Infrastructure.Api.APICall>();
        //    services.AddHttpClient("FlashCourierAPI", client =>
        //    {
        //        //HOMOLOG
        //        //client.BaseAddress = new Uri("https://homolog.flashpegasus.com.br/FlashPegasus/rest");

        //        client.BaseAddress = new Uri("https://webservice.flashpegasus.com.br/FlashPegasus/rest");
        //        client.Timeout = new TimeSpan(0, 20, 0);
        //    });

        //    services.AddScoped<IFlashCourierService, FlashCourierService>();
        //    services.AddScoped<IFlashCourierRepository, FlashCourierRepository>();

        //    return services;
        //}

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
