using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.LinxMicrovix
{
    [ApiController]
    [Route("MicrovixJobs/B2CLinxMicrovixIndividual")]
    public class B2CLinxMicrovixIndividualController : Controller
    {
        private readonly string? _docMainCompany;
        private readonly string? _projectName;
        private readonly string? _parametersInterval;
        private readonly string? _parametersTableName;
        private readonly string? _parametersLogTableName;
        private readonly string? _key;
        private readonly string? _authentication;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly IB2CConsultaClassificacaoService _b2cConsultaClassificacaoService;
        private readonly IB2CConsultaClientesService _b2cConsultaClientesService;
        private readonly IB2CConsultaClientesContatosService _b2cConsultaClientesContatosService;
        private readonly IB2CConsultaClientesContatosParentescoService _b2cConsultaClientesContatosParentescoService;
        private readonly IB2CConsultaImagensService _b2cConsultaImagensService;

        public B2CLinxMicrovixIndividualController
        (
            IConfiguration configuration,
            IB2CConsultaClassificacaoService b2cConsultaClassificacaoService,
            IB2CConsultaClientesService b2cConsultaClientesService,
            IB2CConsultaClientesContatosService b2cConsultaClientesContatosService,
            IB2CConsultaClientesContatosParentescoService b2cConsultaClientesContatosParentescoService,
            IB2CConsultaImagensService b2cConsultaImagensService
        )
        {
            _configuration = configuration;
            _b2cConsultaClassificacaoService = b2cConsultaClassificacaoService;
            _b2cConsultaClientesService = b2cConsultaClientesService;
            _b2cConsultaClientesContatosService = b2cConsultaClientesContatosService;
            _b2cConsultaClientesContatosParentescoService = b2cConsultaClientesContatosParentescoService;
            _b2cConsultaImagensService = b2cConsultaImagensService;

            _docMainCompany = _configuration
                .GetSection("B2CLinxMicrovix")
                .GetSection("MainCompany")
                .Value;

            _projectName = _configuration
                .GetSection("B2CLinxMicrovix")
                .GetSection("ProjectName")
                .Value;

            _parametersLogTableName = _configuration
                .GetSection("B2CLinxMicrovix")
                .GetSection("ProjectParametersLogTableName")
                .Value;

            _parametersTableName = _configuration
                .GetSection("B2CLinxMicrovix")
                .GetSection("ProjectParametersTableName")
                .Value;

            _key = _configuration
                .GetSection("B2CLinxMicrovix")
                .GetSection("Key")
                .Value;

            _authentication = _configuration
                .GetSection("B2CLinxMicrovix")
                .GetSection("Authentication")
                .Value;

            _parametersInterval = _configuration
                            .GetSection("B2CLinxMicrovix")
                            .GetSection("ParametersIndividual")
                            .Value;

            _methods = _configuration
                            .GetSection("B2CLinxMicrovix")
                            .GetSection("Methods")
                            .Get<List<LinxMethods>>();
        }

        [HttpPost("B2CConsultaClassificacaoIndividual")]
        public async Task<ActionResult> B2CConsultaClassificacaoIndividual([Required][FromQuery] string? codigo_classificacao, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClassificacao")
                    .FirstOrDefault();

                var result = await _b2cConsultaClassificacaoService.GetRecord(
                    new LinxMicrovixJobParameter
                    {
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    },
                    cnpj_emp: cnpj_emp,
                    identificador: codigo_classificacao
                );

                if (result != true)
                    return BadRequest($"Unable to find record: {codigo_classificacao} on endpoint.");
                else
                    return Ok($"Record: {codigo_classificacao} integrated successfully.");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the record: {codigo_classificacao}.\nError: {ex.Message}");
            }
        }

        [HttpPost("B2CConsultaClientesIndividual")]
        public async Task<ActionResult> B2CConsultaClientesIndividual([Required][FromQuery] string? doc_cliente, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientes")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesService.GetRecord(
                    new LinxMicrovixJobParameter
                    {
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    },
                    cnpj_emp: cnpj_emp,
                    identificador: doc_cliente
                );

                if (result != true)
                    return BadRequest($"Unable to find record: {doc_cliente} on endpoint.");
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the record: {doc_cliente}.\nError: {ex.Message}");
            }
        }

        [HttpPost("B2CConsultaClientesContatosParentescoIndividual")]
        public async Task<ActionResult> B2CConsultaClientesContatosParentescoIndividual([Required][FromQuery] string? id_parentesco, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesContatosParentescoService.GetRecord(
                    new LinxMicrovixJobParameter
                    {
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    },
                    cnpj_emp: cnpj_emp,
                    identificador: id_parentesco
                );

                if (result != true)
                    return BadRequest($"Unable to find record: {id_parentesco} on endpoint.");
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the record: {id_parentesco}.\nError: {ex.Message}");
            }
        }

        [HttpPost("B2CConsultaImagensIndividual")]
        public async Task<ActionResult> B2CConsultaImagensIndividual([Required][FromQuery] string? id_imagem, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaImagens")
                    .FirstOrDefault();

                var result = await _b2cConsultaImagensService.GetRecord(
                    new LinxMicrovixJobParameter
                    {
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    },
                    cnpj_emp: cnpj_emp,
                    identificador: id_imagem
                );

                if (result != true)
                    return BadRequest($"Unable to find record: {id_imagem} on endpoint.");
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Content($"Unable to integrate the record: {id_imagem}.\nError: {ex.Message}");
            }
        }
    }
}
