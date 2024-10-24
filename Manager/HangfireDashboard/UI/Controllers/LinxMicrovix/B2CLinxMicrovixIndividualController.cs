using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HangfireDashboard.UI.Controllers.LinxMicrovix
{
    [ApiController]
    [Route("MicrovixJobs/B2CLinxMicrovixIndividual")]
    public class B2CLinxMicrovixIndividualController : Controller
    {
        private readonly string? _projectName;
        private readonly string? _parametersTableName;
        private readonly string? _parametersLogTableName;
        private readonly string? _key;
        private readonly string? _authentication;

        private readonly IConfiguration _configuration;
        private readonly IB2CConsultaClassificacaoService<B2CConsultaClassificacao> _b2cConsultaClassificacaoService;
        private readonly IB2CConsultaClientesService<B2CConsultaClientes> _b2cConsultaClientesService;
        private readonly IB2CConsultaClientesContatosService<B2CConsultaClientesContatos> _b2cConsultaClientesContatosService;
        private readonly IB2CConsultaClientesContatosParentescoService<B2CConsultaClientesContatosParentesco> _b2cConsultaClientesContatosParentescoService;

        public B2CLinxMicrovixIndividualController
        (
            IConfiguration configuration,
            IB2CConsultaClassificacaoService<B2CConsultaClassificacao> b2cConsultaClassificacaoService,
            IB2CConsultaClientesService<B2CConsultaClientes> b2cConsultaClientesService,
            IB2CConsultaClientesContatosService<B2CConsultaClientesContatos> b2cConsultaClientesContatosService,
            IB2CConsultaClientesContatosParentescoService<B2CConsultaClientesContatosParentesco> b2cConsultaClientesContatosParentescoService
        )
        {
            _configuration = configuration;
            _b2cConsultaClassificacaoService = b2cConsultaClassificacaoService;
            _b2cConsultaClientesService = b2cConsultaClientesService;
            _b2cConsultaClientesContatosService = b2cConsultaClientesContatosService;
            _b2cConsultaClientesContatosParentescoService = b2cConsultaClientesContatosParentescoService;

            _projectName = _configuration
                .GetSection("LinxMicrovix")
                .GetSection("ProjectName")
                .Value;

            _parametersLogTableName = _configuration
                .GetSection("LinxMicrovix")
                .GetSection("ProjectParametersLogTableName")
                .Value;

            _parametersTableName = _configuration
                .GetSection("LinxMicrovix")
                .GetSection("ProjectParametersTableName")
                .Value;

            _key = _configuration
                .GetSection("LinxMicrovix")
                .GetSection("B2CKey")
                .Value;

            _authentication = _configuration
                .GetSection("LinxMicrovix")
                .GetSection("B2CAuthentication")
                .Value;
        }

        [HttpPost("B2CConsultaClassificacaoIndividual")]
        public async Task<ActionResult> B2CConsultaClassificacaoIndividual([Required][FromQuery] string codigo_classificacao, [Required][FromQuery] string cnpj_emp)
        {
            try
            {
                var result = await _b2cConsultaClassificacaoService.GetRecord(
                    new JobParameter
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

                        parametersInterval = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("ParametersIndividual")
                            .Value,
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
        public async Task<ActionResult> B2CConsultaClientesIndividual([Required][FromQuery] string doc_cliente, [Required][FromQuery] string cnpj_emp)
        {
            try
            {
                var result = await _b2cConsultaClientesService.GetRecord(
                    new JobParameter
                    {
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,

                        jobName = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("B2CConsultaClientes")
                            .GetSection("MethodName")
                            .Value,

                        tableName = "_" + _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("B2CConsultaClientes")
                            .GetSection("MethodName")
                            .Value,

                        parametersInterval = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("ParametersIndividual")
                            .Value,
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
        public async Task<ActionResult> B2CConsultaClientesContatosParentescoIndividual([Required][FromQuery] string id_parentesco, [Required][FromQuery] string cnpj_emp)
        {
            try
            {
                var result = await _b2cConsultaClientesContatosParentescoService.GetRecord(
                    new JobParameter
                    {
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,

                        jobName = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("B2CConsultaClientesContatosParentesco")
                            .GetSection("MethodName")
                            .Value,

                        tableName = "_" + _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("B2CConsultaClientesContatosParentesco")
                            .GetSection("MethodName")
                            .Value,

                        parametersInterval = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("ParametersIndividual")
                            .Value,
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
    }
}
