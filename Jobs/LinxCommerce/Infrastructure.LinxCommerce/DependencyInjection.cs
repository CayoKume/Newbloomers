﻿using Application.LinxCommerce.Interfaces;
using Application.LinxCommerce.Services;
using Domain.LinxCommerce.CustomValidations.Customer;
using Domain.LinxCommerce.CustomValidations.Order;
using Domain.LinxCommerce.CustomValidations.Product;
using Domain.LinxCommerce.CustomValidations.SalesRepresentative;
using Domain.LinxCommerce.CustomValidations.Sku;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys;
using FluentValidation;
using Infrastructure.LinxCommerce.Api;
using Infrastructure.LinxCommerce.Repository;
using Infrastructure.LinxCommerce.Repositorys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.LinxCommerce.Data;

namespace Infrastructure.LinxCommerce.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedLinxCommerceServices(this IServiceCollection services)
        {
            services.AddScopedLinxCommerceValidations();

            services.AddScoped<ILinxCommerceRepositoryBase, LinxCommerceRepositoryBase>();
            services.AddScoped<IAPICall, APICall>();
            services.AddHttpClient("LinxCommerceAPI", client =>
            {
                client.BaseAddress = new Uri("https://misha.layer.core.dcg.com.br");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

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

        private static IServiceCollection AddScopedLinxCommerceValidations(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            services.AddValidatorsFromAssemblyContaining<VideoValidator>();
            services.AddValidatorsFromAssemblyContaining<ImageValidator>();
            services.AddValidatorsFromAssemblyContaining<MediaAssociationValidator>();
            services.AddValidatorsFromAssemblyContaining<MidiaValidator>();

            services.AddValidatorsFromAssemblyContaining<SkuValidator>();
            services.AddValidatorsFromAssemblyContaining<Domain.LinxCommerce.CustomValidations.Sku.MetadataValueValidator>();
            services.AddValidatorsFromAssemblyContaining<ParentRelationValidator>();

            services.AddValidatorsFromAssemblyContaining<PersonValidator>();
            services.AddValidatorsFromAssemblyContaining<ContactValidator>();
            services.AddValidatorsFromAssemblyContaining<EmailConfirmationValidator>();
            services.AddValidatorsFromAssemblyContaining<GroupsValidator>();
            services.AddValidatorsFromAssemblyContaining<PersonAddressValidator>();

            services.AddValidatorsFromAssemblyContaining<OrderValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderTagValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderShipmentValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderPaymentMethodValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderPaymentInfoValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderItemValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderInvoiceValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderDiscountValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderDeliveryMethodValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderAddressValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderSellerValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderMultiSiteTenantValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderTypeValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderStatusValidator>();

            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeAddressValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeComissionValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeContactDataValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeIdentificationValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeMaxDiscountValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativePortfolioValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeShippingRegionValidator>();
            services.AddValidatorsFromAssemblyContaining<SalesRepresentativeWebSiteSettingsValidator>();

            return services;
        }

        public static IServiceCollection AddDbContextLinxCommerceService(this IServiceCollection services, string databaseType, string connectionstring)
        {
            if (databaseType == "SQLServer")
            {
                services.AddDbContext<LinxCommerceDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseSqlServer(connectionstring);
                });
            }

            if (databaseType == "MySql")
            {
                services.AddDbContext<LinxCommerceDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseMySQL(connectionstring);
                });
            }

            if (databaseType == "Postgree")
            {
                services.AddDbContext<LinxCommerceDbContext>((serviceProvider, options) =>
                {
                    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                    options.UseNpgsql(connectionstring);
                });
            }

            return services;
        }
    }
}
