using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDashboard.UI.Controllers.LinxCommerce
{
    [ApiController]
    [Route("LinxCommerceJobs/LinxCommerce")]
    public class LinxCommerceController : Controller
    {
        private readonly LinxCommerceJobParameter _linxCommerceJobParameter;
        private readonly List<LinxMethods>? _methods;

        private readonly IConfiguration _configuration;
        private readonly ISalesRepresentativeService _salesRepresentativeService;
        private readonly IOrderService _orderService;
        private readonly ISKUService _skuService;

        public LinxCommerceController(
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

        [HttpPost("SearchOrders")]
        public async Task<ActionResult> SearchOrders()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchOrders")
                    .FirstOrDefault();

                var result = await _orderService.SearchOrders(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
                );

                if (result == "true")
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("SearchOrderStatus")]
        public async Task<ActionResult> SearchOrderStatus()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchOrderStatus")
                    .FirstOrDefault();

                var result = await _orderService.SearchOrderStatus(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: "OrderStatus"
                    )
                );

                if (result == "true")
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("SearchSalesRepresentative")]
        public async Task<ActionResult> SearchSalesRepresentative()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchSalesRepresentative")
                    .FirstOrDefault();

                var result = await _salesRepresentativeService.SearchSalesRepresentative(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: "SaleRepresentative"
                    )
                );

                if (result == "true")
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }
    }
}
