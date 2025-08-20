using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HangfireDashboard.UI.Controllers.LinxCommerce
{
    [ApiController]
    [Route("LinxCommerceJobs/LinxCommerceIndividual")]
    public class LinxCommerceIndividualController : Controller
    {
        private readonly LinxCommerceJobParameter _linxCommerceJobParameter;
        private readonly List<LinxMethods>? _methods;

        private readonly IConfiguration _configuration;
        private readonly ISKUService _skuService;
        private readonly ICustomerService _customerService;

        public LinxCommerceIndividualController(
            IConfiguration configuration,
            ISKUService skuService,
            ICustomerService customerService
        )
        {
            _configuration = configuration;
            _skuService = skuService;
            _customerService = customerService;

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

        [HttpPost("GetOrder")]
        public async Task<ActionResult> GetOrder([Required][FromQuery] string? orderId)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var result = await _salesService.GetOrder(
            //        new LinxCommerceJobParameter
            //        {
            //            projectName = _projectName,
            //            keyAuthorization = _key,
            //            userAuthentication = _authentication,
            //            parametersTableName = _parametersTableName,
            //            parametersLogTableName = _parametersLogTableName,

            //            jobName = _configuration
            //                .GetSection("LinxMicrovix")
            //                .GetSection("B2CConsultaClassificacao")
            //                .GetSection("MethodName")
            //                .Value,

            //            tableName = "_" + _configuration
            //                .GetSection("LinxMicrovix")
            //                .GetSection("B2CConsultaClassificacao")
            //                .GetSection("MethodName")
            //                .Value,
            //        },
            //        orderId: orderId
            //    );

            //    if (result != true)
            //        return BadRequest($"Unable to find record: {orderId} on endpoint.");
            //    else
            //        return Ok($"Record: {orderId} integrated successfully.");
            //}
            //catch (ExceptionBase ex)
            //{
            //    Response.StatusCode = 400;
            //    return Content($"Unable to integrate the record: {orderId}.\n//error: {ex.Message}");
            //}
        }

        [HttpPost("GetCustomer")]
        public async Task<ActionResult> GetCustomer([Required][FromQuery] string? customerId)
        {
            var method = _methods
                .Where(m => m.MethodName == "SearchCustomer")
                .FirstOrDefault();

            var result = await _customerService.GetCustomer(
                _linxCommerceJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: "Customer"
                ),
                Identifier: customerId
            );

            return Ok($"Record: {customerId} integrated successfully.");
        }

        [HttpPost("GetSKU")]
        public async Task<ActionResult> GetSKU([Required][FromQuery] int productId)
        {
            var method = _methods
                .Where(m => m.MethodName == "SKU")
                .FirstOrDefault();

            var result = await _skuService.GetSKU(
                _linxCommerceJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                productID: productId
            );

            return Ok($"Record: {productId} integrated successfully.");
        }
    }
}
