using Application.DatabaseInit.Interfaces;
using Domain.DatabaseInit.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Database
{
    [ApiController]
    [Route("DatabaseInit/B2CLinxMicrovix")]
    public class B2CLinxMicrovixController : Controller
    {
        private readonly Parameter _parameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;
        private readonly IB2CLinxMicrovixService _b2cLinxMicrovixService;

        public B2CLinxMicrovixController(
            IConfiguration configuration,
            IB2CLinxMicrovixService b2cLinxMicrovixService
        )
        {
            _b2cLinxMicrovixService = b2cLinxMicrovixService;
            _configuration = configuration;

            _parameter = new Parameter(
                databaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("LinxMicrovixCommerce")
                                .Value,

                untreatedDatabaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("Untreated")
                                .Value,

                parametersTableName: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("ParametersTableName")
                                .Value
            );

            _methods = _configuration
                        .GetSection("B2CLinxMicrovix")
                        .GetSection("Methods")
                        .Get<List<LinxMethods>>();
        }

        [HttpPost("CreateTablesIfNotExists")]
        public async Task<ActionResult> CreateTablesIfNotExists()
        {
            await _b2cLinxMicrovixService.CreateTablesIfNotExists(_parameter, _methods);

            return Ok($"Tables created successfully.");
        }

        [HttpPost("CreateTablesMerges")]
        public async Task<ActionResult> CreateTablesMerges()
        {
            await _b2cLinxMicrovixService.CreateTablesMerges(_parameter, _methods);

            return Ok($"Tables merges created successfully.");
        }

        [HttpPost("InsertParametersIfNotExists")]
        public async Task<ActionResult> InsertParametersIfNotExists()
        {
            await _b2cLinxMicrovixService.InsertParametersIfNotExists(_parameter, _methods);

            return Ok($"Parameters created successfully.");
        }
    }
}
