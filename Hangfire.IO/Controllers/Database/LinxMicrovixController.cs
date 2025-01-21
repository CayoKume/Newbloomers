using Application.DatabaseInit.Interfaces;
using Domain.DatabaseInit.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Database
{
    [ApiController]
    [Route("DatabaseInit/LinxMicrovix")]
    public class LinxMicrovixController : Controller
    {
        private readonly Parameter _parameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;
        private readonly ILinxMicrovixService _linxMicrovixService;

        public LinxMicrovixController(
            IConfiguration configuration,
            ILinxMicrovixService linxMicrovixService
        )
        {
            _linxMicrovixService = linxMicrovixService;
            _configuration = configuration;

            _parameter = new Parameter(
                databaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("LinxMicrovix")
                                .Value,

                untreatedDatabaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("Untreated")
                                .Value,

                parametersTableName: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ParametersTableName")
                                .Value
            );

            _methods = _configuration
                        .GetSection("LinxMicrovix")
                        .GetSection("Methods")
                        .Get<List<LinxMethods>>();
        }

        [HttpPost("CreateTablesIfNotExists")]
        public async Task<ActionResult> CreateTablesIfNotExists()
        {
            await _linxMicrovixService.CreateTablesIfNotExists(_parameter, _methods);

            return Ok($"Tables created successfully.");
        }

        [HttpPost("CreateTablesMerges")]
        public async Task<ActionResult> CreateTablesMerges()
        {
            await _linxMicrovixService.CreateTablesMerges(_parameter, _methods);

            return Ok($"Tables merges created successfully.");
        }

        [HttpPost("InsertParametersIfNotExists")]
        public async Task<ActionResult> InsertParametersIfNotExists()
        {
            await _linxMicrovixService.InsertParametersIfNotExists(_parameter, _methods);

            return Ok($"Parameters created successfully.");
        }
    }
}
