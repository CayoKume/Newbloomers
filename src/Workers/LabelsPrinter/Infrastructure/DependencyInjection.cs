using LabelsPrinter.Application.Handlers.Commands;
using LabelsPrinter.Application.Interfaces.Handlers.Commands;
using LabelsPrinter.Application.Interfaces.Services;
using LabelsPrinter.Application.Services;
using LabelsPrinter.Domain.Interfaces;
using LabelsPrinter.Infrastructure.Repositorys;

namespace LabelsPrinter.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<ILabelsPrinterService, LabelsPrinterService>();
            services.AddScoped<ILabelsPrinterRepository, LabelsPrinterRepository>();
            services.AddScoped<ILabelsPrinterCommandHandler, LabelsPrinterCommandHandler>();

            return services;
        }
    }
}
