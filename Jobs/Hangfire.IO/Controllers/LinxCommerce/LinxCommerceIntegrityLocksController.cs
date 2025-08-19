using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.LinxCommerce
{
#if DEBUG
    [ApiController]
    [Route("LinxCommerceJobs/LinxCommerceIntegrityLocks")]
    public class LinxCommerceIntegrityLocksController : Controller
    {
        private readonly LinxCommerceJobParameter _linxCommerceJobParameter;
        private readonly List<LinxMethods>? _methods;

        private readonly IConfiguration _configuration;
        private readonly ICustomerService _customerService;
        private readonly ISalesRepresentativeService _salesRepresentativeService;
        private readonly IOrderService _orderService;
        private readonly ISKUService _skuService;

        public LinxCommerceIntegrityLocksController(
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

        [HttpPost("IntegrityLockOrderItem")]
        public async Task<ActionResult> IntegrityLockOrdersRegisters()
        {
            var result = await _orderService.IntegrityLockOrdersRegisters(
                _linxCommerceJobParameter.SetParameters(
                    jobName: "IntegrityLockOrdersRegisters",
                    tableName: "Orders"
                )
            );

            return Ok($"Records integrated successfully.");
        }
    } 
#endif
}
