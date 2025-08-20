using Application.Movidesk.Interfaces.Services;
using Application.Movidesk.Services;
using Domain.Movidesk.Interfaces.Repositorys;
using Infrastructure.Movidesk.Data;
using Infrastructure.Movidesk.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using Application.Movidesk.CustomValidations.Person;
using Infrastructure.Movidesk.Api;
using Domain.Movidesk.Interfaces.Apis;

namespace Infrastructure.Movidesk.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedMovideskServices(this IServiceCollection services)
        {
            services.AddScopedMovideskValidations();

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

        private static IServiceCollection AddScopedMovideskValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<PersonValidator>();
            services.AddValidatorsFromAssemblyContaining<ContactValidator>();
            services.AddValidatorsFromAssemblyContaining<EmailValidator>();
            services.AddValidatorsFromAssemblyContaining<AddressValidator>();
            services.AddValidatorsFromAssemblyContaining<RelationshipValidator>();

            return services;
        }
        
        public static IServiceCollection AddDbContextMovideskService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<GeneralMovideskContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });

                services.AddDbContext<UntreatedMovideskContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<GeneralMovideskContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });

                services.AddDbContext<UntreatedMovideskContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<GeneralMovideskContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });

                services.AddDbContext<UntreatedMovideskContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
