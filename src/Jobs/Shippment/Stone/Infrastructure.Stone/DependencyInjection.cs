using Application.Stone.Handlers.Commands;
using Application.Stone.Interfaces.Handlers.Commands;
using Application.Stone.Interfaces.Services;
using Application.Stone.Services;
using Application.Stone.Validations;
using Domain.Stone.Interfaces.Api;
using Domain.Stone.Interfaces.Repository;
using FluentValidation;
using Infrastructure.Stone.Api;
using Infrastructure.Stone.Data;
using Infrastructure.Stone.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Stone
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedStoneServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("StoneAPI", client =>
            {
                //HOMOLOG
                //client.BaseAddress = new Uri("https://stg-entrega.stone.com.br/api/smart-logistic-gateway/");

                client.BaseAddress = new Uri("https://entrega.stone.com.br/api/smart-logistic-gateway/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IStoneService, StoneService>();
            services.AddScoped<IStoneRepository, StoneRepository>();
            services.AddScoped<IStoneLogisticaCommandHandler, StoneLogisticaCommandHandler>();

            services.AddValidatorsFromAssemblyContaining<StoneOrderValidator>();

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
