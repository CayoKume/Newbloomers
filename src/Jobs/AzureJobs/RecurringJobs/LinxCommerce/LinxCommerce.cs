using Application.Core.Middlewares;
using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs.LinxCommerce
{
    public class LinxCommerce
    {
        private readonly WebJobExceptionHandlingMiddleware _webJobExceptionHandlingMiddleware;
        private readonly LinxCommerceJobParameter _linxCommerceJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly ISalesRepresentativeService _salesRepresentativeService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly ISKUService _skuService;

        public LinxCommerce(
            IConfiguration configuration,
            IServiceProvider services,
            IOrderService orderService,
            ICustomerService customerService,
            ISalesRepresentativeService salesRepresentativeService,
            ISKUService skuService
        )
        {
            _configuration = configuration;
            _skuService = skuService;
            _orderService = orderService;
            _customerService = customerService;
            _salesRepresentativeService = salesRepresentativeService;

            _linxCommerceJobParameter = new LinxCommerceJobParameter(
                docMainCompany: _configuration
                                .GetSection("LinxCommerce")
                                .GetSection("DocMainCompany")
                                .Value,

                schema: "linx_commerce",

                databaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("LinxCommerce")
                                .Value,

                untreatedDatabaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("Untreated")
                                .Value,

                projectName: _configuration
                                .GetSection("LinxCommerce")
                                .GetSection("ProjectName")
                                .Value,

                parametersInterval: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ParametersDateInterval")
                                .Value,

                parametersTableName: _configuration
                                .GetSection("LinxCommerce")
                                .GetSection("ParametersTableName")
                                .Value,

                keyAuthorization: _configuration
                                .GetSection("LinxCommerce")
                                .GetSection("Key")
                                .Value,

                userAuthentication: _configuration
                                .GetSection("LinxCommerce")
                                .GetSection("Authentication")
                                .Value
            );

            _methods = _configuration
                            .GetSection("LinxCommerce")
                            .GetSection("Methods")
                            .Get<List<LinxMethods>>();

            _webJobExceptionHandlingMiddleware = new WebJobExceptionHandlingMiddleware(services);
        }

        // public async Task SearchOrders([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        // {
        //     await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //     {
        //         var method = _methods
        //             .Where(m => m.MethodName == "SearchOrders")
        //             .FirstOrDefault();

        //         var result = await _orderService.SearchOrdersByDateInterval(
        //             _linxCommerceJobParameter.SetParameters(
        //                 jobName: method.MethodName,
        //                 tableName: method.MethodName
        //             )
        //         );
        //     });
        // }

        // public async Task SearchProductsByQueue([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        // {
        //     await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //     {
        //         var method = _methods
        //             .Where(m => m.MethodName == "SearchProducts")
        //             .FirstOrDefault();

        //         var result = await _skuService.SearchProductByQueue(
        //             _linxCommerceJobParameter.SetParameters(
        //                 jobName: method.MethodName,
        //                 tableName: method.MethodName
        //             )
        //         );
        //     });
        // }

        // public async Task SearchSKUsByQueue([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        // {
        //     await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //     {
        //         var method = _methods
        //             .Where(m => m.MethodName == "SearchSKU")
        //             .FirstOrDefault();

        //         var result = await _skuService.SearchSKUByQueue(
        //             _linxCommerceJobParameter.SetParameters(
        //                 jobName: method.MethodName,
        //                 tableName: method.MethodName
        //             )
        //         );
        //     });
        // }

        // public async Task SearchOrdersByQueue([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        // {
        //     await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //     {
        //         var method = _methods
        //             .Where(m => m.MethodName == "SearchOrders")
        //             .FirstOrDefault();

        //         var result = await _orderService.SearchOrdersByQueue(
        //             _linxCommerceJobParameter.SetParameters(
        //                 jobName: method.MethodName,
        //                 tableName: method.MethodName
        //             )
        //         );
        //     });
        // }

        // public async Task SearchCustomerByQueue([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        // {
        //     await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //     {
        //         var method = _methods
        //             .Where(m => m.MethodName == "SearchCustomer")
        //             .FirstOrDefault();

        //         var result = await _customerService.SearchCustomerByQueue(
        //             _linxCommerceJobParameter.SetParameters(
        //                 jobName: method.MethodName,
        //                 tableName: method.MethodName
        //             )
        //         );
        //     });
        // }

        // public async Task SearchSalesRepresentative([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        // {
        //     await _webJobExceptionHandlingMiddleware.ExecuteAsync(async () =>
        //     {
        //         var method = _methods
        //             .Where(m => m.MethodName == "SearchSalesRepresentative")
        //             .FirstOrDefault();

        //         var result = await _salesRepresentativeService.SearchSalesRepresentative(
        //             _linxCommerceJobParameter.SetParameters(
        //                 jobName: method.MethodName,
        //                 tableName: method.MethodName
        //             )
        //         );
        //     });
        // }
    }
}
