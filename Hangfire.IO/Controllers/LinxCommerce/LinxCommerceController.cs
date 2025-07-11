﻿using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
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
        private readonly ICustomerService _customerService;
        private readonly ISalesRepresentativeService _salesRepresentativeService;
        private readonly IOrderService _orderService;
        private readonly ISKUService _skuService;

        public LinxCommerceController(
            IConfiguration configuration,
            ICustomerService customerService,
            IOrderService orderService,
            ISalesRepresentativeService salesRepresentativeService,
            ISKUService skuService
        )
        {
            _configuration = configuration;
            _customerService = customerService;
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

        [HttpPost("SearchSkusByDateInterval")]
        public async Task<ActionResult> SearchSkusByDateInterval()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchSKU")
                    .FirstOrDefault();

                var result = await _skuService.SearchSKUByDateInterval(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("SearchSkusByQueue")]
        public async Task<ActionResult> SearchSkusByQueue()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchSKU")
                    .FirstOrDefault();

                var result = await _skuService.SearchSKUByQueue(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("SearchProductsByDateInterval")]
        public async Task<ActionResult> SearchProductsByDateInterval()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchProducts")
                    .FirstOrDefault();

                var result = await _skuService.SearchProductByDateInterval(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("SearchProductsByQueue")]
        public async Task<ActionResult> SearchProductsByQueue()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchProducts")
                    .FirstOrDefault();

                var result = await _skuService.SearchProductByQueue(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("SearchOrdersByDateInterval")]
        public async Task<ActionResult> SearchOrdersByDateInterval()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchOrders")
                    .FirstOrDefault();

                var result = await _orderService.SearchOrdersByDateInterval(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("SearchOrdersByQueue")]
        public async Task<ActionResult> SearchOrdersByQueue()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchOrders")
                    .FirstOrDefault();

                var result = await _orderService.SearchOrdersByQueue(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
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
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
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

                if (result == true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("SearchCustomerByDateInterval")]
        public async Task<ActionResult> SearchCustomerByDateInterval()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchCustomer")
                    .FirstOrDefault();

                var result = await _customerService.SearchCustomerByDateInterval(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: "Customer"
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("SearchCustomerByQueue")]
        public async Task<ActionResult> SearchCustomerByQueue()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SearchCustomer")
                    .FirstOrDefault();

                var result = await _customerService.SearchCustomerByQueue(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: "Customer"
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }

        [HttpPost("UpdateTrackingNumberOrder")]
        public async Task<ActionResult> UpdateTrackingNumberOrder()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "UpdateTrackingNumberOrder")
                    .FirstOrDefault();

                var result = await _orderService.UpdateTrackingNumberOrder(
                    _linxCommerceJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: "UpdateTrackingNumberOrder"
                    )
                );

                if (result != true)
                    return BadRequest($"Unable to find records on endpoint.");
                else
                    return Ok($"Records integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the records.\n//error: {ex.Message}");
            }
        }
    }
}
