using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services;
using Application.LinxMicrovix.Outbound.WebService.Services.Base;
using Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Api;
using Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxCommerce;
using Infrastructure.LinxMicrovix.Outbound.WebService.Repositorys.Dapper.Base;
using Infrastructure.LinxMicrovix.Outbound.WebService.Repository.Dapper.LinxMicrovix;
using LinxMicrovix.Outbound.Web.Service.Application.Services.LinxMicrovix;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddScopedB2CLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped(typeof(ILinxMicrovixAzureSQLRepositoryBase<>), typeof(LinxMicrovixAzureSQLRepositoryBase<>));
            services.AddScoped(typeof(ILinxMicrovixSQLServerRepositoryBase<>), typeof(LinxMicrovixSQLServerRepositoryBase<>));
            services.AddScoped<IAPICall, APICall>();

            services.AddScoped<IB2CConsultaClassificacaoService, B2CConsultaClassificacaoService>();
            services.AddScoped<IB2CConsultaClassificacaoRepository, B2CConsultaClassificacaoRepository>();

            services.AddScoped<IB2CConsultaClientesService, B2CConsultaClientesService>();
            services.AddScoped<IB2CConsultaClientesRepository, B2CConsultaClientesRepository>();

            services.AddScoped<IB2CConsultaClientesContatosService, B2CConsultaClientesContatosService>();
            services.AddScoped<IB2CConsultaClientesContatosRepository, B2CConsultaClientesContatosRepository>();

            services.AddScoped<IB2CConsultaClientesContatosParentescoService, B2CConsultaClientesContatosParentescoService>();
            services.AddScoped<IB2CConsultaClientesContatosParentescoRepository, B2CConsultaClientesContatosParentescoRepository>();

            services.AddScoped<IB2CConsultaClientesEnderecosEntregaService, B2CConsultaClientesEnderecosEntregaService>();
            services.AddScoped<IB2CConsultaClientesEnderecosEntregaRepository, B2CConsultaClientesEnderecosEntregaRepository>();

            services.AddScoped<IB2CConsultaClientesEstadoCivilService, B2CConsultaClientesEstadoCivilService>();
            services.AddScoped<IB2CConsultaClientesEstadoCivilRepository, B2CConsultaClientesEstadoCivilRepository>();

            services.AddScoped<IB2CConsultaClientesSaldoService, B2CConsultaClientesSaldoService>();
            services.AddScoped<IB2CConsultaClientesSaldoRepository, B2CConsultaClientesSaldoRepository>();

            services.AddScoped<IB2CConsultaClientesSaldoLinxService, B2CConsultaClientesSaldoLinxService>();
            services.AddScoped<IB2CConsultaClientesSaldoLinxRepository, B2CConsultaClientesSaldoLinxRepository>();

            services.AddScoped<IB2CConsultaCNPJsChaveService, B2CConsultaCNPJsChaveService>();
            services.AddScoped<IB2CConsultaCNPJsChaveRepository, B2CConsultaCNPJsChaveRepository>();

            services.AddScoped<IB2CConsultaCodigoRastreioService, B2CConsultaCodigoRastreioService>();
            services.AddScoped<IB2CConsultaCodigoRastreioRepository, B2CConsultaCodigoRastreioRepository>();

            services.AddScoped<IB2CConsultaColecoesService, B2CConsultaColecoesService>();
            services.AddScoped<IB2CConsultaColecoesRepository, B2CConsultaColecoesRepository>();

            services.AddScoped<IB2CConsultaEmpresasService, B2CConsultaEmpresasService>();
            services.AddScoped<IB2CConsultaEmpresasRepository, B2CConsultaEmpresasRepository>();

            services.AddScoped<IB2CConsultaEspessurasService, B2CConsultaEspessurasService>();
            services.AddScoped<IB2CConsultaEspessurasRepository, B2CConsultaEspessurasRepository>();

            services.AddScoped<IB2CConsultaFlagsService, B2CConsultaFlagsService>();
            services.AddScoped<IB2CConsultaFlagsRepository, B2CConsultaFlagsRepository>();

            services.AddScoped<IB2CConsultaFormasPagamentoService, B2CConsultaFormasPagamentoService>();
            services.AddScoped<IB2CConsultaFormasPagamentoRepository, B2CConsultaFormasPagamentoRepository>();

            services.AddScoped<IB2CConsultaFornecedoresService, B2CConsultaFornecedoresService>();
            services.AddScoped<IB2CConsultaFornecedoresRepository, B2CConsultaFornecedoresRepository>();

            services.AddScoped<IB2CConsultaGrade1Service, B2CConsultaGrade1Service>();
            services.AddScoped<IB2CConsultaGrade1Repository, B2CConsultaGrade1Repository>();

            services.AddScoped<IB2CConsultaGrade2Service, B2CConsultaGrade2Service>();
            services.AddScoped<IB2CConsultaGrade2Repository, B2CConsultaGrade2Repository>();

            services.AddScoped<IB2CConsultaImagensService, B2CConsultaImagensService>();
            services.AddScoped<IB2CConsultaImagensRepository, B2CConsultaImagensRepository>();

            services.AddScoped<IB2CConsultaImagensHDService, B2CConsultaImagensHDService>();
            services.AddScoped<IB2CConsultaImagensHDRepository, B2CConsultaImagensHDRepository>();

            services.AddScoped<IB2CConsultaLegendasCadastrosAuxiliaresService, B2CConsultaLegendasCadastrosAuxiliaresService>();
            services.AddScoped<IB2CConsultaLegendasCadastrosAuxiliaresRepository, B2CConsultaLegendasCadastrosAuxiliaresRepository>();

            services.AddScoped<IB2CConsultaLinhasService, B2CConsultaLinhasService>();
            services.AddScoped<IB2CConsultaLinhasRepository, B2CConsultaLinhasRepository>();

            services.AddScoped<IB2CConsultaMarcasService, B2CConsultaMarcasService>();
            services.AddScoped<IB2CConsultaMarcasRepository, B2CConsultaMarcasRepository>();

            services.AddScoped<IB2CConsultaNFeService, B2CConsultaNFeService>();
            services.AddScoped<IB2CConsultaNFeRepository, B2CConsultaNFeRepository>();

            services.AddScoped<IB2CConsultaNFeSituacaoService, B2CConsultaNFeSituacaoService>();
            services.AddScoped<IB2CConsultaNFeSituacaoRepository, B2CConsultaNFeSituacaoRepository>();

            services.AddScoped<IB2CConsultaPalavrasChavePesquisaService, B2CConsultaPalavrasChavePesquisaService>();
            services.AddScoped<IB2CConsultaPalavrasChavePesquisaRepository, B2CConsultaPalavrasChavePesquisaRepository>();

            services.AddScoped<IB2CConsultaPedidosService, B2CConsultaPedidosService>();
            services.AddScoped<IB2CConsultaPedidosRepository, B2CConsultaPedidosRepository>();

            services.AddScoped<IB2CConsultaPedidosIdentificadorService, B2CConsultaPedidosIdentificadorService>();
            services.AddScoped<IB2CConsultaPedidosIdentificadorRepository, B2CConsultaPedidosIdentificadorRepository>();

            services.AddScoped<IB2CConsultaPedidosItensService, B2CConsultaPedidosItensService>();
            services.AddScoped<IB2CConsultaPedidosItensRepository, B2CConsultaPedidosItensRepository>();

            services.AddScoped<IB2CConsultaPedidosPlanosService, B2CConsultaPedidosPlanosService>();
            services.AddScoped<IB2CConsultaPedidosPlanosRepository, B2CConsultaPedidosPlanosRepository>();

            services.AddScoped<IB2CConsultaPedidosStatusService, B2CConsultaPedidosStatusService>();
            services.AddScoped<IB2CConsultaPedidosStatusRepository, B2CConsultaPedidosStatusRepository>();

            services.AddScoped<IB2CConsultaPedidosTiposService, B2CConsultaPedidosTiposService>();
            services.AddScoped<IB2CConsultaPedidosTiposRepository, B2CConsultaPedidosTiposRepository>();

            services.AddScoped<IB2CConsultaPlanosService, B2CConsultaPlanosService>();
            services.AddScoped<IB2CConsultaPlanosRepository, B2CConsultaPlanosRepository>();

            services.AddScoped<IB2CConsultaPlanosParcelasService, B2CConsultaPlanosParcelasService>();
            services.AddScoped<IB2CConsultaPlanosParcelasRepository, B2CConsultaPlanosParcelasRepository>();

            services.AddScoped<IB2CConsultaProdutosService, B2CConsultaProdutosService>();
            services.AddScoped<IB2CConsultaProdutosRepository, B2CConsultaProdutosRepository>();

            services.AddScoped<IB2CConsultaProdutosAssociadosService, B2CConsultaProdutosAssociadosService>();
            services.AddScoped<IB2CConsultaProdutosAssociadosRepository, B2CConsultaProdutosAssociadosRepository>();

            services.AddScoped<IB2CConsultaProdutosCampanhasService, B2CConsultaProdutosCampanhasService>();
            services.AddScoped<IB2CConsultaProdutosCampanhasRepository, B2CConsultaProdutosCampanhasRepository>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisDetalhesService, B2CConsultaProdutosCamposAdicionaisDetalhesService>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisDetalhesRepository, B2CConsultaProdutosCamposAdicionaisDetalhesRepository>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisNomesService, B2CConsultaProdutosCamposAdicionaisNomesService>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisNomesRepository, B2CConsultaProdutosCamposAdicionaisNomesRepository>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisValoresService, B2CConsultaProdutosCamposAdicionaisValoresService>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisValoresRepository, B2CConsultaProdutosCamposAdicionaisValoresRepository>();

            services.AddScoped<IB2CConsultaProdutosCodebarService, B2CConsultaProdutosCodebarService>();
            services.AddScoped<IB2CConsultaProdutosCodebarRepository, B2CConsultaProdutosCodebarRepository>();

            services.AddScoped<IB2CConsultaProdutosCustosService, B2CConsultaProdutosCustosService>();
            services.AddScoped<IB2CConsultaProdutosCustosRepository, B2CConsultaProdutosCustosRepository>();

            services.AddScoped<IB2CConsultaProdutosDepositosService, B2CConsultaProdutosDepositosService>();
            services.AddScoped<IB2CConsultaProdutosDepositosRepository, B2CConsultaProdutosDepositosRepository>();

            services.AddScoped<IB2CConsultaProdutosDetalhesService, B2CConsultaProdutosDetalhesService>();
            services.AddScoped<IB2CConsultaProdutosDetalhesRepository, B2CConsultaProdutosDetalhesRepository>();

            services.AddScoped<IB2CConsultaProdutosDetalhesDepositosService, B2CConsultaProdutosDetalhesDepositosService>();
            services.AddScoped<IB2CConsultaProdutosDetalhesDepositosRepository, B2CConsultaProdutosDetalhesDepositosRepository>();

            services.AddScoped<IB2CConsultaProdutosDimensoesService, B2CConsultaProdutosDimensoesService>();
            services.AddScoped<IB2CConsultaProdutosDimensoesRepository, B2CConsultaProdutosDimensoesRepository>();

            services.AddScoped<IB2CConsultaProdutosFlagsService, B2CConsultaProdutosFlagsService>();
            services.AddScoped<IB2CConsultaProdutosFlagsRepository, B2CConsultaProdutosFlagsRepository>();

            services.AddScoped<IB2CConsultaProdutosImagensService, B2CConsultaProdutosImagensService>();
            services.AddScoped<IB2CConsultaProdutosImagensRepository, B2CConsultaProdutosImagensRepository>();

            services.AddScoped<IB2CConsultaProdutosInformacoesService, B2CConsultaProdutosInformacoesService>();
            services.AddScoped<IB2CConsultaProdutosInformacoesRepository, B2CConsultaProdutosInformacoesRepository>();

            services.AddScoped<IB2CConsultaProdutosPalavrasChavePesquisaService, B2CConsultaProdutosPalavrasChavePesquisaService>();
            services.AddScoped<IB2CConsultaProdutosPalavrasChavePesquisaRepository, B2CConsultaProdutosPalavrasChavePesquisaRepository>();

            services.AddScoped<IB2CConsultaProdutosPromocaoService, B2CConsultaProdutosPromocaoService>();
            services.AddScoped<IB2CConsultaProdutosPromocaoRepository, B2CConsultaProdutosPromocaoRepository>();

            services.AddScoped<IB2CConsultaProdutosStatusService, B2CConsultaProdutosStatusService>();
            services.AddScoped<IB2CConsultaProdutosStatusRepository, B2CConsultaProdutosStatusRepository>();

            services.AddScoped<IB2CConsultaProdutosTabelasService, B2CConsultaProdutosTabelasService>();
            services.AddScoped<IB2CConsultaProdutosTabelasRepository, B2CConsultaProdutosTabelasRepository>();

            services.AddScoped<IB2CConsultaProdutosTabelasPrecosService, B2CConsultaProdutosTabelasPrecosService>();
            services.AddScoped<IB2CConsultaProdutosTabelasPrecosRepository, B2CConsultaProdutosTabelasPrecosRepository>();

            services.AddScoped<IB2CConsultaProdutosTagsService, B2CConsultaProdutosTagsService>();
            services.AddScoped<IB2CConsultaProdutosTagsRepository, B2CConsultaProdutosTagsRepository>();

            services.AddScoped<IB2CConsultaSetoresService, B2CConsultaSetoresService>();
            services.AddScoped<IB2CConsultaSetoresRepository, B2CConsultaSetoresRepository>();

            services.AddScoped<IB2CConsultaStatusService, B2CConsultaStatusService>();
            services.AddScoped<IB2CConsultaStatusRepository, B2CConsultaStatusRepository>();

            services.AddScoped<IB2CConsultaTagsService, B2CConsultaTagsService>();
            services.AddScoped<IB2CConsultaTagsRepository, B2CConsultaTagsRepository>();

            services.AddScoped<IB2CConsultaTipoEncomendaService, B2CConsultaTipoEncomendaService>();
            services.AddScoped<IB2CConsultaTipoEncomendaRepository, B2CConsultaTipoEncomendaRepository>();

            services.AddScoped<IB2CConsultaTiposCobrancaFreteService, B2CConsultaTiposCobrancaFreteService>();
            services.AddScoped<IB2CConsultaTiposCobrancaFreteRepository, B2CConsultaTiposCobrancaFreteRepository>();

            services.AddScoped<IB2CConsultaTransportadoresService, B2CConsultaTransportadoresService>();
            services.AddScoped<IB2CConsultaTransportadoresRepository, B2CConsultaTransportadoresRepository>();

            services.AddScoped<IB2CConsultaUnidadeService, B2CConsultaUnidadeService>();
            services.AddScoped<IB2CConsultaUnidadeRepository, B2CConsultaUnidadeRepository>();

            services.AddScoped<IB2CConsultaVendedoresService, B2CConsultaVendedoresService>();
            services.AddScoped<IB2CConsultaVendedoresRepository, B2CConsultaVendedoresRepository>();

            return services;
        }

        public static IServiceCollection AddScopedLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped(typeof(ILinxMicrovixAzureSQLRepositoryBase<>), typeof(LinxMicrovixAzureSQLRepositoryBase<>));
            services.AddScoped(typeof(ILinxMicrovixSQLServerRepositoryBase<>), typeof(LinxMicrovixSQLServerRepositoryBase<>));
            services.AddScoped<IAPICall, APICall>();

            services.AddScoped<ILinxClientesFornecService, LinxClientesFornecService>();
            services.AddScoped<ILinxClientesFornecRepository, LinxClientesFornecRepository>();

            services.AddScoped<ILinxClientesEnderecosEntregaService, LinxClientesEnderecosEntregaService>();
            services.AddScoped<ILinxClientesEnderecosEntregaRepository, LinxClientesEnderecosEntregaRepository>();

            services.AddScoped<ILinxMovimentoService, LinxMovimentoService>();
            services.AddScoped<ILinxMovimentoRepository, LinxMovimentoRepository>();

            services.AddScoped<ILinxMovimentoCartoesService, LinxMovimentoCartoesService>();
            services.AddScoped<ILinxMovimentoCartoesRepository, LinxMovimentoCartoesRepository>();

            services.AddScoped<ILinxMovimentoPlanosService, LinxMovimentoPlanosService>();
            services.AddScoped<ILinxMovimentoPlanosRepository, LinxMovimentoPlanosRepository>();

            services.AddScoped<ILinxMovimentoTrocasService, LinxMovimentoTrocasService>();
            services.AddScoped<ILinxMovimentoTrocasRepository, LinxMovimentoTrocasRepository>();

            services.AddScoped<ILinxPlanosService, LinxPlanosService>();
            services.AddScoped<ILinxPlanosRepository, LinxPlanosRepository>();

            services.AddScoped<ILinxNaturezaOperacaoService, LinxNaturezaOperacaoService>();
            services.AddScoped<ILinxNaturezaOperacaoRepository, LinxNaturezaOperacaoRepository>();

            services.AddScoped<ILinxProdutosService, LinxProdutosService>();
            services.AddScoped<ILinxProdutosRepository, LinxProdutosRepository>();

            services.AddScoped<ILinxProdutosCodBarService, LinxProdutosCodBarService>();
            services.AddScoped<ILinxProdutosCodBarRepository, LinxProdutosCodBarRepository>();

            services.AddScoped<ILinxProdutosTabelasService, LinxProdutosTabelasService>();
            services.AddScoped<ILinxProdutosTabelasRepository, LinxProdutosTabelasRepository>();

            services.AddScoped<ILinxProdutosTabelasPrecosService, LinxProdutosTabelasPrecosService>();
            services.AddScoped<ILinxProdutosTabelasPrecosRepository, LinxProdutosTabelasPrecosRepository>();

            services.AddScoped<ILinxProdutosInventarioService, LinxProdutosInventarioService>();
            services.AddScoped<ILinxProdutosInventarioRepository, LinxProdutosInventarioRepository>();

            services.AddScoped<ILinxProdutosDetalhesService, LinxProdutosDetalhesService>();
            services.AddScoped<ILinxProdutosDetalhesRepository, LinxProdutosDetalhesRepository>();

            services.AddScoped<ILinxProdutosDepositosService, LinxProdutosDepositosService>();
            services.AddScoped<ILinxProdutosDepositosRepository, LinxProdutosDepositosRepository>();

            services.AddScoped<ILinxProdutosPromocoesService, LinxProdutosPromocoesService>();
            services.AddScoped<ILinxProdutosPromocoesRepository, LinxProdutosPromocoesRepository>();

            services.AddScoped<ILinxProdutosCamposAdicionaisService, LinxProdutosCamposAdicionaisService>();
            services.AddScoped<ILinxProdutosCamposAdicionaisRepository, LinxProdutosCamposAdicionaisRepository>();

            services.AddScoped<ILinxB2CPedidosService, LinxB2CPedidosService>();
            services.AddScoped<ILinxB2CPedidosRepository, LinxB2CPedidosRepository>();

            services.AddScoped<ILinxB2CPedidosItensService, LinxB2CPedidosItensService>();
            services.AddScoped<ILinxB2CPedidosItensRepository, LinxB2CPedidosItensRepository>();

            services.AddScoped<ILinxB2CPedidosStatusService, LinxB2CPedidosStatusService>();
            services.AddScoped<ILinxB2CPedidosStatusRepository, LinxB2CPedidosStatusRepository>();

            services.AddScoped<ILinxB2CStatusService, LinxB2CStatusService>();
            services.AddScoped<ILinxB2CStatusRepository, LinxB2CStatusRepository>();

            services.AddScoped<ILinxPedidosVendaService, LinxPedidosVendaService>();
            services.AddScoped<ILinxPedidosVendaRepository, LinxPedidosVendaRepository>();

            services.AddScoped<ILinxPedidosCompraService, LinxPedidosCompraService>();
            services.AddScoped<ILinxPedidosCompraRepository, LinxPedidosCompraRepository>();

            services.AddScoped<ILinxGrupoLojasService, LinxGrupoLojasService>();
            services.AddScoped<ILinxGrupoLojasRepository, LinxGrupoLojasRepository>();

            services.AddScoped<ILinxLojasService, LinxLojasService>();
            services.AddScoped<ILinxLojasRepository, LinxLojasRepository>();

            services.AddScoped<ILinxSetoresService, LinxSetoresService>();
            services.AddScoped<ILinxSetoresRepository, LinxSetoresRepository>();

            services.AddScoped<ILinxVendedoresService, LinxVendedoresService>();
            services.AddScoped<ILinxVendedoresRepository, LinxVendedoresRepository>();

            services.AddScoped<ILinxUsuariosService, LinxUsuariosService>();
            services.AddScoped<ILinxUsuariosRepository, LinxUsuariosRepository>();

            services.AddScoped<ILinxCfopFiscalService, LinxCfopFiscalService>();
            services.AddScoped<ILinxCfopFiscalRepository, LinxCfopFiscalRepository>();

            services.AddScoped<ILinxRotinaOrigemService, LinxRotinaOrigemService>();
            services.AddScoped<ILinxRotinaOrigemRepository, LinxRotinaOrigemRepository>();

            services.AddScoped<ILinxXMLDocumentosService, LinxXMLDocumentosService>();
            services.AddScoped<ILinxXMLDocumentosRepository, LinxXMLDocumentosRepository>();

            return services;
        }
    }
}
