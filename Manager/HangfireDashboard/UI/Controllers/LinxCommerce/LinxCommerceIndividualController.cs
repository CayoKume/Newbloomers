using HangfireDashboard.Domain.Entites;
using IntegrationsCore.Domain.Entities.Parameters;
using LinxCommerce.Application.Services.Sales;
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
        private readonly List<Method>? _methods;

        private readonly IConfiguration _configuration;
        private readonly ISalesService _salesService;

        public LinxCommerceIndividualController(
            IConfiguration configuration,
            ISalesService salesService    
        )
        {
            _configuration = configuration;
            _salesService = salesService;

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
        }

        [HttpPost("GetOrder")]
        public async Task<ActionResult> GetOrder([Required][FromQuery] string? orderId)
        {
            try
            {
                var result = await _salesService.GetOrder(
                    new LinxCommerceJobParameter
                    {
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,

                        jobName = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("B2CConsultaClassificacao")
                            .GetSection("MethodName")
                            .Value,

                        tableName = "_" + _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("B2CConsultaClassificacao")
                            .GetSection("MethodName")
                            .Value,
                    },
                    orderId: orderId
                );

                if (result != true)
                    return BadRequest($"Unable to find record: {orderId} on endpoint.");
                else
                    return Ok($"Record: {orderId} integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the record: {orderId}.\nError: {ex.Message}");
            }
        }
    }
}
