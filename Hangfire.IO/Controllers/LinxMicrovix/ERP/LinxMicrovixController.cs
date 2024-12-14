using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.LinxMicrovix
{
    public class LinxMicrovixController : Controller
    {
        private readonly LinxAPIParam _linxMicrovixJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly ILinxVendedoresService _linxVendedoresService;
        private readonly ILinxProdutosCodBarService _linxProdutosCodBarService;

        public LinxMicrovixController(
            IConfiguration configuration,
            ILinxVendedoresService linxVendedoresService,
            ILinxProdutosCodBarService linxProdutosCodBarService
        )
        {
            _configuration = configuration;
            _linxVendedoresService = linxVendedoresService;
            _linxProdutosCodBarService = linxProdutosCodBarService;

            _linxMicrovixJobParameter = new LinxAPIParam(
                docMainCompany: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("DocMainCompany")
                                .Value,

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

                projectName: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ProjectName")
                                .Value,

                parametersInterval: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ParametersDateInterval")
                                .Value,

                parametersTableName: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ParametersTableName")
                                .Value,

                keyAuthorization: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("Key")
                                .Value,

                userAuthentication: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("Authentication")
                                .Value
            );

            _methods = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("Methods")
                            .Get<List<LinxMethods>>();
        }

        [HttpPost("LinxVendedores")]
        public async Task<ActionResult> LinxVendedores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxVendedores")
                    .FirstOrDefault();

                var result = await _linxVendedoresService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
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
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }

        [HttpPost("LinxProdutosCodBar")]
        public async Task<ActionResult> LinxProdutosCodBar()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosCodBar")
                    .FirstOrDefault();

                var result = await _linxProdutosCodBarService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
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
                return Content($"Unable to integrate the records.\nError: {ex.Message}");
            }
        }
    }
}
