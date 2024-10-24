using IntegrationsCore.Domain.Entities;
using LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using Microsoft.AspNetCore.Mvc;
using HangfireDashboard.Domain.Entites;
using ZstdSharp.Unsafe;

namespace HangfireDashboard.UI.Controllers.LinxMicrovix
{
    [ApiController]
    [Route("MicrovixJobs/B2CLinxMicrovix")]
    public class B2CLinxMicrovixController : Controller
    {
        private readonly string? _docMainCompany;
        private readonly string? _projectName;
        private readonly string? _parametersInterval;
        private readonly string? _parametersTableName;
        private readonly string? _parametersLogTableName;
        private readonly string? _key;
        private readonly string? _authentication;
        private readonly List<Method>? _methods;

        private readonly IConfiguration _configuration;
        private readonly IB2CConsultaClassificacaoService<B2CConsultaClassificacao> _b2cConsultaClassificacaoService;
        private readonly IB2CConsultaClientesService<B2CConsultaClientes> _b2cConsultaClientesService;
        private readonly IB2CConsultaClientesContatosService<B2CConsultaClientesContatos> _b2cConsultaClientesContatosService;
        private readonly IB2CConsultaClientesContatosParentescoService<B2CConsultaClientesContatosParentesco> _b2cConsultaClientesContatosParentescoService;
        private readonly IB2CConsultaClientesEnderecosEntregaService<B2CConsultaClientesEnderecosEntrega> _b2cConsultaClientesEnderecosEntregaService;
        private readonly IB2CConsultaClientesEstadoCivilService<B2CConsultaClientesEstadoCivil> _b2cConsultaClientesEstadoCivilService;
        private readonly IB2CConsultaClientesSaldoService<B2CConsultaClientesSaldo> _b2cConsultaClientesSaldoService;
        private readonly IB2CConsultaClientesSaldoLinxService<B2CConsultaClientesSaldoLinx> _b2cConsultaClientesSaldoLinxService;
        private readonly IB2CConsultaCNPJsChaveService<B2CConsultaCNPJsChave> _b2cConsultaCNPJsChaveService;
        private readonly IB2CConsultaCodigoRastreioService<B2CConsultaCodigoRastreio> _b2cConsultaCodigoRastreioService;
        private readonly IB2CConsultaColecoesService<B2CConsultaColecoes> _b2cConsultaColecoesService;
        private readonly IB2CConsultaEmpresasService<B2CConsultaEmpresas> _b2cConsultaEmpresasService;
        private readonly IB2CConsultaEspessurasService<B2CConsultaEspessuras> _b2cConsultaEspessurasService;
        private readonly IB2CConsultaFlagsService<B2CConsultaFlags> _b2cConsultaFlagsService;
        private readonly IB2CConsultaFormasPagamentoService<B2CConsultaFormasPagamento> _b2cConsultaFormasPagamentoService;
        private readonly IB2CConsultaFornecedoresService<B2CConsultaFornecedores> _b2cConsultaFornecedoresService;
        private readonly IB2CConsultaGrade1Service<B2CConsultaGrade1> _b2cConsultaGrade1Service;
        private readonly IB2CConsultaGrade2Service<B2CConsultaGrade2> _b2cConsultaGrade2Service;
        private readonly IB2CConsultaImagensService<B2CConsultaImagens> _b2cConsultaImagensService;
        private readonly IB2CConsultaImagensHDService<B2CConsultaImagensHD> _b2cConsultaImagensHDService;
        private readonly IB2CConsultaLegendasCadastrosAuxiliaresService<B2CConsultaLegendasCadastrosAuxiliares> _b2cConsultaLegendasCadastrosAuxiliaresService;
        private readonly IB2CConsultaLinhasService<B2CConsultaLinhas> _b2cConsultaLinhasService;
        private readonly IB2CConsultaMarcasService<B2CConsultaMarcas> _b2cConsultaMarcasService;
        private readonly IB2CConsultaNFeService<B2CConsultaNFe> _b2cConsultaNFeService;
        private readonly IB2CConsultaNFeSituacaoService<B2CConsultaNFeSituacao> _b2cConsultaNFeSituacaoService;
        private readonly IB2CConsultaPalavrasChavePesquisaService<B2CConsultaPalavrasChavePesquisa> _b2cConsultaPalavrasChavePesquisaService;
        private readonly IB2CConsultaPedidosService<B2CConsultaPedidos> _b2cConsultaPedidosService;
        private readonly IB2CConsultaPedidosIdentificadorService<B2CConsultaPedidosIdentificador> _b2cConsultaPedidosIdentificadorService;
        private readonly IB2CConsultaPedidosItensService<B2CConsultaPedidosItens> _b2cConsultaPedidosItensService;
        private readonly IB2CConsultaPedidosPlanosService<B2CConsultaPedidosPlanos> _b2cConsultaPedidosPlanosService;
        private readonly IB2CConsultaPedidosStatusService<B2CConsultaPedidosStatus> _b2cConsultaPedidosStatusService;
        private readonly IB2CConsultaPedidosTiposService<B2CConsultaPedidosTipos> _b2cConsultaPedidosTiposService;
        private readonly IB2CConsultaPlanosService<B2CConsultaPlanos> _b2cConsultaPlanosService;
        private readonly IB2CConsultaPlanosParcelasService<B2CConsultaPlanosParcelas> _b2cConsultaPlanosParcelasService;
        private readonly IB2CConsultaProdutosService<B2CConsultaProdutos> _b2cConsultaProdutosService;
        private readonly IB2CConsultaProdutosAssociadosService<B2CConsultaProdutosAssociados> _b2cConsultaProdutosAssociadosService;
        private readonly IB2CConsultaProdutosCampanhasService<B2CConsultaProdutosCampanhas> _b2cConsultaProdutosCampanhasService;
        private readonly IB2CConsultaProdutosCamposAdicionaisDetalhesService<B2CConsultaProdutosCamposAdicionaisDetalhes> _b2cConsultaProdutosCamposAdicionaisDetalhesService;
        private readonly IB2CConsultaProdutosCamposAdicionaisNomesService<B2CConsultaProdutosCamposAdicionaisNomes> _b2cConsultaProdutosCamposAdicionaisNomesService;
        private readonly IB2CConsultaProdutosCamposAdicionaisValoresService<B2CConsultaProdutosCamposAdicionaisValores> _b2cConsultaProdutosCamposAdicionaisValoresService;
        private readonly IB2CConsultaProdutosCodebarService<B2CConsultaProdutosCodebar> _b2cConsultaProdutosCodebarService;
        private readonly IB2CConsultaProdutosCustosService<B2CConsultaProdutosCustos> _b2cConsultaProdutosCustosService;
        private readonly IB2CConsultaProdutosDepositosService<B2CConsultaProdutosDepositos> _b2cConsultaProdutosDepositosService;
        private readonly IB2CConsultaProdutosDetalhesService<B2CConsultaProdutosDetalhes> _b2cConsultaProdutosDetalhesService;
        private readonly IB2CConsultaProdutosDetalhesDepositosService<B2CConsultaProdutosDetalhesDepositos> _b2cConsultaProdutosDetalhesDepositosService;
        private readonly IB2CConsultaProdutosDimensoesService<B2CConsultaProdutosDimensoes> _b2cConsultaProdutosDimensoesService;
        private readonly IB2CConsultaProdutosFlagsService<B2CConsultaProdutosFlags> _b2cConsultaProdutosFlagsService;
        private readonly IB2CConsultaProdutosImagensService<B2CConsultaProdutosImagens> _b2cConsultaProdutosImagensService;
        private readonly IB2CConsultaProdutosInformacoesService<B2CConsultaProdutosInformacoes> _b2cConsultaProdutosInformacoesService;
        private readonly IB2CConsultaProdutosPalavrasChavePesquisaService<B2CConsultaProdutosPalavrasChavePesquisa> _b2cConsultaProdutosPalavrasChavePesquisaService;
        private readonly IB2CConsultaProdutosPromocaoService<B2CConsultaProdutosPromocao> _b2cConsultaProdutosPromocaoService;
        private readonly IB2CConsultaProdutosStatusService<B2CConsultaProdutosStatus> _b2cConsultaProdutosStatusService;
        private readonly IB2CConsultaProdutosTabelasService<B2CConsultaProdutosTabelas> _b2cConsultaProdutosTabelasService;
        private readonly IB2CConsultaProdutosTabelasPrecosService<B2CConsultaProdutosTabelasPrecos> _b2cConsultaProdutosTabelasPrecosService;
        private readonly IB2CConsultaProdutosTagsService<B2CConsultaProdutosTags> _b2cConsultaProdutosTagsService;
        private readonly IB2CConsultaSetoresService<B2CConsultaSetores> _b2cConsultaSetoresService;
        private readonly IB2CConsultaStatusService<B2CConsultaStatus> _b2cConsultaStatusService;
        private readonly IB2CConsultaTagsService<B2CConsultaTags> _b2cConsultaTagsService;
        private readonly IB2CConsultaTipoEncomendaService<B2CConsultaTipoEncomenda> _b2cConsultaTipoEncomendaService;
        private readonly IB2CConsultaTiposCobrancaFreteService<B2CConsultaTiposCobrancaFrete> _b2cConsultaTiposCobrancaFreteService;
        private readonly IB2CConsultaTransportadoresService<B2CConsultaTransportadores> _b2cConsultaTransportadoresService;
        private readonly IB2CConsultaUnidadeService<B2CConsultaUnidade> _b2cConsultaUnidadeService;
        private readonly IB2CConsultaVendedoresService<B2CConsultaVendedores> _b2cConsultaVendedoresService;

        public B2CLinxMicrovixController
        (
            IConfiguration configuration,
            IB2CConsultaClassificacaoService<B2CConsultaClassificacao> b2cConsultaClassificacaoService,
            IB2CConsultaClientesService<B2CConsultaClientes> b2cConsultaClientesService,
            IB2CConsultaClientesContatosService<B2CConsultaClientesContatos> b2cConsultaClientesContatosService,
            IB2CConsultaClientesContatosParentescoService<B2CConsultaClientesContatosParentesco> b2cConsultaClientesContatosParentescoService,
            IB2CConsultaClientesEnderecosEntregaService<B2CConsultaClientesEnderecosEntrega> b2cConsultaClientesEnderecosEntregaService,
            IB2CConsultaClientesEstadoCivilService<B2CConsultaClientesEstadoCivil> b2cConsultaClientesEstadoCivilService,
            IB2CConsultaClientesSaldoService<B2CConsultaClientesSaldo> b2cConsultaClientesSaldoService,
            IB2CConsultaClientesSaldoLinxService<B2CConsultaClientesSaldoLinx> b2cConsultaClientesSaldoLinxService,
            IB2CConsultaCNPJsChaveService<B2CConsultaCNPJsChave> b2cConsultaCNPJsChaveService,
            IB2CConsultaCodigoRastreioService<B2CConsultaCodigoRastreio> b2cConsultaCodigoRastreioService,
            IB2CConsultaColecoesService<B2CConsultaColecoes> b2cConsultaColecoesService,
            IB2CConsultaEmpresasService<B2CConsultaEmpresas> b2cConsultaEmpresasService,
            IB2CConsultaEspessurasService<B2CConsultaEspessuras> b2cConsultaEspessurasService,
            IB2CConsultaFlagsService<B2CConsultaFlags> b2cConsultaFlagsService,
            IB2CConsultaFormasPagamentoService<B2CConsultaFormasPagamento> b2cConsultaFormasPagamentoService,
            IB2CConsultaFornecedoresService<B2CConsultaFornecedores> b2cConsultaFornecedoresService,
            IB2CConsultaGrade1Service<B2CConsultaGrade1> b2cConsultaGrade1Service,
            IB2CConsultaGrade2Service<B2CConsultaGrade2> b2cConsultaGrade2Service,
            IB2CConsultaImagensService<B2CConsultaImagens> b2cConsultaImagensService,
            IB2CConsultaImagensHDService<B2CConsultaImagensHD> b2cConsultaImagensHDService,
            IB2CConsultaLegendasCadastrosAuxiliaresService<B2CConsultaLegendasCadastrosAuxiliares> b2cConsultaLegendasCadastrosAuxiliaresService,
            IB2CConsultaLinhasService<B2CConsultaLinhas> b2cConsultaLinhasService,
            IB2CConsultaMarcasService<B2CConsultaMarcas> b2cConsultaMarcasService,
            IB2CConsultaNFeService<B2CConsultaNFe> b2cConsultaNFeService,
            IB2CConsultaNFeSituacaoService<B2CConsultaNFeSituacao> b2cConsultaNFeSituacaoService,
            IB2CConsultaPalavrasChavePesquisaService<B2CConsultaPalavrasChavePesquisa> b2cConsultaPalavrasChavePesquisaService,
            IB2CConsultaPedidosService<B2CConsultaPedidos> b2cConsultaPedidosService,
            IB2CConsultaPedidosIdentificadorService<B2CConsultaPedidosIdentificador> b2cConsultaPedidosIdentificadorService,
            IB2CConsultaPedidosItensService<B2CConsultaPedidosItens> b2cConsultaPedidosItensService,
            IB2CConsultaPedidosPlanosService<B2CConsultaPedidosPlanos> b2cConsultaPedidosPlanosService,
            IB2CConsultaPedidosStatusService<B2CConsultaPedidosStatus> b2cConsultaPedidosStatusService,
            IB2CConsultaPedidosTiposService<B2CConsultaPedidosTipos> b2cConsultaPedidosTiposService,
            IB2CConsultaPlanosService<B2CConsultaPlanos> b2cConsultaPlanosService,
            IB2CConsultaPlanosParcelasService<B2CConsultaPlanosParcelas> b2cConsultaPlanosParcelasService,
            IB2CConsultaProdutosService<B2CConsultaProdutos> b2cConsultaProdutosService,
            IB2CConsultaProdutosAssociadosService<B2CConsultaProdutosAssociados> b2cConsultaProdutosAssociadosService,
            IB2CConsultaProdutosCampanhasService<B2CConsultaProdutosCampanhas> b2cConsultaProdutosCampanhasService,
            IB2CConsultaProdutosCamposAdicionaisDetalhesService<B2CConsultaProdutosCamposAdicionaisDetalhes> b2cConsultaProdutosCamposAdicionaisDetalhesService,
            IB2CConsultaProdutosCamposAdicionaisNomesService<B2CConsultaProdutosCamposAdicionaisNomes> b2cConsultaProdutosCamposAdicionaisNomesService,
            IB2CConsultaProdutosCamposAdicionaisValoresService<B2CConsultaProdutosCamposAdicionaisValores> b2cConsultaProdutosCamposAdicionaisValoresService,
            IB2CConsultaProdutosCodebarService<B2CConsultaProdutosCodebar> b2cConsultaProdutosCodebarService,
            IB2CConsultaProdutosCustosService<B2CConsultaProdutosCustos> b2cConsultaProdutosCustosService,
            IB2CConsultaProdutosDepositosService<B2CConsultaProdutosDepositos> b2cConsultaProdutosDepositosService,
            IB2CConsultaProdutosDetalhesService<B2CConsultaProdutosDetalhes> b2cConsultaProdutosDetalhesService,
            IB2CConsultaProdutosDetalhesDepositosService<B2CConsultaProdutosDetalhesDepositos> b2cConsultaProdutosDetalhesDepositosService,
            IB2CConsultaProdutosDimensoesService<B2CConsultaProdutosDimensoes> b2cConsultaProdutosDimensoesService,
            IB2CConsultaProdutosFlagsService<B2CConsultaProdutosFlags> b2cConsultaProdutosFlagsService,
            IB2CConsultaProdutosImagensService<B2CConsultaProdutosImagens> b2cConsultaProdutosImagensService,
            IB2CConsultaProdutosInformacoesService<B2CConsultaProdutosInformacoes> b2cConsultaProdutosInformacoesService,
            IB2CConsultaProdutosPalavrasChavePesquisaService<B2CConsultaProdutosPalavrasChavePesquisa> b2cConsultaProdutosPalavrasChavePesquisaService,
            IB2CConsultaProdutosPromocaoService<B2CConsultaProdutosPromocao> b2cConsultaProdutosPromocaoService,
            IB2CConsultaProdutosStatusService<B2CConsultaProdutosStatus> b2cConsultaProdutosStatusService,
            IB2CConsultaProdutosTabelasService<B2CConsultaProdutosTabelas> b2cConsultaProdutosTabelasService,
            IB2CConsultaProdutosTabelasPrecosService<B2CConsultaProdutosTabelasPrecos> b2cConsultaProdutosTabelasPrecosService,
            IB2CConsultaProdutosTagsService<B2CConsultaProdutosTags> b2cConsultaProdutosTagsService,
            IB2CConsultaSetoresService<B2CConsultaSetores> b2cConsultaSetoresService,
            IB2CConsultaStatusService<B2CConsultaStatus> b2cConsultaStatusService,
            IB2CConsultaTagsService<B2CConsultaTags> b2cConsultaTagsService,
            IB2CConsultaTipoEncomendaService<B2CConsultaTipoEncomenda> b2cConsultaTipoEncomendaService,
            IB2CConsultaTiposCobrancaFreteService<B2CConsultaTiposCobrancaFrete> b2cConsultaTiposCobrancaFreteService,
            IB2CConsultaTransportadoresService<B2CConsultaTransportadores> b2cConsultaTransportadoresService,
            IB2CConsultaUnidadeService<B2CConsultaUnidade> b2cConsultaUnidadeService,
            IB2CConsultaVendedoresService<B2CConsultaVendedores> b2cConsultaVendedoresService
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
                            .GetSection("ParametersDateInterval")
                            .Value;

            _methods = _configuration
                            .GetSection("B2CLinxMicrovix")
                            .GetSection("Methods")
                            .Get<List<Method>>();
        }

        [HttpPost("B2CConsultaClassificacao")]
        public async Task<ActionResult> B2CConsultaClassificacao()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClassificacao")
                    .FirstOrDefault();
                
                var result = await _b2cConsultaClassificacaoService.GetRecords(
                    new JobParameter {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaClientes")]
        public async Task<ActionResult> B2CConsultaClientes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientes")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaClientesContatos")]
        public async Task<ActionResult> B2CConsultaClientesContatos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesContatosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaClientesContatosParentesco")]
        public async Task<ActionResult> B2CConsultaClientesContatosParentesco()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesContatosParentescoService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaClientesEnderecosEntrega")]
        public async Task<ActionResult> B2CConsultaClientesEnderecosEntrega()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesEnderecosEntregaService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaClientesEstadoCivil")]
        public async Task<ActionResult> B2CConsultaClientesEstadoCivil()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesEstadoCivilService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaClientesSaldo")]
        public async Task<ActionResult> B2CConsultaClientesSaldo()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesSaldoService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaClientesSaldoLinx")]
        public async Task<ActionResult> B2CConsultaClientesSaldoLinx()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                    .FirstOrDefault();

                var result = await _b2cConsultaClientesSaldoLinxService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaCNPJsChave")]
        public async Task<ActionResult> B2CConsultaCNPJsChave()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                    .FirstOrDefault();

                var result = await _b2cConsultaCNPJsChaveService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaCodigoRastreio")]
        public async Task<ActionResult> B2CConsultaCodigoRastreio()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                    .FirstOrDefault();

                var result = await _b2cConsultaCodigoRastreioService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaColecoes")]
        public async Task<ActionResult> B2CConsultaColecoes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaColecoes")
                    .FirstOrDefault();

                var result = await _b2cConsultaColecoesService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaEmpresas")]
        public async Task<ActionResult> B2CConsultaEmpresas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaEmpresas")
                    .FirstOrDefault();

                var result = await _b2cConsultaEmpresasService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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
        
        [HttpPost("B2CConsultaEspessuras")]
        public async Task<ActionResult> B2CConsultaEspessuras()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaEspessuras")
                    .FirstOrDefault();

                var result = await _b2cConsultaEspessurasService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaFlags")]
        public async Task<ActionResult> B2CConsultaFlags()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaFlags")
                    .FirstOrDefault();

                var result = await _b2cConsultaFlagsService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaFormasPagamento")]
        public async Task<ActionResult> B2CConsultaFormasPagamento()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                    .FirstOrDefault();

                var result = await _b2cConsultaFormasPagamentoService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaFornecedores")]
        public async Task<ActionResult> B2CConsultaFornecedores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaFornecedores")
                    .FirstOrDefault();

                var result = await _b2cConsultaFornecedoresService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaGrade1")]
        public async Task<ActionResult> B2CConsultaGrade1()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaGrade1")
                    .FirstOrDefault();

                var result = await _b2cConsultaGrade1Service.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaGrade2")]
        public async Task<ActionResult> B2CConsultaGrade2()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaGrade2")
                    .FirstOrDefault();

                var result = await _b2cConsultaGrade2Service.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaImagens")]
        public async Task<ActionResult> B2CConsultaImagens()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaImagens")
                    .FirstOrDefault();

                var result = await _b2cConsultaImagensService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaImagensHD")]
        public async Task<ActionResult> B2CConsultaImagensHD()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaImagensHD")
                    .FirstOrDefault();

                var result = await _b2cConsultaImagensHDService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaLegendasCadastrosAuxiliares")]
        public async Task<ActionResult> B2CConsultaLegendasCadastrosAuxiliares()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                    .FirstOrDefault();

                var result = await _b2cConsultaLegendasCadastrosAuxiliaresService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaLinhas")]
        public async Task<ActionResult> B2CConsultaLinhas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaLinhas")
                    .FirstOrDefault();

                var result = await _b2cConsultaLinhasService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaMarcas")]
        public async Task<ActionResult> B2CConsultaMarcas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaMarcas")
                    .FirstOrDefault();

                var result = await _b2cConsultaMarcasService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaNFe")]
        public async Task<ActionResult> B2CConsultaNFe()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaNFe")
                    .FirstOrDefault();

                var result = await _b2cConsultaNFeService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaNFeSituacao")]
        public async Task<ActionResult> B2CConsultaNFeSituacao()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                    .FirstOrDefault();

                var result = await _b2cConsultaNFeSituacaoService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPalavrasChavePesquisa")]
        public async Task<ActionResult> B2CConsultaPalavrasChavePesquisa()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                    .FirstOrDefault();

                var result = await _b2cConsultaPalavrasChavePesquisaService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPedidos")]
        public async Task<ActionResult> B2CConsultaPedidos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPedidos")
                    .FirstOrDefault();

                var result = await _b2cConsultaPedidosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPedidosIdentificador")]
        public async Task<ActionResult> B2CConsultaPedidosIdentificador()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                    .FirstOrDefault();

                var result = await _b2cConsultaPedidosIdentificadorService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPedidosItens")]
        public async Task<ActionResult> B2CConsultaPedidosItens()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                    .FirstOrDefault();

                var result = await _b2cConsultaPedidosItensService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPedidosPlanos")]
        public async Task<ActionResult> B2CConsultaPedidosPlanos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                    .FirstOrDefault();

                var result = await _b2cConsultaPedidosPlanosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPedidosStatus")]
        public async Task<ActionResult> B2CConsultaPedidosStatus()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                    .FirstOrDefault();

                var result = await _b2cConsultaPedidosStatusService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPedidosTipos")]
        public async Task<ActionResult> B2CConsultaPedidosTipos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                    .FirstOrDefault();

                var result = await _b2cConsultaPedidosTiposService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPlanos")]
        public async Task<ActionResult> B2CConsultaPlanos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPlanos")
                    .FirstOrDefault();

                var result = await _b2cConsultaPlanosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaPlanosParcelas")]
        public async Task<ActionResult> B2CConsultaPlanosParcelas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                    .FirstOrDefault();

                var result = await _b2cConsultaPlanosParcelasService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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
        
        [HttpPost("B2CConsultaProdutos")]
        public async Task<ActionResult> B2CConsultaProdutos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutos")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosAssociados")]
        public async Task<ActionResult> B2CConsultaProdutosAssociados()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosAssociadosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosCampanhas")]
        public async Task<ActionResult> B2CConsultaProdutosCampanhas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosCampanhasService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosCamposAdicionaisDetalhes")]
        public async Task<ActionResult> B2CConsultaProdutosCamposAdicionaisDetalhes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosCamposAdicionaisDetalhesService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosCamposAdicionaisNomes")]
        public async Task<ActionResult> B2CConsultaProdutosCamposAdicionaisNomes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosCamposAdicionaisNomesService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosCamposAdicionaisValores")]
        public async Task<ActionResult> B2CConsultaProdutosCamposAdicionaisValores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosCamposAdicionaisValoresService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosCodebar")]
        public async Task<ActionResult> B2CConsultaProdutosCodebar()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosCodebarService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosCustos")]
        public async Task<ActionResult> B2CConsultaProdutosCustos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosCustosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosDepositos")]
        public async Task<ActionResult> B2CConsultaProdutosDepositos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosDepositosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosDetalhes")]
        public async Task<ActionResult> B2CConsultaProdutosDetalhes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosDetalhesService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosDetalhesDepositos")]
        public async Task<ActionResult> B2CConsultaProdutosDetalhesDepositos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosDetalhesDepositosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosDimensoes")]
        public async Task<ActionResult> B2CConsultaProdutosDimensoes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosDimensoesService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosFlags")]
        public async Task<ActionResult> B2CConsultaProdutosFlags()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosFlagsService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosImagens")]
        public async Task<ActionResult> B2CConsultaProdutosImagens()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosImagensService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosInformacoes")]
        public async Task<ActionResult> B2CConsultaProdutosInformacoes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosInformacoesService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosPalavrasChavePesquisa")]
        public async Task<ActionResult> B2CConsultaProdutosPalavrasChavePesquisa()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosPalavrasChavePesquisaService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosPromocao")]
        public async Task<ActionResult> B2CConsultaProdutosPromocao()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosPromocaoService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosStatus")]
        public async Task<ActionResult> B2CConsultaProdutosStatus()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosStatusService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosTabelas")]
        public async Task<ActionResult> B2CConsultaProdutosTabelas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosTabelasService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosTabelasPrecos")]
        public async Task<ActionResult> B2CConsultaProdutosTabelasPrecos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosTabelasPrecosService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaProdutosTags")]
        public async Task<ActionResult> B2CConsultaProdutosTags()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                    .FirstOrDefault();

                var result = await _b2cConsultaProdutosTagsService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaSetores")]
        public async Task<ActionResult> B2CConsultaSetores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaSetores")
                    .FirstOrDefault();

                var result = await _b2cConsultaSetoresService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaStatus")]
        public async Task<ActionResult> B2CConsultaStatus()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaStatus")
                    .FirstOrDefault();

                var result = await _b2cConsultaStatusService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaTags")]
        public async Task<ActionResult> B2CConsultaTags()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaTags")
                    .FirstOrDefault();

                var result = await _b2cConsultaTagsService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaTipoEncomenda")]
        public async Task<ActionResult> B2CConsultaTipoEncomenda()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                    .FirstOrDefault();

                var result = await _b2cConsultaTipoEncomendaService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaTiposCobrancaFrete")]
        public async Task<ActionResult> B2CConsultaTiposCobrancaFrete()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                    .FirstOrDefault();

                var result = await _b2cConsultaTiposCobrancaFreteService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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
        
        [HttpPost("B2CConsultaTransportadores")]
        public async Task<ActionResult> B2CConsultaTransportadores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaTransportadores")
                    .FirstOrDefault();

                var result = await _b2cConsultaTransportadoresService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaUnidade")]
        public async Task<ActionResult> B2CConsultaUnidade()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaUnidade")
                    .FirstOrDefault();

                var result = await _b2cConsultaUnidadeService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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

        [HttpPost("B2CConsultaVendedores")]
        public async Task<ActionResult> B2CConsultaVendedores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "B2CConsultaVendedores")
                    .FirstOrDefault();

                var result = await _b2cConsultaVendedoresService.GetRecords(
                    new JobParameter
                    {
                        docMainCompany = _docMainCompany,
                        projectName = _projectName,
                        keyAuthorization = _key,
                        userAuthentication = _authentication,
                        parametersTableName = _parametersTableName,
                        parametersLogTableName = _parametersLogTableName,
                        parametersInterval = _parametersInterval,
                        jobName = method.MethodName,
                        tableName = method.MethodName
                    }
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
