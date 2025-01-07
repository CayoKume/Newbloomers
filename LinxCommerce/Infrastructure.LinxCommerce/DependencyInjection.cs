using Application.LinxCommerce.Interfaces.Catolog;
using Application.LinxCommerce.Services.Catolog;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;
using Domain.LinxCommerce.Interfaces.Repositorys.Catolog;
using Infrastructure.LinxCommerce.Api;
using Infrastructure.LinxCommerce.Repository.Base;
using Infrastructure.LinxCommerce.Repositorys.Catolog;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.LinxCommerce.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedLinxCommerceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILinxCommerceRepositoryBase<>), typeof(LinxCommerceRepositoryBase<>));
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("LinxCommerceAPI", client =>
            {
                client.BaseAddress = new Uri("https://misha.layer.core.dcg.com.br");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IOrderRepository, OrderRepository>();

            //services.AddScoped<IProductService<SearchProductResponse.Root>, ProductService<SearchProductResponse.Root>>();
            //services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ISKUService, SKUService>();
            services.AddScoped<ISKURepository, SKURepository>();

            //services.AddScoped<ISalesRepresentativeService, SalesRepresentativeService>();

            return services;
        }
    }
}
