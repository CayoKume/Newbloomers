using Application.Movidesk.Interfaces;
using Application.Movidesk.Services;
using Domain.Movidesk.Interfaces.Apis;
using Domain.Movidesk.Interfaces.Repositorys;
using Infrastructure.Movidesk.Api;
using Infrastructure.Movidesk.Data;
using Infrastructure.Movidesk.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Movidesk
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedMovideskServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("MovideskAPI", client =>
            {
                client.BaseAddress = new Uri("https://api.movidesk.com/public/v1/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IMovideskService, MovideskService>();
            services.AddScoped<IMovideskRepository, MovideskRepository>();

            return services;
        }

        public static IServiceCollection AddDbContextMovideskService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<MovideskTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });

                services.AddDbContext<MovideskUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<MovideskTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });

                services.AddDbContext<MovideskUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<MovideskTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });

                services.AddDbContext<MovideskUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
