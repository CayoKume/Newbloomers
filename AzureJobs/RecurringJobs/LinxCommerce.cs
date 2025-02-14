using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs
{
    public class LinxCommerce
    {
        private readonly LinxCommerceJobParameter _linxCommerceJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly ISalesRepresentativeService _salesRepresentativeService;
        private readonly IOrderService _orderService;
        private readonly ISKUService _skuService;

        public LinxCommerce(
            IConfiguration configuration,
            IOrderService orderService,
            ISalesRepresentativeService salesRepresentativeService,
            ISKUService skuService
        )
        {
            _configuration = configuration;
            _skuService = skuService;
            _orderService = orderService;
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
        }

        //public async Task SearchOrders([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "SearchOrders")
        //            .FirstOrDefault();

        //        var result = await _orderService.SearchOrders(
        //            _linxCommerceJobParameter.SetParameters(
        //                jobName: method.MethodName,
        //                tableName: method.MethodName
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
