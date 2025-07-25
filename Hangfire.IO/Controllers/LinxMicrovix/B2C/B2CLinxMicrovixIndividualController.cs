using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.LinxMicrovix
{
    [ApiController]
    [Route("MicrovixJobs/B2CLinxMicrovixIndividual")]
    public class B2CLinxMicrovixIndividualController : Controller
    {
        private readonly LinxAPIParam _linxMicrovixJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly IB2CConsultaClassificacaoService _b2cConsultaClassificacaoService;
        private readonly IB2CConsultaClientesService _b2cConsultaClientesService;
        private readonly IB2CConsultaPedidosService _b2cConsultaPedidosService;
        private readonly IB2CConsultaNFeService _b2cConsultaNFeService;
        private readonly IB2CConsultaPedidosItensService _b2cConsultaPedidosItensService;
        private readonly IB2CConsultaPedidosStatusService _b2cConsultaPedidosStatusService;
        private readonly IB2CConsultaClientesContatosService _b2cConsultaClientesContatosService;
        private readonly IB2CConsultaClientesContatosParentescoService _b2cConsultaClientesContatosParentescoService;
        private readonly IB2CConsultaImagensService _b2cConsultaImagensService;

        public B2CLinxMicrovixIndividualController
        (
            IConfiguration configuration,
            IB2CConsultaPedidosService b2cConsultaPedidosService,
            IB2CConsultaNFeService b2cConsultaNFeService,
            IB2CConsultaPedidosItensService b2cConsultaPedidosItensService,
            IB2CConsultaPedidosStatusService b2cConsultaPedidosStatusService,
            IB2CConsultaClassificacaoService b2cConsultaClassificacaoService,
            IB2CConsultaClientesService b2cConsultaClientesService,
            IB2CConsultaClientesContatosService b2cConsultaClientesContatosService,
            IB2CConsultaClientesContatosParentescoService b2cConsultaClientesContatosParentescoService,
            IB2CConsultaImagensService b2cConsultaImagensService
        )
        {
            _configuration = configuration;
            _b2cConsultaPedidosService = b2cConsultaPedidosService;
            _b2cConsultaNFeService = b2cConsultaNFeService;
            _b2cConsultaPedidosItensService = b2cConsultaPedidosItensService;
            _b2cConsultaPedidosStatusService = b2cConsultaPedidosStatusService;
            _b2cConsultaClassificacaoService = b2cConsultaClassificacaoService;
            _b2cConsultaClientesService = b2cConsultaClientesService;
            _b2cConsultaClientesContatosService = b2cConsultaClientesContatosService;
            _b2cConsultaClientesContatosParentescoService = b2cConsultaClientesContatosParentescoService;
            _b2cConsultaImagensService = b2cConsultaImagensService;

            _linxMicrovixJobParameter = new LinxAPIParam(
                docMainCompany: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("DocMainCompany")
                                .Value,

                schema: "linx_microvix_commerce",

                databaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("LinxMicrovixCommerceDatabaseName")
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

                parametersInterval: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("ParametersIndividual")
                                .Value,

                parametersTableName: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("ParametersTableName")
                                .Value,

                keyAuthorization: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("Key")
                                .Value,

                userAuthentication: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("Authentication")
                                .Value
            );

            _methods = _configuration
                            .GetSection("B2CLinxMicrovix")
                            .GetSection("Methods")
                            .Get<List<LinxMethods>>();
        }

        [HttpPost("B2CConsultaClassificacaoIndividual")]
        public async Task<ActionResult> B2CConsultaClassificacaoIndividual([Required][FromQuery] string? codigo_classificacao, [Required][FromQuery] string? cnpj_emp)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClassificacao")
                .FirstOrDefault();

            var result = await _b2cConsultaClassificacaoService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                cnpj_emp: cnpj_emp,
                identificador: codigo_classificacao
            );

            return Ok($"Record: {codigo_classificacao} integrated successfully.");
        }

        [HttpPost("B2CConsultaClientesIndividual")]
        public async Task<ActionResult> B2CConsultaClientesIndividual([Required][FromQuery] string? doc_cliente)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientes")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                identificador: doc_cliente
            );

            return Ok();
        }

        [HttpPost("B2CConsultaNFeIndividual")]
        public async Task<ActionResult> B2CConsultaNFeIndividual([Required][FromQuery] string? id_pedido)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaNFe")
                .FirstOrDefault();

            var result = await _b2cConsultaNFeService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                identificador: id_pedido
            );

            return Ok();
        }


        [HttpPost("B2CConsultaPedidosIndividual")]
        public async Task<ActionResult> B2CConsultaPedidosIndividual([Required][FromQuery] string? id_pedido)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidos")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                identificador: id_pedido
            );

            return Ok();
        }

        [HttpPost("B2CConsultaPedidosItensIndividual")]
        public async Task<ActionResult> B2CConsultaPedidosItensIndividual([Required][FromQuery] string? id_pedido, [Required][FromQuery] string? cnpj_emp)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosItensService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                identificador: id_pedido
            );

            return Ok();
        }

        [HttpPost("B2CConsultaPedidosStatusIndividual")]
        public async Task<ActionResult> B2CConsultaPedidosStatusIndividual([Required][FromQuery] string? id_pedido, [Required][FromQuery] string? cnpj_emp)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosStatusService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                identificador: id_pedido
            );

            return Ok();
        }

        [HttpPost("B2CConsultaClientesContatosParentescoIndividual")]
        public async Task<ActionResult> B2CConsultaClientesContatosParentescoIndividual([Required][FromQuery] string? id_parentesco, [Required][FromQuery] string? cnpj_emp)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesContatosParentescoService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                cnpj_emp: cnpj_emp,
                identificador: id_parentesco
            );

            return Ok();
        }

        [HttpPost("B2CConsultaImagensIndividual")]
        public async Task<ActionResult> B2CConsultaImagensIndividual([Required][FromQuery] string? id_imagem, [Required][FromQuery] string? cnpj_emp)
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaImagens")
                .FirstOrDefault();

            var result = await _b2cConsultaImagensService.GetRecord(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                ),
                cnpj_emp: cnpj_emp,
                identificador: id_imagem
            );

            return Ok();
        }
    }
}
