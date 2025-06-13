using Application.Dootax.Interfaces;
using Application.Dootax.Services;
using Domain.Dootax.Interfaces.Apis;
using Domain.Dootax.Interfaces.Repositorys;
using Infrastructure.Dootax.Api;
using Infrastructure.Dootax.Repositorys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Dootax.Data;

namespace Infrastructure.Dootax
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedDootaxServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("DootaxAPI", client =>
            {
                //HOMOLOG
                //https://hom.app.dootax.com.br

                client.BaseAddress = new Uri("https://app.dootax.com.br");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IDootaxService, DootaxService>();
            services.AddScoped<IDootaxRepository, DootaxRepository>();

            return services;
        }

        public static IServiceCollection AddDbContextDootaxService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<DootaxTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });

                services.AddDbContext<DootaxUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<DootaxTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });

                services.AddDbContext<DootaxUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<DootaxTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });

                services.AddDbContext<DootaxUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
