using Application.DatabaseInit.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace Hangfire.IO.Controllers.Database
{
    [ApiController]
    [Route("DatabaseInit")]
    public class DatabaseInitController : Controller
    {
        private readonly LinxAPIParam _linxMicrovixJobParameter;
        private readonly List<string>? _databases;
        private readonly IConfiguration _configuration;
        private readonly IDatabaseInitService _databaseInitService;

        public DatabaseInitController(
            IConfiguration configuration,
            IDatabaseInitService databaseInitService
        )
        {
            _databaseInitService = databaseInitService;
            _configuration = configuration;

            _linxMicrovixJobParameter = new LinxAPIParam(
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

                docMainCompany: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("DocMainCompany")
                                .Value
            );

            _databases = _configuration
                        .GetSection("ConfigureServer")
                        .GetSection("Databases")
                        .Get<List<string>>();
        }

        [HttpPost("CreateDatabasesIfNotExists")]
        public async Task<ActionResult> CreateDatabasesIfNotExists()
        {
            await _databaseInitService.CreateDatabasesIfNotExists(databases: _databases);

            return Ok($"Tables created successfully.");
        }
    }
}
