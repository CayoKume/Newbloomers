using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.LinxMicrovix
{
#if DEBUG
    [ApiController]
    [Route("LinxMicrovixJobs/B2CLinxMicrovix")]
    public class B2CLinxMicrovixController : Controller
    {
        private readonly LinxAPIParam _linxMicrovixJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly IB2CConsultaClassificacaoService _b2cConsultaClassificacaoService;
        private readonly IB2CConsultaClientesService _b2cConsultaClientesService;
        private readonly IB2CConsultaClientesContatosService _b2cConsultaClientesContatosService;
        private readonly IB2CConsultaClientesContatosParentescoService _b2cConsultaClientesContatosParentescoService;
        private readonly IB2CConsultaClientesEnderecosEntregaService _b2cConsultaClientesEnderecosEntregaService;
        private readonly IB2CConsultaClientesEstadoCivilService _b2cConsultaClientesEstadoCivilService;
        private readonly IB2CConsultaClientesSaldoService _b2cConsultaClientesSaldoService;
        private readonly IB2CConsultaClientesSaldoLinxService _b2cConsultaClientesSaldoLinxService;
        private readonly IB2CConsultaCNPJsChaveService _b2cConsultaCNPJsChaveService;
        private readonly IB2CConsultaCodigoRastreioService _b2cConsultaCodigoRastreioService;
        private readonly IB2CConsultaColecoesService _b2cConsultaColecoesService;
        private readonly IB2CConsultaEmpresasService _b2cConsultaEmpresasService;
        private readonly IB2CConsultaEspessurasService _b2cConsultaEspessurasService;
        private readonly IB2CConsultaFlagsService _b2cConsultaFlagsService;
        private readonly IB2CConsultaFormasPagamentoService _b2cConsultaFormasPagamentoService;
        private readonly IB2CConsultaFornecedoresService _b2cConsultaFornecedoresService;
        private readonly IB2CConsultaGrade1Service _b2cConsultaGrade1Service;
        private readonly IB2CConsultaGrade2Service _b2cConsultaGrade2Service;
        private readonly IB2CConsultaImagensService _b2cConsultaImagensService;
        private readonly IB2CConsultaImagensHDService _b2cConsultaImagensHDService;
        private readonly IB2CConsultaLegendasCadastrosAuxiliaresService _b2cConsultaLegendasCadastrosAuxiliaresService;
        private readonly IB2CConsultaLinhasService _b2cConsultaLinhasService;
        private readonly IB2CConsultaMarcasService _b2cConsultaMarcasService;
        private readonly IB2CConsultaNFeService _b2cConsultaNFeService;
        private readonly IB2CConsultaNFeSituacaoService _b2cConsultaNFeSituacaoService;
        private readonly IB2CConsultaPalavrasChavePesquisaService _b2cConsultaPalavrasChavePesquisaService;
        private readonly IB2CConsultaPedidosService _b2cConsultaPedidosService;
        private readonly IB2CConsultaPedidosIdentificadorService _b2cConsultaPedidosIdentificadorService;
        private readonly IB2CConsultaPedidosItensService _b2cConsultaPedidosItensService;
        private readonly IB2CConsultaPedidosPlanosService _b2cConsultaPedidosPlanosService;
        private readonly IB2CConsultaPedidosStatusService _b2cConsultaPedidosStatusService;
        private readonly IB2CConsultaPedidosTiposService _b2cConsultaPedidosTiposService;
        private readonly IB2CConsultaPlanosService _b2cConsultaPlanosService;
        private readonly IB2CConsultaPlanosParcelasService _b2cConsultaPlanosParcelasService;
        private readonly IB2CConsultaProdutosService _b2cConsultaProdutosService;
        private readonly IB2CConsultaProdutosAssociadosService _b2cConsultaProdutosAssociadosService;
        private readonly IB2CConsultaProdutosCampanhasService _b2cConsultaProdutosCampanhasService;
        private readonly IB2CConsultaProdutosCamposAdicionaisDetalhesService _b2cConsultaProdutosCamposAdicionaisDetalhesService;
        private readonly IB2CConsultaProdutosCamposAdicionaisNomesService _b2cConsultaProdutosCamposAdicionaisNomesService;
        private readonly IB2CConsultaProdutosCamposAdicionaisValoresService _b2cConsultaProdutosCamposAdicionaisValoresService;
        private readonly IB2CConsultaProdutosCodebarService _b2cConsultaProdutosCodebarService;
        private readonly IB2CConsultaProdutosCustosService _b2cConsultaProdutosCustosService;
        private readonly IB2CConsultaProdutosDepositosService _b2cConsultaProdutosDepositosService;
        private readonly IB2CConsultaProdutosDetalhesService _b2cConsultaProdutosDetalhesService;
        private readonly IB2CConsultaProdutosDetalhesDepositosService _b2cConsultaProdutosDetalhesDepositosService;
        private readonly IB2CConsultaProdutosDimensoesService _b2cConsultaProdutosDimensoesService;
        private readonly IB2CConsultaProdutosFlagsService _b2cConsultaProdutosFlagsService;
        private readonly IB2CConsultaProdutosImagensService _b2cConsultaProdutosImagensService;
        private readonly IB2CConsultaProdutosInformacoesService _b2cConsultaProdutosInformacoesService;
        private readonly IB2CConsultaProdutosPalavrasChavePesquisaService _b2cConsultaProdutosPalavrasChavePesquisaService;
        private readonly IB2CConsultaProdutosPromocaoService _b2cConsultaProdutosPromocaoService;
        private readonly IB2CConsultaProdutosStatusService _b2cConsultaProdutosStatusService;
        private readonly IB2CConsultaProdutosTabelasService _b2cConsultaProdutosTabelasService;
        private readonly IB2CConsultaProdutosTabelasPrecosService _b2cConsultaProdutosTabelasPrecosService;
        private readonly IB2CConsultaProdutosTagsService _b2cConsultaProdutosTagsService;
        private readonly IB2CConsultaSetoresService _b2cConsultaSetoresService;
        private readonly IB2CConsultaStatusService _b2cConsultaStatusService;
        private readonly IB2CConsultaTagsService _b2cConsultaTagsService;
        private readonly IB2CConsultaTipoEncomendaService _b2cConsultaTipoEncomendaService;
        private readonly IB2CConsultaTiposCobrancaFreteService _b2cConsultaTiposCobrancaFreteService;
        private readonly IB2CConsultaTransportadoresService _b2cConsultaTransportadoresService;
        private readonly IB2CConsultaUnidadeService _b2cConsultaUnidadeService;
        private readonly IB2CConsultaVendedoresService _b2cConsultaVendedoresService;

        public B2CLinxMicrovixController
        (
            IConfiguration configuration,
            IB2CConsultaClassificacaoService b2cConsultaClassificacaoService,
            IB2CConsultaClientesService b2cConsultaClientesService,
            IB2CConsultaClientesContatosService b2cConsultaClientesContatosService,
            IB2CConsultaClientesContatosParentescoService b2cConsultaClientesContatosParentescoService,
            IB2CConsultaClientesEnderecosEntregaService b2cConsultaClientesEnderecosEntregaService,
            IB2CConsultaClientesEstadoCivilService b2cConsultaClientesEstadoCivilService,
            IB2CConsultaClientesSaldoService b2cConsultaClientesSaldoService,
            IB2CConsultaClientesSaldoLinxService b2cConsultaClientesSaldoLinxService,
            IB2CConsultaCNPJsChaveService b2cConsultaCNPJsChaveService,
            IB2CConsultaCodigoRastreioService b2cConsultaCodigoRastreioService,
            IB2CConsultaColecoesService b2cConsultaColecoesService,
            IB2CConsultaEmpresasService b2cConsultaEmpresasService,
            IB2CConsultaEspessurasService b2cConsultaEspessurasService,
            IB2CConsultaFlagsService b2cConsultaFlagsService,
            IB2CConsultaFormasPagamentoService b2cConsultaFormasPagamentoService,
            IB2CConsultaFornecedoresService b2cConsultaFornecedoresService,
            IB2CConsultaGrade1Service b2cConsultaGrade1Service,
            IB2CConsultaGrade2Service b2cConsultaGrade2Service,
            IB2CConsultaImagensService b2cConsultaImagensService,
            IB2CConsultaImagensHDService b2cConsultaImagensHDService,
            IB2CConsultaLegendasCadastrosAuxiliaresService b2cConsultaLegendasCadastrosAuxiliaresService,
            IB2CConsultaLinhasService b2cConsultaLinhasService,
            IB2CConsultaMarcasService b2cConsultaMarcasService,
            IB2CConsultaNFeService b2cConsultaNFeService,
            IB2CConsultaNFeSituacaoService b2cConsultaNFeSituacaoService,
            IB2CConsultaPalavrasChavePesquisaService b2cConsultaPalavrasChavePesquisaService,
            IB2CConsultaPedidosService b2cConsultaPedidosService,
            IB2CConsultaPedidosIdentificadorService b2cConsultaPedidosIdentificadorService,
            IB2CConsultaPedidosItensService b2cConsultaPedidosItensService,
            IB2CConsultaPedidosPlanosService b2cConsultaPedidosPlanosService,
            IB2CConsultaPedidosStatusService b2cConsultaPedidosStatusService,
            IB2CConsultaPedidosTiposService b2cConsultaPedidosTiposService,
            IB2CConsultaPlanosService b2cConsultaPlanosService,
            IB2CConsultaPlanosParcelasService b2cConsultaPlanosParcelasService,
            IB2CConsultaProdutosService b2cConsultaProdutosService,
            IB2CConsultaProdutosAssociadosService b2cConsultaProdutosAssociadosService,
            IB2CConsultaProdutosCampanhasService b2cConsultaProdutosCampanhasService,
            IB2CConsultaProdutosCamposAdicionaisDetalhesService b2cConsultaProdutosCamposAdicionaisDetalhesService,
            IB2CConsultaProdutosCamposAdicionaisNomesService b2cConsultaProdutosCamposAdicionaisNomesService,
            IB2CConsultaProdutosCamposAdicionaisValoresService b2cConsultaProdutosCamposAdicionaisValoresService,
            IB2CConsultaProdutosCodebarService b2cConsultaProdutosCodebarService,
            IB2CConsultaProdutosCustosService b2cConsultaProdutosCustosService,
            IB2CConsultaProdutosDepositosService b2cConsultaProdutosDepositosService,
            IB2CConsultaProdutosDetalhesService b2cConsultaProdutosDetalhesService,
            IB2CConsultaProdutosDetalhesDepositosService b2cConsultaProdutosDetalhesDepositosService,
            IB2CConsultaProdutosDimensoesService b2cConsultaProdutosDimensoesService,
            IB2CConsultaProdutosFlagsService b2cConsultaProdutosFlagsService,
            IB2CConsultaProdutosImagensService b2cConsultaProdutosImagensService,
            IB2CConsultaProdutosInformacoesService b2cConsultaProdutosInformacoesService,
            IB2CConsultaProdutosPalavrasChavePesquisaService b2cConsultaProdutosPalavrasChavePesquisaService,
            IB2CConsultaProdutosPromocaoService b2cConsultaProdutosPromocaoService,
            IB2CConsultaProdutosStatusService b2cConsultaProdutosStatusService,
            IB2CConsultaProdutosTabelasService b2cConsultaProdutosTabelasService,
            IB2CConsultaProdutosTabelasPrecosService b2cConsultaProdutosTabelasPrecosService,
            IB2CConsultaProdutosTagsService b2cConsultaProdutosTagsService,
            IB2CConsultaSetoresService b2cConsultaSetoresService,
            IB2CConsultaStatusService b2cConsultaStatusService,
            IB2CConsultaTagsService b2cConsultaTagsService,
            IB2CConsultaTipoEncomendaService b2cConsultaTipoEncomendaService,
            IB2CConsultaTiposCobrancaFreteService b2cConsultaTiposCobrancaFreteService,
            IB2CConsultaTransportadoresService b2cConsultaTransportadoresService,
            IB2CConsultaUnidadeService b2cConsultaUnidadeService,
            IB2CConsultaVendedoresService b2cConsultaVendedoresService
        )
        {
            _configuration = configuration;
            _b2cConsultaClassificacaoService = b2cConsultaClassificacaoService;
            _b2cConsultaClientesService = b2cConsultaClientesService;
            _b2cConsultaClientesContatosService = b2cConsultaClientesContatosService;
            _b2cConsultaClientesContatosParentescoService = b2cConsultaClientesContatosParentescoService;
            _b2cConsultaClientesEnderecosEntregaService = b2cConsultaClientesEnderecosEntregaService;
            _b2cConsultaClientesEstadoCivilService = b2cConsultaClientesEstadoCivilService;
            _b2cConsultaClientesSaldoService = b2cConsultaClientesSaldoService;
            _b2cConsultaClientesSaldoLinxService = b2cConsultaClientesSaldoLinxService;
            _b2cConsultaCNPJsChaveService = b2cConsultaCNPJsChaveService;
            _b2cConsultaCodigoRastreioService = b2cConsultaCodigoRastreioService;
            _b2cConsultaColecoesService = b2cConsultaColecoesService;
            _b2cConsultaEmpresasService = b2cConsultaEmpresasService;
            _b2cConsultaEspessurasService = b2cConsultaEspessurasService;
            _b2cConsultaFlagsService = b2cConsultaFlagsService;
            _b2cConsultaFormasPagamentoService = b2cConsultaFormasPagamentoService;
            _b2cConsultaFornecedoresService = b2cConsultaFornecedoresService;
            _b2cConsultaGrade1Service = b2cConsultaGrade1Service;
            _b2cConsultaGrade2Service = b2cConsultaGrade2Service;
            _b2cConsultaImagensService = b2cConsultaImagensService;
            _b2cConsultaImagensHDService = b2cConsultaImagensHDService;
            _b2cConsultaLegendasCadastrosAuxiliaresService = b2cConsultaLegendasCadastrosAuxiliaresService;
            _b2cConsultaLinhasService = b2cConsultaLinhasService;
            _b2cConsultaMarcasService = b2cConsultaMarcasService;
            _b2cConsultaNFeService = b2cConsultaNFeService;
            _b2cConsultaNFeSituacaoService = b2cConsultaNFeSituacaoService;
            _b2cConsultaPalavrasChavePesquisaService = b2cConsultaPalavrasChavePesquisaService;
            _b2cConsultaPedidosService = b2cConsultaPedidosService;
            _b2cConsultaPedidosIdentificadorService = b2cConsultaPedidosIdentificadorService;
            _b2cConsultaPedidosItensService = b2cConsultaPedidosItensService;
            _b2cConsultaPedidosPlanosService = b2cConsultaPedidosPlanosService;
            _b2cConsultaPedidosStatusService = b2cConsultaPedidosStatusService;
            _b2cConsultaPedidosTiposService = b2cConsultaPedidosTiposService;
            _b2cConsultaPlanosService = b2cConsultaPlanosService;
            _b2cConsultaPlanosParcelasService = b2cConsultaPlanosParcelasService;
            _b2cConsultaProdutosService = b2cConsultaProdutosService;
            _b2cConsultaProdutosAssociadosService = b2cConsultaProdutosAssociadosService;
            _b2cConsultaProdutosCampanhasService = b2cConsultaProdutosCampanhasService;
            _b2cConsultaProdutosCamposAdicionaisDetalhesService = b2cConsultaProdutosCamposAdicionaisDetalhesService;
            _b2cConsultaProdutosCamposAdicionaisNomesService = b2cConsultaProdutosCamposAdicionaisNomesService;
            _b2cConsultaProdutosCamposAdicionaisValoresService = b2cConsultaProdutosCamposAdicionaisValoresService;
            _b2cConsultaProdutosCodebarService = b2cConsultaProdutosCodebarService;
            _b2cConsultaProdutosCustosService = b2cConsultaProdutosCustosService;
            _b2cConsultaProdutosDepositosService = b2cConsultaProdutosDepositosService;
            _b2cConsultaProdutosDetalhesService = b2cConsultaProdutosDetalhesService;
            _b2cConsultaProdutosDetalhesDepositosService = b2cConsultaProdutosDetalhesDepositosService;
            _b2cConsultaProdutosDimensoesService = b2cConsultaProdutosDimensoesService;
            _b2cConsultaProdutosFlagsService = b2cConsultaProdutosFlagsService;
            _b2cConsultaProdutosImagensService = b2cConsultaProdutosImagensService;
            _b2cConsultaProdutosInformacoesService = b2cConsultaProdutosInformacoesService;
            _b2cConsultaProdutosPalavrasChavePesquisaService = b2cConsultaProdutosPalavrasChavePesquisaService;
            _b2cConsultaProdutosPromocaoService = b2cConsultaProdutosPromocaoService;
            _b2cConsultaProdutosStatusService = b2cConsultaProdutosStatusService;
            _b2cConsultaProdutosTabelasService = b2cConsultaProdutosTabelasService;
            _b2cConsultaProdutosTabelasPrecosService = b2cConsultaProdutosTabelasPrecosService;
            _b2cConsultaProdutosTagsService = b2cConsultaProdutosTagsService;
            _b2cConsultaSetoresService = b2cConsultaSetoresService;
            _b2cConsultaStatusService = b2cConsultaStatusService;
            _b2cConsultaTagsService = b2cConsultaTagsService;
            _b2cConsultaTipoEncomendaService = b2cConsultaTipoEncomendaService;
            _b2cConsultaTiposCobrancaFreteService = b2cConsultaTiposCobrancaFreteService;
            _b2cConsultaTransportadoresService = b2cConsultaTransportadoresService;
            _b2cConsultaUnidadeService = b2cConsultaUnidadeService;
            _b2cConsultaVendedoresService = b2cConsultaVendedoresService;

            _linxMicrovixJobParameter = new LinxAPIParam(
                docMainCompany: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("DocMainCompany")
                                .Value,

                schema: "linx_microvix_commerce",

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

                parametersInterval: _configuration
                                .GetSection("B2CLinxMicrovix")
                                .GetSection("ParametersDateInterval")
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

        [HttpPost("B2CConsultaClassificacao")]
        public async Task<ActionResult> B2CConsultaClassificacao()
        {

            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClassificacao")
                .FirstOrDefault();

            var result = await _b2cConsultaClassificacaoService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaClientes")]
        public async Task<ActionResult> B2CConsultaClientes()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientes")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaClientesContatos")]
        public async Task<ActionResult> B2CConsultaClientesContatos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesContatosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaClientesContatosParentesco")]
        public async Task<ActionResult> B2CConsultaClientesContatosParentesco()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesContatosParentescoService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaClientesEnderecosEntrega")]
        public async Task<ActionResult> B2CConsultaClientesEnderecosEntrega()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesEnderecosEntregaService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaClientesEstadoCivil")]
        public async Task<ActionResult> B2CConsultaClientesEstadoCivil()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesEstadoCivilService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaClientesSaldo")]
        public async Task<ActionResult> B2CConsultaClientesSaldo()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesSaldoService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaClientesSaldoLinx")]
        public async Task<ActionResult> B2CConsultaClientesSaldoLinx()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                .FirstOrDefault();

            var result = await _b2cConsultaClientesSaldoLinxService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaCNPJsChave")]
        public async Task<ActionResult> B2CConsultaCNPJsChave()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                .FirstOrDefault();

            var result = await _b2cConsultaCNPJsChaveService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaCodigoRastreio")]
        public async Task<ActionResult> B2CConsultaCodigoRastreio()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                .FirstOrDefault();

            var result = await _b2cConsultaCodigoRastreioService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaColecoes")]
        public async Task<ActionResult> B2CConsultaColecoes()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaColecoes")
                .FirstOrDefault();

            var result = await _b2cConsultaColecoesService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaEmpresas")]
        public async Task<ActionResult> B2CConsultaEmpresas()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaEmpresas")
                .FirstOrDefault();

            var result = await _b2cConsultaEmpresasService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaEspessuras")]
        public async Task<ActionResult> B2CConsultaEspessuras()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaEspessuras")
                .FirstOrDefault();

            var result = await _b2cConsultaEspessurasService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaFlags")]
        public async Task<ActionResult> B2CConsultaFlags()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaFlags")
                .FirstOrDefault();

            var result = await _b2cConsultaFlagsService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaFormasPagamento")]
        public async Task<ActionResult> B2CConsultaFormasPagamento()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                .FirstOrDefault();

            var result = await _b2cConsultaFormasPagamentoService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaFornecedores")]
        public async Task<ActionResult> B2CConsultaFornecedores()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaFornecedores")
                .FirstOrDefault();

            var result = await _b2cConsultaFornecedoresService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaGrade1")]
        public async Task<ActionResult> B2CConsultaGrade1()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaGrade1")
                .FirstOrDefault();

            var result = await _b2cConsultaGrade1Service.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaGrade2")]
        public async Task<ActionResult> B2CConsultaGrade2()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaGrade2")
                .FirstOrDefault();

            var result = await _b2cConsultaGrade2Service.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaImagens")]
        public async Task<ActionResult> B2CConsultaImagens()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaImagens")
                .FirstOrDefault();

            var result = await _b2cConsultaImagensService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaImagensHD")]
        public async Task<ActionResult> B2CConsultaImagensHD()
        {

            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaImagensHD")
                .FirstOrDefault();

            var result = await _b2cConsultaImagensHDService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaLegendasCadastrosAuxiliares")]
        public async Task<ActionResult> B2CConsultaLegendasCadastrosAuxiliares()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                .FirstOrDefault();

            var result = await _b2cConsultaLegendasCadastrosAuxiliaresService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaLinhas")]
        public async Task<ActionResult> B2CConsultaLinhas()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaLinhas")
                .FirstOrDefault();

            var result = await _b2cConsultaLinhasService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaMarcas")]
        public async Task<ActionResult> B2CConsultaMarcas()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaMarcas")
                .FirstOrDefault();

            var result = await _b2cConsultaMarcasService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaNFe")]
        public async Task<ActionResult> B2CConsultaNFe()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaNFe")
                .FirstOrDefault();

            var result = await _b2cConsultaNFeService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaNFeSituacao")]
        public async Task<ActionResult> B2CConsultaNFeSituacao()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                .FirstOrDefault();

            var result = await _b2cConsultaNFeSituacaoService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPalavrasChavePesquisa")]
        public async Task<ActionResult> B2CConsultaPalavrasChavePesquisa()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                .FirstOrDefault();

            var result = await _b2cConsultaPalavrasChavePesquisaService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPedidos")]
        public async Task<ActionResult> B2CConsultaPedidos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidos")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPedidosIdentificador")]
        public async Task<ActionResult> B2CConsultaPedidosIdentificador()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosIdentificadorService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPedidosItens")]
        public async Task<ActionResult> B2CConsultaPedidosItens()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosItensService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPedidosPlanos")]
        public async Task<ActionResult> B2CConsultaPedidosPlanos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosPlanosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPedidosStatus")]
        public async Task<ActionResult> B2CConsultaPedidosStatus()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosStatusService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPedidosTipos")]
        public async Task<ActionResult> B2CConsultaPedidosTipos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                .FirstOrDefault();

            var result = await _b2cConsultaPedidosTiposService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPlanos")]
        public async Task<ActionResult> B2CConsultaPlanos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPlanos")
                .FirstOrDefault();

            var result = await _b2cConsultaPlanosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaPlanosParcelas")]
        public async Task<ActionResult> B2CConsultaPlanosParcelas()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                .FirstOrDefault();

            var result = await _b2cConsultaPlanosParcelasService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutos")]
        public async Task<ActionResult> B2CConsultaProdutos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutos")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosAssociados")]
        public async Task<ActionResult> B2CConsultaProdutosAssociados()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosAssociadosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosCampanhas")]
        public async Task<ActionResult> B2CConsultaProdutosCampanhas()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosCampanhasService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosCamposAdicionaisDetalhes")]
        public async Task<ActionResult> B2CConsultaProdutosCamposAdicionaisDetalhes()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosCamposAdicionaisDetalhesService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosCamposAdicionaisNomes")]
        public async Task<ActionResult> B2CConsultaProdutosCamposAdicionaisNomes()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosCamposAdicionaisNomesService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosCamposAdicionaisValores")]
        public async Task<ActionResult> B2CConsultaProdutosCamposAdicionaisValores()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosCamposAdicionaisValoresService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosCodebar")]
        public async Task<ActionResult> B2CConsultaProdutosCodebar()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosCodebarService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosCustos")]
        public async Task<ActionResult> B2CConsultaProdutosCustos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosCustosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosDepositos")]
        public async Task<ActionResult> B2CConsultaProdutosDepositos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosDepositosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosDetalhes")]
        public async Task<ActionResult> B2CConsultaProdutosDetalhes()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosDetalhesService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosDetalhesDepositos")]
        public async Task<ActionResult> B2CConsultaProdutosDetalhesDepositos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosDetalhesDepositosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosDimensoes")]
        public async Task<ActionResult> B2CConsultaProdutosDimensoes()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosDimensoesService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosFlags")]
        public async Task<ActionResult> B2CConsultaProdutosFlags()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosFlagsService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosImagens")]
        public async Task<ActionResult> B2CConsultaProdutosImagens()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosImagensService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosInformacoes")]
        public async Task<ActionResult> B2CConsultaProdutosInformacoes()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosInformacoesService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosPalavrasChavePesquisa")]
        public async Task<ActionResult> B2CConsultaProdutosPalavrasChavePesquisa()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosPalavrasChavePesquisaService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosPromocao")]
        public async Task<ActionResult> B2CConsultaProdutosPromocao()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosPromocaoService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosStatus")]
        public async Task<ActionResult> B2CConsultaProdutosStatus()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosStatusService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosTabelas")]
        public async Task<ActionResult> B2CConsultaProdutosTabelas()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosTabelasService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosTabelasPrecos")]
        public async Task<ActionResult> B2CConsultaProdutosTabelasPrecos()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosTabelasPrecosService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaProdutosTags")]
        public async Task<ActionResult> B2CConsultaProdutosTags()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                .FirstOrDefault();

            var result = await _b2cConsultaProdutosTagsService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaSetores")]
        public async Task<ActionResult> B2CConsultaSetores()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaSetores")
                .FirstOrDefault();

            var result = await _b2cConsultaSetoresService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaStatus")]
        public async Task<ActionResult> B2CConsultaStatus()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaStatus")
                .FirstOrDefault();

            var result = await _b2cConsultaStatusService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaTags")]
        public async Task<ActionResult> B2CConsultaTags()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaTags")
                .FirstOrDefault();

            var result = await _b2cConsultaTagsService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaTipoEncomenda")]
        public async Task<ActionResult> B2CConsultaTipoEncomenda()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                .FirstOrDefault();

            var result = await _b2cConsultaTipoEncomendaService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaTiposCobrancaFrete")]
        public async Task<ActionResult> B2CConsultaTiposCobrancaFrete()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                .FirstOrDefault();

            var result = await _b2cConsultaTiposCobrancaFreteService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaTransportadores")]
        public async Task<ActionResult> B2CConsultaTransportadores()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaTransportadores")
                .FirstOrDefault();

            var result = await _b2cConsultaTransportadoresService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );
            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaUnidade")]
        public async Task<ActionResult> B2CConsultaUnidade()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaUnidade")
                .FirstOrDefault();

            var result = await _b2cConsultaUnidadeService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }

        [HttpPost("B2CConsultaVendedores")]
        public async Task<ActionResult> B2CConsultaVendedores()
        {
            var method = _methods
                .Where(m => m.MethodName == "B2CConsultaVendedores")
                .FirstOrDefault();

            var result = await _b2cConsultaVendedoresService.GetRecords(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }
    }
#endif
}
