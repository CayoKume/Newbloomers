using Application.LinxCommerce.Interfaces.Catolog;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HangfireDashboard.UI.Controllers.LinxCommerce
{
    [ApiController]
    [Route("LinxCommerceJobs/LinxCommerceIndividual")]
    public class LinxCommerceIndividualController : Controller
    {
        private readonly string? _projectName;
        private readonly string? _parametersTableName;
        private readonly string? _parametersLogTableName;
        private readonly string? _key;
        private readonly string? _authentication;
        private readonly string? _databaseName;
        private readonly List<LinxMethods>? _methods;

        private readonly IConfiguration _configuration;
        private readonly ISKUService _skuService;

        public LinxCommerceIndividualController(
            IConfiguration configuration,
            ISKUService skuService
        )
        {
            _configuration = configuration;
            _skuService = skuService;

            _projectName = _configuration
                .GetSection("LinxCommerce")
                .GetSection("ProjectName")
                .Value;

            _parametersLogTableName = _configuration
                .GetSection("LinxCommerce")
                .GetSection("ProjectParametersLogTableName")
                .Value;

            _parametersTableName = _configuration
                .GetSection("LinxCommerce")
                .GetSection("ProjectParametersTableName")
                .Value;

            _key = _configuration
                .GetSection("LinxCommerce")
                .GetSection("Key")
                .Value;

            _authentication = _configuration
                .GetSection("LinxCommerce")
                .GetSection("Authentication")
                .Value;

            _databaseName = _configuration
                 .GetSection("ConfigureServer")
                 .GetSection("LinxCommerceDatabaseName")
                 .Value;

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
            //catch (Exception ex)
            //{
            //    Response.StatusCode = 400;
            //    return Content($"Unable to integrate the record: {orderId}.\nError: {ex.Message}");
            //}
        }

        [HttpPost("GetSKU")]
        public async Task<ActionResult> GetSKU([Required][FromQuery] int productId)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "SKU")
                    .FirstOrDefault();

                var result = await _skuService.GetSKU(
                    new LinxCommerceJobParameter
                    {
                        projectName = _projectName,
                        databaseName = _databaseName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        jobName = method.MethodName,
                        tableName = method.MethodName,
                    },
                    productID: productId
                );

                if (result != true)
                    return BadRequest($"Unable to find record: {productId} on endpoint.");
                else
                    return Ok($"Record: {productId} integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the record: {productId}.\nError: {ex.Message}");
            }
        }
    }
}
