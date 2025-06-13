using Application.Stone.Interfaces;
using Application.Stone.Services;
using Domain.Stone.Interfaces.Api;
using Domain.Stone.Interfaces.Repository;
using Infrastructure.Stone.Api;
using Infrastructure.Stone.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Stone.Data;

namespace Infrastructure.Stone
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedStoneServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("StoneAPI", client =>
            {
                client.BaseAddress = new Uri("https://stg-entrega.stone.com.br/api/smart-logistic-gateway/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IStoneService, StoneService>();
            services.AddScoped<IStoneRepository, StoneRepository>();

            return services;
        }

        public static IServiceCollection AddDbContextStoneService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<StoneTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });

                services.AddDbContext<StoneUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<StoneTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });

                services.AddDbContext<StoneUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<StoneTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });

                services.AddDbContext<StoneUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
