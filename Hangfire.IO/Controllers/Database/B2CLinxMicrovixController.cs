using Application.DatabaseInit.Interfaces;
using Domain.IntegrationsCore.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Database
{
    [ApiController]
    [Route("DatabaseInit/B2CLinxMicrovix")]
    public class B2CLinxMicrovixController : Controller
    {
        private readonly LinxMicrovixJobParameter _linxMicrovixJobParameter;
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

            _linxMicrovixJobParameter = new LinxMicrovixJobParameter(
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

                projectName: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("ProjectName")
                                .Value,

                userAuthentication: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("Authentication")
                                .Value,

                keyAuthorization: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("Key")
                                .Value,

                parametersInterval: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("ParametersDateInterval")
                                .Value,

                parametersTableName: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("ParametersTableName")
                                .Value,

                docDocMainCompany: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("DocMainCompany")
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
            _b2cLinxMicrovixService.CreateTablesIfNotExists(_linxMicrovixJobParameter, _methods);

            return Ok($"Tables created successfully.");
        }

        [HttpPost("CreateTablesMerges")]
        public async Task<ActionResult> CreateTablesMerges()
        {
            _b2cLinxMicrovixService.CreateTablesMerges(_linxMicrovixJobParameter, _methods);

            return Ok($"Tables merges created successfully.");
        }

        [HttpPost("InsertParametersIfNotExists")]
        public async Task<ActionResult> InsertParametersIfNotExists()
        {
            throw new NotImplementedException();
        }
    }
}
