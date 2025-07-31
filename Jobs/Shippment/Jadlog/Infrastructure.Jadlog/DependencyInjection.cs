using Application.Jadlog.Interfaces;
using Application.Jadlog.Services;
using Domain.Jadlog.CustomValidations;
using Domain.Jadlog.Interfaces.Api;
using Domain.Jadlog.Interfaces.Repositorys;
using FluentValidation;
using Infrastructure.Jadlog.Api;
using Infrastructure.Jadlog.Repositorys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Jadlog.Data;

namespace Infrastructure.Jadlog.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedJadlogServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("JadlogAPI", client =>
            {
                client.BaseAddress = new Uri("https://www.jadlog.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });
            services.AddHttpClient("JadlogTechAPI", client =>
            {
                client.BaseAddress = new Uri("https://prd-traffic.jadlogtech.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddValidatorsFromAssemblyContaining<ConsultaValidator>();
            services.AddValidatorsFromAssemblyContaining<EventoValidator>();
            services.AddValidatorsFromAssemblyContaining<RecebedorValidator>();
            services.AddValidatorsFromAssemblyContaining<RootValidator>();
            services.AddValidatorsFromAssemblyContaining<TrackingValidator>();
            services.AddValidatorsFromAssemblyContaining<VolumeValidator>();

            services.AddScoped<IJadlogService, JadlogService>();
            services.AddScoped<IJadlogRepository, JadlogRepository>();

            return services;
        }

        public static IServiceCollection AddDbContextJadlogService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<JadlogDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<JadlogDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<JadlogDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
