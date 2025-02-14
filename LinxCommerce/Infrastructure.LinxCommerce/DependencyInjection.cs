using Application.LinxCommerce.Interfaces;
using Application.LinxCommerce.Services;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;
using Domain.LinxCommerce.Interfaces.Repositorys.Order;
using Domain.LinxCommerce.Interfaces.Repositorys.SalesRepresentative;
using Domain.LinxCommerce.Interfaces.Repositorys.SKU;
using Infrastructure.LinxCommerce.Api;
using Infrastructure.LinxCommerce.Repository;
using Infrastructure.LinxCommerce.Repository.Base;
using Infrastructure.LinxCommerce.Repositorys.Order;
using Infrastructure.LinxCommerce.Repositorys.SalesRepresentative;
using Infrastructure.LinxCommerce.Repositorys.SKU;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.LinxCommerce.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedLinxCommerceServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxCommerceRepositoryBase, LinxCommerceRepositoryBase>();
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("LinxCommerceAPI", client =>
            {
                client.BaseAddress = new Uri("https://misha.layer.core.dcg.com.br");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();

            //services.AddScoped<IProductService<SearchProductResponse.Root>, ProductService<SearchProductResponse.Root>>();
            //services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ISKUService, SKUService>();
            services.AddScoped<ISKURepository, SKURepository>();

            services.AddScoped<ISalesRepresentativeService, SalesRepresentativeService>();
            services.AddScoped<ISalesRepresentativeRepository, SalesRepresentativeRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
