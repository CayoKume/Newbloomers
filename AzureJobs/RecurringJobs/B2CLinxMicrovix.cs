using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Services;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs
{
    public class B2CLinxMicrovix
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

        public B2CLinxMicrovix
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

        //public async Task B2CConsultaClientes([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "B2CConsultaClientes")
        //        .FirstOrDefault();

        //        var result = await _b2cConsultaClientesService.GetRecords(
        //            _linxMicrovixJobParameter.SetParameters(
        //                jobName: method.MethodName,
        //                tableName: method.MethodName
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task B2CConsultaEmpresas([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "B2CConsultaEmpresas")
        //        .FirstOrDefault();

        //        var result = await _b2cConsultaEmpresasService.GetRecords(
        //            _linxMicrovixJobParameter.SetParameters(
        //                jobName: method.MethodName,
        //                tableName: method.MethodName
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task B2CConsultaNFe([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "B2CConsultaNFe")
        //        .FirstOrDefault();

        //        var result = await _b2cConsultaNFeService.GetRecords(
        //            _linxMicrovixJobParameter.SetParameters(
        //                jobName: method.MethodName,
        //                tableName: method.MethodName
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task B2CConsultaNFeSituacao([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
        //        .FirstOrDefault();

        //        var result = await _b2cConsultaNFeSituacaoService.GetRecords(
        //            _linxMicrovixJobParameter.SetParameters(
        //                jobName: method.MethodName,
        //                tableName: method.MethodName
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task B2CConsultaStatus([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "B2CConsultaStatus")
        //            .FirstOrDefault();

        //        var result = await _b2cConsultaStatusService.GetRecords(
        //            _linxMicrovixJobParameter.SetParameters(
        //                jobName: method.MethodName,
        //                tableName: method.MethodName
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public async Task B2CConsultaClassificacao([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "B2CConsultaClassificacao")
        //            .FirstOrDefault();

        //        var result = await _b2cConsultaClassificacaoService.GetRecords(
        //            _linxMicrovixJobParameter.SetParameters(
        //                jobName: method.MethodName,
        //                tableName: method.MethodName
        //            )
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
    }
}
