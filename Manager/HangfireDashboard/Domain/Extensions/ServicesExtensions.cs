using Hangfire;
using Hangfire.SqlServer;
using FlashCourier.Application.Services;
using FlashCourier.Infrastructure.Repository;
using FlashCourier.Domain.Entites;
using TotalExpress.Application.Services;
using TotalExpress.Infrastructure.Repository;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using HangfireDashboard.Infrastructure.Repository;
using HangfireDashboard.Domain.Entites;
using IntegrationsCore.Domain.Entities.Parameters;
using IntegrationsCore.Infrastructure.Connections.SQLServer;
using LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxMicrovix;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxMicrovix;
using LinxCommerce.Application.Services.Catolog.SKU;
using LinxCommerce.Infrastructure.Repository.Catolog.SKURepository;
using LinxCommerce.Infrastructure.Repository.Base;

namespace HangfireDashboard.Domain.Extensions
{
    public static class ServicesExtensions
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            var serverName = builder.Configuration.GetSection("ConfigureServer").GetSection("ServerName").Value;
            var connectionstring = builder.Configuration.GetConnectionString("Connection").Replace("[catalog]", "GENERAL").Replace("[database]", "GENERAL");

            builder.Services.AddScopedSQLServerConnection();

            builder.Services.AddScopedLinxCommerceServices();
            builder.Services.AddScopedLinxMicrovixServices();
            builder.Services.AddScopedB2CLinxMicrovixServices();
            builder.Services.AddScopedFlashCourierServices();
            builder.Services.AddScopedTotalExpressServices();

            builder.Services.AddHangfireService(connectionstring, serverName);

            return builder;
        }

        public static IServiceCollection AddScopedLinxCommerceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILinxCommerceRepositoryBase<>), typeof(LinxCommerceRepositoryBase<>));
            services.AddScoped<LinxCommerce.Infrastructure.Api.IAPICall, LinxCommerce.Infrastructure.Api.APICall>();
            services.AddHttpClient("LinxCommerceAPI", client =>
            {
                client.BaseAddress = new Uri("https://misha.layer.core.dcg.com.br");
                client.Timeout = new TimeSpan(0, 20, 0);
            });

            services.AddScoped<ISKUService, SKUService>();
            services.AddScoped<ISKURepository, SKURepository>();

            return services;
        }

        public static IServiceCollection AddScopedLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped(typeof(ILinxMicrovixRepositoryBase<>), typeof(LinxMicrovixRepositoryBase<>));
            services.AddScoped<LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.IAPICall, LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.APICall>();

            services.AddScoped<ILinxVendedoresService, LinxVendedoresService>();
            services.AddScoped<ILinxVendedoresRepository, LinxVendedoresRepository>();

            services.AddScoped<ILinxProdutosCodBarService, LinxProdutosCodBarService>();
            services.AddScoped<ILinxProdutosCodBarRepository, LinxProdutosCodBarRepository>();

            return services;
        }

        public static IServiceCollection AddScopedB2CLinxMicrovixServices(this IServiceCollection services)
        {
            services.AddScoped<ILinxMicrovixServiceBase, LinxMicrovixServiceBase>();
            services.AddScoped(typeof(ILinxMicrovixRepositoryBase<>), typeof(LinxMicrovixRepositoryBase<>));
            services.AddScoped<LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.IAPICall, LinxMicrovix_Outbound_Web_Service.Infrastructure.Api.APICall>();

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

            services.AddScoped<IDBInitializationRepository<ServerParameter>, DBInitializationRepository<ServerParameter>>();
            services.AddScoped<IDBInitializationRepository<LinxAPIParam>, DBInitializationRepository<LinxAPIParam>>();
            services.AddScoped<IDBInitializationRepository<LinxAPILog>, DBInitializationRepository<LinxAPILog>>();

            return services;
        }

        public static IServiceCollection AddHangfireService(this IServiceCollection services, string? connectionstring, string? serverName)
        {
            services.AddHangfire(configuration => configuration
                .UseFilter(new AutomaticRetryAttribute { Attempts = 0 })

                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionstring, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer(options =>
            {
                options.WorkerCount = 50;
                options.ServerName = serverName;
                options.Queues = new[] { serverName.ToLower() };
            });

            return services;
        }
    }
}
