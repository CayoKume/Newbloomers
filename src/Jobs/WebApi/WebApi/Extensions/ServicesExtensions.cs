using Application.Core.Interfaces;
using Application.Core.Services;
using Domain.Core.Interfaces;
using Hangfire.SqlServer;
using Infrastructure.FlashCourier.DependencyInjection;
using Infrastructure.Core.DependencyInjection;
using Infrastructure.LinxCommerce.DependencyInjection;
using Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection;
using Infrastructure.TotalExpress.DependencyInjection;
using Infrastructure.AfterSale.DependencyInjection;
using Infrastructure.Jadlog.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Dootax;
using Infrastructure.Movidesk;
using FluentValidation;
using System.Reflection;
using Infrastructure.Movidesk.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;
using Infrastructure.Stone;

namespace Hangfire.IO.Extensions
{
    public static class ServicesExtensions
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScopedCoreServices();

            builder.Services.AddScopedLinxCommerceServices();
            builder.Services.AddScopedLinxMicrovixServices();
            builder.Services.AddScopedB2CLinxMicrovixServices();
            builder.Services.AddScopedFlashCourierServices();
            builder.Services.AddScopedTotalExpressServices();
            builder.Services.AddScopedAfterSaleServices();
            builder.Services.AddScopedJadlogServices();
            builder.Services.AddScopedStoneServices();
            builder.Services.AddScopedDootaxServices();
            builder.Services.AddScopedMovideskServices();

            //Refatorar Aqui (tentar deixar só em uma linha todas as validações da fluent validation)
            builder.Services.AddValidatorsFromAssembly(Assembly.Load("Application.LinxMicrovix.Outbound.WebService"));

            builder.Services.AddDbContextService(builder);
            //builder.Services.AddHangfireService(builder);

            return builder;
        }

        public static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var databaseType = builder.Configuration.GetSection("ConfigureServer").GetSection("DatabaseType").Value;
            var connectionstring = builder.Configuration.GetConnectionString("Connection");

            builder.Services.AddDbContextAfterSaleService(databaseType, connectionstring);
            builder.Services.AddDbContextMovideskService(databaseType, connectionstring);
            builder.Services.AddDbContextDootaxService(databaseType, connectionstring);
            //builder.Services.AddDbContextLinxCommerceService(databaseType, connectionstring);
            builder.Services.AddDbContextLinxMicrovixService(databaseType, connectionstring);
            //builder.Services.AddDbContextFlashCourierService(databaseType, connectionstring);
            //builder.Services.AddDbContextJadlogService(databaseType, connectionstring);
            //builder.Services.AddDbContextTotalExpressService(databaseType, connectionstring);

            return services;
        }

        public static IServiceCollection AddHangfireService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var serverName = builder.Configuration.GetSection("ConfigureServer").GetSection("ServerName").Value;
            var databaseName = builder.Configuration.GetSection("ConfigureServer").GetSection("GeneralDatabaseName").Value;
            var connectionstring = builder.Configuration.GetConnectionString("Connection").Replace("[catalog]", databaseName).Replace("[database]", databaseName);

            services
                .AddHangfire(configuration => configuration
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
