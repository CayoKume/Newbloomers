using FlashCourier.Application.Services;
using FlashCourier.Infrastructure.Repository;
using TotalExpress.Application.Services;
using TotalExpress.Infrastructure.Repository;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using IntegrationsCore.Domain.Entities.Parameters;
using IntegrationsCore.Infrastructure.Connections.SQLServer;
using LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxMicrovix;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxMicrovix;
//using LinxCommerce.Application.Services.Sales;

namespace WebJobsApplication.Domain.Extensions
{
    public static class ServicesExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddHostedServices();
                services.AddScopedSQLServerConnection();
                //services.AddScopedLinxCommerceServices();
                services.AddScopedLinxMicrovixServices();
                services.AddScopedB2CLinxMicrovixServices();
                services.AddScopedFlashCourierServices();
                services.AddScopedTotalExpressServices();
            });

            return builder;
        }

        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<Worker>();
            return services;
        }

        //public static IServiceCollection AddScopedLinxCommerceServices(this IServiceCollection services)
        //{
        //    services.AddScoped<LinxCommerce.Infrastructure.Api.IAPICall, LinxCommerce.Infrastructure.Api.APICall>();
        //    services.AddHttpClient("LinxCommerceAPI", client =>
        //    {
        //        client.BaseAddress = new Uri("https://misha.layer.core.dcg.com.br");
        //        client.Timeout = new TimeSpan(0, 20, 0);
        //    });

        //    services.AddScoped<ISalesService, SalesService>();

        //    return services;
        //}

        public static IServiceCollection AddScopedLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped(typeof(ILinxMicrovixRepositoryBase<>), typeof(LinxMicrovixRepositoryBase<>));
            services.AddScoped<LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.IAPICall, LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.APICall>();

            services.AddScoped<ILinxVendedoresService<LinxVendedores>, LinxVendedoresService<LinxVendedores>>();
            services.AddScoped<ILinxVendedoresRepository<LinxVendedores>, LinxVendedoresRepository<LinxVendedores>>();

            return services;
        }

        public static IServiceCollection AddScopedB2CLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped(typeof(ILinxMicrovixRepositoryBase<>), typeof(LinxMicrovixRepositoryBase<>));
            services.AddScoped<LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.IAPICall, LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.APICall>();

            services.AddScoped<IB2CConsultaClassificacaoService<B2CConsultaClassificacao>, B2CConsultaClassificacaoService<B2CConsultaClassificacao>>();
            services.AddScoped<IB2CConsultaClassificacaoRepository<B2CConsultaClassificacao>, B2CConsultaClassificacaoRepository<B2CConsultaClassificacao>>();

            services.AddScoped<IB2CConsultaClientesService<B2CConsultaClientes>, B2CConsultaClientesService<B2CConsultaClientes>>();
            services.AddScoped<IB2CConsultaClientesRepository<B2CConsultaClientes>, B2CConsultaClientesRepository<B2CConsultaClientes>>();

            services.AddScoped<IB2CConsultaClientesContatosService<B2CConsultaClientesContatos>, B2CConsultaClientesContatosService<B2CConsultaClientesContatos>>();
            services.AddScoped<IB2CConsultaClientesContatosRepository<B2CConsultaClientesContatos>, B2CConsultaClientesContatosRepository<B2CConsultaClientesContatos>>();

            services.AddScoped<IB2CConsultaClientesContatosParentescoService<B2CConsultaClientesContatosParentesco>, B2CConsultaClientesContatosParentescoService<B2CConsultaClientesContatosParentesco>>();
            services.AddScoped<IB2CConsultaClientesContatosParentescoRepository<B2CConsultaClientesContatosParentesco>, B2CConsultaClientesContatosParentescoRepository<B2CConsultaClientesContatosParentesco>>();

            services.AddScoped<IB2CConsultaClientesEnderecosEntregaService<B2CConsultaClientesEnderecosEntrega>, B2CConsultaClientesEnderecosEntregaService<B2CConsultaClientesEnderecosEntrega>>();
            services.AddScoped<IB2CConsultaClientesEnderecosEntregaRepository<B2CConsultaClientesEnderecosEntrega>, B2CConsultaClientesEnderecosEntregaRepository<B2CConsultaClientesEnderecosEntrega>>();

            services.AddScoped<IB2CConsultaClientesEstadoCivilService<B2CConsultaClientesEstadoCivil>, B2CConsultaClientesEstadoCivilService<B2CConsultaClientesEstadoCivil>>();
            services.AddScoped<IB2CConsultaClientesEstadoCivilRepository<B2CConsultaClientesEstadoCivil>, B2CConsultaClientesEstadoCivilRepository<B2CConsultaClientesEstadoCivil>>();

            services.AddScoped<IB2CConsultaClientesSaldoService<B2CConsultaClientesSaldo>, B2CConsultaClientesSaldoService<B2CConsultaClientesSaldo>>();
            services.AddScoped<IB2CConsultaClientesSaldoRepository<B2CConsultaClientesSaldo>, B2CConsultaClientesSaldoRepository<B2CConsultaClientesSaldo>>();

            services.AddScoped<IB2CConsultaClientesSaldoLinxService<B2CConsultaClientesSaldoLinx>, B2CConsultaClientesSaldoLinxService<B2CConsultaClientesSaldoLinx>>();
            services.AddScoped<IB2CConsultaClientesSaldoLinxRepository<B2CConsultaClientesSaldoLinx>, B2CConsultaClientesSaldoLinxRepository<B2CConsultaClientesSaldoLinx>>();

            services.AddScoped<IB2CConsultaCNPJsChaveService<B2CConsultaCNPJsChave>, B2CConsultaCNPJsChaveService<B2CConsultaCNPJsChave>>();
            services.AddScoped<IB2CConsultaCNPJsChaveRepository<B2CConsultaCNPJsChave>, B2CConsultaCNPJsChaveRepository<B2CConsultaCNPJsChave>>();

            services.AddScoped<IB2CConsultaCodigoRastreioService<B2CConsultaCodigoRastreio>, B2CConsultaCodigoRastreioService<B2CConsultaCodigoRastreio>>();
            services.AddScoped<IB2CConsultaCodigoRastreioRepository<B2CConsultaCodigoRastreio>, B2CConsultaCodigoRastreioRepository<B2CConsultaCodigoRastreio>>();

            services.AddScoped<IB2CConsultaColecoesService<B2CConsultaColecoes>, B2CConsultaColecoesService<B2CConsultaColecoes>>();
            services.AddScoped<IB2CConsultaColecoesRepository<B2CConsultaColecoes>, B2CConsultaColecoesRepository<B2CConsultaColecoes>>();

            services.AddScoped<IB2CConsultaEmpresasService<B2CConsultaEmpresas>, B2CConsultaEmpresasService<B2CConsultaEmpresas>>();
            services.AddScoped<IB2CConsultaEmpresasRepository<B2CConsultaEmpresas>, B2CConsultaEmpresasRepository<B2CConsultaEmpresas>>();

            services.AddScoped<IB2CConsultaEspessurasService<B2CConsultaEspessuras>, B2CConsultaEspessurasService<B2CConsultaEspessuras>>();
            services.AddScoped<IB2CConsultaEspessurasRepository<B2CConsultaEspessuras>, B2CConsultaEspessurasRepository<B2CConsultaEspessuras>>();

            services.AddScoped<IB2CConsultaFlagsService<B2CConsultaFlags>, B2CConsultaFlagsService<B2CConsultaFlags>>();
            services.AddScoped<IB2CConsultaFlagsRepository<B2CConsultaFlags>, B2CConsultaFlagsRepository<B2CConsultaFlags>>();

            services.AddScoped<IB2CConsultaFormasPagamentoService<B2CConsultaFormasPagamento>, B2CConsultaFormasPagamentoService<B2CConsultaFormasPagamento>>();
            services.AddScoped<IB2CConsultaFormasPagamentoRepository<B2CConsultaFormasPagamento>, B2CConsultaFormasPagamentoRepository<B2CConsultaFormasPagamento>>();

            services.AddScoped<IB2CConsultaFornecedoresService<B2CConsultaFornecedores>, B2CConsultaFornecedoresService<B2CConsultaFornecedores>>();
            services.AddScoped<IB2CConsultaFornecedoresRepository<B2CConsultaFornecedores>, B2CConsultaFornecedoresRepository<B2CConsultaFornecedores>>();

            services.AddScoped<IB2CConsultaGrade1Service<B2CConsultaGrade1>, B2CConsultaGrade1Service<B2CConsultaGrade1>>();
            services.AddScoped<IB2CConsultaGrade1Repository<B2CConsultaGrade1>, B2CConsultaGrade1Repository<B2CConsultaGrade1>>();

            services.AddScoped<IB2CConsultaGrade2Service<B2CConsultaGrade2>, B2CConsultaGrade2Service<B2CConsultaGrade2>>();
            services.AddScoped<IB2CConsultaGrade2Repository<B2CConsultaGrade2>, B2CConsultaGrade2Repository<B2CConsultaGrade2>>();

            services.AddScoped<IB2CConsultaImagensService<B2CConsultaImagens>, B2CConsultaImagensService<B2CConsultaImagens>>();
            services.AddScoped<IB2CConsultaImagensRepository<B2CConsultaImagens>, B2CConsultaImagensRepository<B2CConsultaImagens>>();

            services.AddScoped<IB2CConsultaImagensHDService<B2CConsultaImagensHD>, B2CConsultaImagensHDService<B2CConsultaImagensHD>>();
            services.AddScoped<IB2CConsultaImagensHDRepository<B2CConsultaImagensHD>, B2CConsultaImagensHDRepository<B2CConsultaImagensHD>>();

            services.AddScoped<IB2CConsultaLegendasCadastrosAuxiliaresService<B2CConsultaLegendasCadastrosAuxiliares>, B2CConsultaLegendasCadastrosAuxiliaresService<B2CConsultaLegendasCadastrosAuxiliares>>();
            services.AddScoped<IB2CConsultaLegendasCadastrosAuxiliaresRepository<B2CConsultaLegendasCadastrosAuxiliares>, B2CConsultaLegendasCadastrosAuxiliaresRepository<B2CConsultaLegendasCadastrosAuxiliares>>();

            services.AddScoped<IB2CConsultaLinhasService<B2CConsultaLinhas>, B2CConsultaLinhasService<B2CConsultaLinhas>>();
            services.AddScoped<IB2CConsultaLinhasRepository<B2CConsultaLinhas>, B2CConsultaLinhasRepository<B2CConsultaLinhas>>();

            services.AddScoped<IB2CConsultaMarcasService<B2CConsultaMarcas>, B2CConsultaMarcasService<B2CConsultaMarcas>>();
            services.AddScoped<IB2CConsultaMarcasRepository<B2CConsultaMarcas>, B2CConsultaMarcasRepository<B2CConsultaMarcas>>();

            services.AddScoped<IB2CConsultaNFeService<B2CConsultaNFe>, B2CConsultaNFeService<B2CConsultaNFe>>();
            services.AddScoped<IB2CConsultaNFeRepository<B2CConsultaNFe>, B2CConsultaNFeRepository<B2CConsultaNFe>>();

            services.AddScoped<IB2CConsultaNFeSituacaoService<B2CConsultaNFeSituacao>, B2CConsultaNFeSituacaoService<B2CConsultaNFeSituacao>>();
            services.AddScoped<IB2CConsultaNFeSituacaoRepository<B2CConsultaNFeSituacao>, B2CConsultaNFeSituacaoRepository<B2CConsultaNFeSituacao>>();

            services.AddScoped<IB2CConsultaPalavrasChavePesquisaService<B2CConsultaPalavrasChavePesquisa>, B2CConsultaPalavrasChavePesquisaService<B2CConsultaPalavrasChavePesquisa>>();
            services.AddScoped<IB2CConsultaPalavrasChavePesquisaRepository<B2CConsultaPalavrasChavePesquisa>, B2CConsultaPalavrasChavePesquisaRepository<B2CConsultaPalavrasChavePesquisa>>();

            services.AddScoped<IB2CConsultaPedidosService<B2CConsultaPedidos>, B2CConsultaPedidosService<B2CConsultaPedidos>>();
            services.AddScoped<IB2CConsultaPedidosRepository<B2CConsultaPedidos>, B2CConsultaPedidosRepository<B2CConsultaPedidos>>();

            services.AddScoped<IB2CConsultaPedidosIdentificadorService<B2CConsultaPedidosIdentificador>, B2CConsultaPedidosIdentificadorService<B2CConsultaPedidosIdentificador>>();
            services.AddScoped<IB2CConsultaPedidosIdentificadorRepository<B2CConsultaPedidosIdentificador>, B2CConsultaPedidosIdentificadorRepository<B2CConsultaPedidosIdentificador>>();

            services.AddScoped<IB2CConsultaPedidosItensService<B2CConsultaPedidosItens>, B2CConsultaPedidosItensService<B2CConsultaPedidosItens>>();
            services.AddScoped<IB2CConsultaPedidosItensRepository<B2CConsultaPedidosItens>, B2CConsultaPedidosItensRepository<B2CConsultaPedidosItens>>();

            services.AddScoped<IB2CConsultaPedidosPlanosService<B2CConsultaPedidosPlanos>, B2CConsultaPedidosPlanosService<B2CConsultaPedidosPlanos>>();
            services.AddScoped<IB2CConsultaPedidosPlanosRepository<B2CConsultaPedidosPlanos>, B2CConsultaPedidosPlanosRepository<B2CConsultaPedidosPlanos>>();

            services.AddScoped<IB2CConsultaPedidosStatusService<B2CConsultaPedidosStatus>, B2CConsultaPedidosStatusService<B2CConsultaPedidosStatus>>();
            services.AddScoped<IB2CConsultaPedidosStatusRepository<B2CConsultaPedidosStatus>, B2CConsultaPedidosStatusRepository<B2CConsultaPedidosStatus>>();

            services.AddScoped<IB2CConsultaPedidosTiposService<B2CConsultaPedidosTipos>, B2CConsultaPedidosTiposService<B2CConsultaPedidosTipos>>();
            services.AddScoped<IB2CConsultaPedidosTiposRepository<B2CConsultaPedidosTipos>, B2CConsultaPedidosTiposRepository<B2CConsultaPedidosTipos>>();

            services.AddScoped<IB2CConsultaPlanosService<B2CConsultaPlanos>, B2CConsultaPlanosService<B2CConsultaPlanos>>();
            services.AddScoped<IB2CConsultaPlanosRepository<B2CConsultaPlanos>, B2CConsultaPlanosRepository<B2CConsultaPlanos>>();

            services.AddScoped<IB2CConsultaPlanosParcelasService<B2CConsultaPlanosParcelas>, B2CConsultaPlanosParcelasService<B2CConsultaPlanosParcelas>>();
            services.AddScoped<IB2CConsultaPlanosParcelasRepository<B2CConsultaPlanosParcelas>, B2CConsultaPlanosParcelasRepository<B2CConsultaPlanosParcelas>>();

            services.AddScoped<IB2CConsultaProdutosService<B2CConsultaProdutos>, B2CConsultaProdutosService<B2CConsultaProdutos>>();
            services.AddScoped<IB2CConsultaProdutosRepository<B2CConsultaProdutos>, B2CConsultaProdutosRepository<B2CConsultaProdutos>>();

            services.AddScoped<IB2CConsultaProdutosAssociadosService<B2CConsultaProdutosAssociados>, B2CConsultaProdutosAssociadosService<B2CConsultaProdutosAssociados>>();
            services.AddScoped<IB2CConsultaProdutosAssociadosRepository<B2CConsultaProdutosAssociados>, B2CConsultaProdutosAssociadosRepository<B2CConsultaProdutosAssociados>>();

            services.AddScoped<IB2CConsultaProdutosCampanhasService<B2CConsultaProdutosCampanhas>, B2CConsultaProdutosCampanhasService<B2CConsultaProdutosCampanhas>>();
            services.AddScoped<IB2CConsultaProdutosCampanhasRepository<B2CConsultaProdutosCampanhas>, B2CConsultaProdutosCampanhasRepository<B2CConsultaProdutosCampanhas>>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisDetalhesService<B2CConsultaProdutosCamposAdicionaisDetalhes>, B2CConsultaProdutosCamposAdicionaisDetalhesService<B2CConsultaProdutosCamposAdicionaisDetalhes>>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisDetalhesRepository<B2CConsultaProdutosCamposAdicionaisDetalhes>, B2CConsultaProdutosCamposAdicionaisDetalhesRepository<B2CConsultaProdutosCamposAdicionaisDetalhes>>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisNomesService<B2CConsultaProdutosCamposAdicionaisNomes>, B2CConsultaProdutosCamposAdicionaisNomesService<B2CConsultaProdutosCamposAdicionaisNomes>>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisNomesRepository<B2CConsultaProdutosCamposAdicionaisNomes>, B2CConsultaProdutosCamposAdicionaisNomesRepository<B2CConsultaProdutosCamposAdicionaisNomes>>();

            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisValoresService<B2CConsultaProdutosCamposAdicionaisValores>, B2CConsultaProdutosCamposAdicionaisValoresService<B2CConsultaProdutosCamposAdicionaisValores>>();
            services.AddScoped<IB2CConsultaProdutosCamposAdicionaisValoresRepository<B2CConsultaProdutosCamposAdicionaisValores>, B2CConsultaProdutosCamposAdicionaisValoresRepository<B2CConsultaProdutosCamposAdicionaisValores>>();

            services.AddScoped<IB2CConsultaProdutosCodebarService<B2CConsultaProdutosCodebar>, B2CConsultaProdutosCodebarService<B2CConsultaProdutosCodebar>>();
            services.AddScoped<IB2CConsultaProdutosCodebarRepository<B2CConsultaProdutosCodebar>, B2CConsultaProdutosCodebarRepository<B2CConsultaProdutosCodebar>>();

            services.AddScoped<IB2CConsultaProdutosCustosService<B2CConsultaProdutosCustos>, B2CConsultaProdutosCustosService<B2CConsultaProdutosCustos>>();
            services.AddScoped<IB2CConsultaProdutosCustosRepository<B2CConsultaProdutosCustos>, B2CConsultaProdutosCustosRepository<B2CConsultaProdutosCustos>>();

            services.AddScoped<IB2CConsultaProdutosDepositosService<B2CConsultaProdutosDepositos>, B2CConsultaProdutosDepositosService<B2CConsultaProdutosDepositos>>();
            services.AddScoped<IB2CConsultaProdutosDepositosRepository<B2CConsultaProdutosDepositos>, B2CConsultaProdutosDepositosRepository<B2CConsultaProdutosDepositos>>();

            services.AddScoped<IB2CConsultaProdutosDetalhesService<B2CConsultaProdutosDetalhes>, B2CConsultaProdutosDetalhesService<B2CConsultaProdutosDetalhes>>();
            services.AddScoped<IB2CConsultaProdutosDetalhesRepository<B2CConsultaProdutosDetalhes>, B2CConsultaProdutosDetalhesRepository<B2CConsultaProdutosDetalhes>>();

            services.AddScoped<IB2CConsultaProdutosDetalhesDepositosService<B2CConsultaProdutosDetalhesDepositos>, B2CConsultaProdutosDetalhesDepositosService<B2CConsultaProdutosDetalhesDepositos>>();
            services.AddScoped<IB2CConsultaProdutosDetalhesDepositosRepository<B2CConsultaProdutosDetalhesDepositos>, B2CConsultaProdutosDetalhesDepositosRepository<B2CConsultaProdutosDetalhesDepositos>>();

            services.AddScoped<IB2CConsultaProdutosDimensoesService<B2CConsultaProdutosDimensoes>, B2CConsultaProdutosDimensoesService<B2CConsultaProdutosDimensoes>>();
            services.AddScoped<IB2CConsultaProdutosDimensoesRepository<B2CConsultaProdutosDimensoes>, B2CConsultaProdutosDimensoesRepository<B2CConsultaProdutosDimensoes>>();

            services.AddScoped<IB2CConsultaProdutosFlagsService<B2CConsultaProdutosFlags>, B2CConsultaProdutosFlagsService<B2CConsultaProdutosFlags>>();
            services.AddScoped<IB2CConsultaProdutosFlagsRepository<B2CConsultaProdutosFlags>, B2CConsultaProdutosFlagsRepository<B2CConsultaProdutosFlags>>();

            services.AddScoped<IB2CConsultaProdutosImagensService<B2CConsultaProdutosImagens>, B2CConsultaProdutosImagensService<B2CConsultaProdutosImagens>>();
            services.AddScoped<IB2CConsultaProdutosImagensRepository<B2CConsultaProdutosImagens>, B2CConsultaProdutosImagensRepository<B2CConsultaProdutosImagens>>();

            services.AddScoped<IB2CConsultaProdutosInformacoesService<B2CConsultaProdutosInformacoes>, B2CConsultaProdutosInformacoesService<B2CConsultaProdutosInformacoes>>();
            services.AddScoped<IB2CConsultaProdutosInformacoesRepository<B2CConsultaProdutosInformacoes>, B2CConsultaProdutosInformacoesRepository<B2CConsultaProdutosInformacoes>>();

            services.AddScoped<IB2CConsultaProdutosPalavrasChavePesquisaService<B2CConsultaProdutosPalavrasChavePesquisa>, B2CConsultaProdutosPalavrasChavePesquisaService<B2CConsultaProdutosPalavrasChavePesquisa>>();
            services.AddScoped<IB2CConsultaProdutosPalavrasChavePesquisaRepository<B2CConsultaProdutosPalavrasChavePesquisa>, B2CConsultaProdutosPalavrasChavePesquisaRepository<B2CConsultaProdutosPalavrasChavePesquisa>>();

            services.AddScoped<IB2CConsultaProdutosPromocaoService<B2CConsultaProdutosPromocao>, B2CConsultaProdutosPromocaoService<B2CConsultaProdutosPromocao>>();
            services.AddScoped<IB2CConsultaProdutosPromocaoRepository<B2CConsultaProdutosPromocao>, B2CConsultaProdutosPromocaoRepository<B2CConsultaProdutosPromocao>>();

            services.AddScoped<IB2CConsultaProdutosStatusService<B2CConsultaProdutosStatus>, B2CConsultaProdutosStatusService<B2CConsultaProdutosStatus>>();
            services.AddScoped<IB2CConsultaProdutosStatusRepository<B2CConsultaProdutosStatus>, B2CConsultaProdutosStatusRepository<B2CConsultaProdutosStatus>>();

            services.AddScoped<IB2CConsultaProdutosTabelasService<B2CConsultaProdutosTabelas>, B2CConsultaProdutosTabelasService<B2CConsultaProdutosTabelas>>();
            services.AddScoped<IB2CConsultaProdutosTabelasRepository<B2CConsultaProdutosTabelas>, B2CConsultaProdutosTabelasRepository<B2CConsultaProdutosTabelas>>();

            services.AddScoped<IB2CConsultaProdutosTabelasPrecosService<B2CConsultaProdutosTabelasPrecos>, B2CConsultaProdutosTabelasPrecosService<B2CConsultaProdutosTabelasPrecos>>();
            services.AddScoped<IB2CConsultaProdutosTabelasPrecosRepository<B2CConsultaProdutosTabelasPrecos>, B2CConsultaProdutosTabelasPrecosRepository<B2CConsultaProdutosTabelasPrecos>>();

            services.AddScoped<IB2CConsultaProdutosTagsService<B2CConsultaProdutosTags>, B2CConsultaProdutosTagsService<B2CConsultaProdutosTags>>();
            services.AddScoped<IB2CConsultaProdutosTagsRepository<B2CConsultaProdutosTags>, B2CConsultaProdutosTagsRepository<B2CConsultaProdutosTags>>();

            services.AddScoped<IB2CConsultaSetoresService<B2CConsultaSetores>, B2CConsultaSetoresService<B2CConsultaSetores>>();
            services.AddScoped<IB2CConsultaSetoresRepository<B2CConsultaSetores>, B2CConsultaSetoresRepository<B2CConsultaSetores>>();

            services.AddScoped<IB2CConsultaStatusService<B2CConsultaStatus>, B2CConsultaStatusService<B2CConsultaStatus>>();
            services.AddScoped<IB2CConsultaStatusRepository<B2CConsultaStatus>, B2CConsultaStatusRepository<B2CConsultaStatus>>();

            services.AddScoped<IB2CConsultaTagsService<B2CConsultaTags>, B2CConsultaTagsService<B2CConsultaTags>>();
            services.AddScoped<IB2CConsultaTagsRepository<B2CConsultaTags>, B2CConsultaTagsRepository<B2CConsultaTags>>();

            services.AddScoped<IB2CConsultaTipoEncomendaService<B2CConsultaTipoEncomenda>, B2CConsultaTipoEncomendaService<B2CConsultaTipoEncomenda>>();
            services.AddScoped<IB2CConsultaTipoEncomendaRepository<B2CConsultaTipoEncomenda>, B2CConsultaTipoEncomendaRepository<B2CConsultaTipoEncomenda>>();

            services.AddScoped<IB2CConsultaTiposCobrancaFreteService<B2CConsultaTiposCobrancaFrete>, B2CConsultaTiposCobrancaFreteService<B2CConsultaTiposCobrancaFrete>>();
            services.AddScoped<IB2CConsultaTiposCobrancaFreteRepository<B2CConsultaTiposCobrancaFrete>, B2CConsultaTiposCobrancaFreteRepository<B2CConsultaTiposCobrancaFrete>>();

            services.AddScoped<IB2CConsultaTransportadoresService<B2CConsultaTransportadores>, B2CConsultaTransportadoresService<B2CConsultaTransportadores>>();
            services.AddScoped<IB2CConsultaTransportadoresRepository<B2CConsultaTransportadores>, B2CConsultaTransportadoresRepository<B2CConsultaTransportadores>>();

            services.AddScoped<IB2CConsultaUnidadeService<B2CConsultaUnidade>, B2CConsultaUnidadeService<B2CConsultaUnidade>>();
            services.AddScoped<IB2CConsultaUnidadeRepository<B2CConsultaUnidade>, B2CConsultaUnidadeRepository<B2CConsultaUnidade>>();

            services.AddScoped<IB2CConsultaVendedoresService<B2CConsultaVendedores>, B2CConsultaVendedoresService<B2CConsultaVendedores>>();
            services.AddScoped<IB2CConsultaVendedoresRepository<B2CConsultaVendedores>, B2CConsultaVendedoresRepository<B2CConsultaVendedores>>();

            return services;
        }

        public static IServiceCollection AddScopedTotalExpressServices(this IServiceCollection services)
        {
            services.AddScoped<TotalExpress.Infrastructure.Api.IAPICall, TotalExpress.Infrastructure.Api.APICall>();
            services.AddHttpClient("TotalExpressAPI", client =>
            {
                client.BaseAddress = new Uri("https://apis.totalexpress.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });
            services.AddHttpClient("TotalExpressEdiAPI", client =>
            {
                client.BaseAddress = new Uri("https://edi.totalexpress.com.br/");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<ITotalExpressService, TotalExpressService>();
            services.AddScoped<ITotalExpressRepository, TotalExpressRepository>();

            return services;
        }

        public static IServiceCollection AddScopedFlashCourierServices(this IServiceCollection services)
        {
            services.AddScoped<FlashCourier.Infrastructure.Api.IAPICall, FlashCourier.Infrastructure.Api.APICall>();
            services.AddHttpClient("FlashCourierAPI", client =>
            {
                //HOMOLOG
                //client.BaseAddress = new Uri("https://homolog.flashpegasus.com.br/FlashPegasus/rest");

                client.BaseAddress = new Uri("https://webservice.flashpegasus.com.br/FlashPegasus/rest");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<IFlashCourierService, FlashCourierService>();
            services.AddScoped<IFlashCourierRepository, FlashCourierRepository>();

            return services;
        }

        public static IServiceCollection AddScopedSQLServerConnection(this IServiceCollection services)
        {
            services.AddScoped<ISQLServerConnection, SQLServerConnection>();
            services.AddScoped<IGeneralConnection, GeneralConnection>();
            services.AddScoped<ILinxCommerceConnection, LinxCommerceConnection>();
            services.AddScoped<ILinxMicrovixConnection, LinxMicrovixConnection>();

            //services.AddScoped<IDBInitializationRepository<ServerParameter>, DBInitializationRepository<ServerParameter>>();
            //services.AddScoped<IDBInitializationRepository<LinxAPIParam>, DBInitializationRepository<LinxAPIParam>>();
            //services.AddScoped<IDBInitializationRepository<LinxAPILog>, DBInitializationRepository<LinxAPILog>>();

            return services;
        }

    }
}
