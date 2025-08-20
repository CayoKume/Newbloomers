using Application.AfterSale.Services;
using Application.AfterSale.Interfaces.Api;
using Domain.AfterSale.Interfaces.Repositorys;
using Infrastructure.AfterSale.Api;
using Infrastructure.AfterSale.Data;
using Infrastructure.AfterSale.Repositorys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Application.AfterSale.Interfaces.Services;
using FluentValidation;
using Application.AfterSale.Validations;

namespace Infrastructure.AfterSale.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedAfterSaleServices(this IServiceCollection services)
        {
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("AfterSaleAPI", client =>
            {
                client.BaseAddress = new Uri("https://api.send4.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IAfterSaleService, AfterSaleService>();
            services.AddScoped<IAfterSaleRepository, AfterSaleRepository>();

            services.AddValidatorsFromAssemblyContaining<AfterSaleEcommerceValidator>();

            return services;
        }

        public static IServiceCollection AddDbContextAfterSaleService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<AfterSaleTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });

                services.AddDbContext<AfterSaleUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<AfterSaleTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });

                services.AddDbContext<AfterSaleUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<AfterSaleTreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });

                services.AddDbContext<AfterSaleUntreatedDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
