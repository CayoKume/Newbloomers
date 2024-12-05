using Application.DatabaseInit.Interfaces;
using Domain.IntegrationsCore.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Database
{
    [ApiController]
    [Route("DatabaseInit/B2CLinxMicrovix")]
    public class B2CLinxMicrovixController : Controller
    {
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
            _methods = _configuration
                        .GetSection("B2CLinxMicrovix")
                        .GetSection("Methods")
                        .Get<List<LinxMethods>>();
        }

        [HttpPost("CreateDatabasesIfNotExists")]
        public async Task<ActionResult> CreateDatabasesIfNotExists()
        {
            return Ok($"Database created successfully.");
        }

        [HttpPost("CreateTablesIfNotExists")]
        public async Task<ActionResult> CreateTablesIfNotExists()
        {
            _b2cLinxMicrovixService.CreateTablesIfNotExists(_methods);

            return Ok($"Tables created successfully.");
        }

        [HttpPost("CreateTablesMerges")]
        public async Task<ActionResult> CreateTablesMerges()
        {
            throw new NotImplementedException();
        }

        [HttpPost("InsertParametersIfNotExists")]
        public async Task<ActionResult> InsertParametersIfNotExists()
        {
            throw new NotImplementedException();
        }
    }
}
