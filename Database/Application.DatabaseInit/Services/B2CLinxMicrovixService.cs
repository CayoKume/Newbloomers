using Application.DatabaseInit.Interfaces;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.Parameters;
using Domain.DatabaseInit.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Application.DatabaseInit.Services
{
    public class B2CLinxMicrovixService : IB2CLinxMicrovixService
    {
        private readonly ILinxAPIParamRepository _linxAPIParamRepository;
        private readonly IB2CConsultaClassificacaoRepository _b2cConsultaClassificacaoRepository;
        private readonly IB2CConsultaClientesContatosRepository _b2cConsultaClientesContatosRepository;
        private readonly IB2CConsultaClientesContatosParentescoRepository _b2cConsultaClientesContatosParentescoRepository;
        private readonly IB2CConsultaClientesEnderecosEntregaRepository _b2cConsultaClientesEnderecosEntregaRepository;
        private readonly IB2CConsultaClientesEstadoCivilRepository _b2cConsultaClientesEstadoCivilRepository;
        private readonly IB2CConsultaClientesRepository _b2cConsultaClientesRepository;
        private readonly IB2CConsultaClientesSaldoLinxRepository _b2cConsultaClientesSaldoLinxRepository;
        private readonly IB2CConsultaClientesSaldoRepository _b2cConsultaClientesSaldoRepository;
        private readonly IB2CConsultaCNPJsChaveRepository _b2cConsultaCNPJsChaveRepository;
        private readonly IB2CConsultaCodigoRastreioRepository _b2cConsultaCodigoRastreioRepository;
        private readonly IB2CConsultaColecoesRepository _b2cConsultaColecoesRepository;
        private readonly IB2CConsultaEmpresasRepository _b2cConsultaEmpresasRepository;
        private readonly IB2CConsultaEspessurasRepository _b2cConsultaEspessurasRepository;
        private readonly IB2CConsultaFlagsRepository _b2cConsultaFlagsRepository;
        private readonly IB2CConsultaFormasPagamentoRepository _b2cConsultaFormasPagamentoRepository;
        private readonly IB2CConsultaFornecedoresRepository _b2cConsultaFornecedoresRepository;
        private readonly IB2CConsultaGrade1Repository _b2cConsultaGrade1Repository;
        private readonly IB2CConsultaGrade2Repository _b2cConsultaGrade2Repository;
        private readonly IB2CConsultaImagensHDRepository _b2cConsultaImagensHDRepository;
        private readonly IB2CConsultaImagensRepository _b2cConsultaImagensRepository;
        private readonly IB2CConsultaLegendasCadastrosAuxiliaresRepository _b2cConsultaLegendasCadastrosAuxiliaresRepository;
        private readonly IB2CConsultaLinhasRepository _b2cConsultaLinhasRepository;
        private readonly IB2CConsultaMarcasRepository _b2cConsultaMarcasRepository;
        private readonly IB2CConsultaNFeRepository _b2cConsultaNFeRepository;
        private readonly IB2CConsultaNFeSituacaoRepository _b2cConsultaNFeSituacaoRepository;
        private readonly IB2CConsultaPalavrasChavePesquisaRepository _b2cConsultaPalavrasChavePesquisaRepository;
        private readonly IB2CConsultaPedidosIdentificadorRepository _b2cConsultaPedidosIdentificadorRepository;
        private readonly IB2CConsultaPedidosItensRepository _b2cConsultaPedidosItensRepository;
        private readonly IB2CConsultaPedidosPlanosRepository _b2cConsultaPedidosPlanosRepository;
        private readonly IB2CConsultaPedidosRepository _b2cConsultaPedidosRepository;
        private readonly IB2CConsultaPedidosStatusRepository _b2cConsultaPedidosStatusRepository;
        private readonly IB2CConsultaPedidosTiposRepository _b2cConsultaPedidosTipRepository;
        private readonly IB2CConsultaPlanosParcelasRepository _b2cConsultaPlanosParcelasRepository;
        private readonly IB2CConsultaPlanosRepository _b2cConsultaPlanosRepository;
        private readonly IB2CConsultaProdutosAssociadosRepository _b2cConsultaProdutosAssociadosRepository;
        private readonly IB2CConsultaProdutosCampanhasRepository _b2cConsultaProdutosCampanhasRepository;
        private readonly IB2CConsultaProdutosCamposAdicionaisDetalhesRepository _b2cConsultaProdutosCamposAdicionaisDetalhesRepository;
        private readonly IB2CConsultaProdutosCamposAdicionaisNomesRepository _b2cConsultaProdutosCamposAdicionaisNomesRepository;
        private readonly IB2CConsultaProdutosCamposAdicionaisValoresRepository _b2cConsultaProdutosCamposAdicionaisValoresRepository;
        private readonly IB2CConsultaProdutosCodebarRepository _b2cConsultaProdutosCodebarRepository;
        private readonly IB2CConsultaProdutosCustosRepository _b2cConsultaProdutosCustosRepository;
        private readonly IB2CConsultaProdutosDepositosRepository _b2cConsultaProdutosDepositosRepository;
        private readonly IB2CConsultaProdutosDetalhesDepositosRepository _b2cConsultaProdutosDetalhesDepositosRepository;
        private readonly IB2CConsultaProdutosDetalhesRepository _b2cConsultaProdutosDetalhesDetalhesRepository;
        private readonly IB2CConsultaProdutosDimensoesRepository _b2cConsultaProdutosDimensoesRepository;
        private readonly IB2CConsultaProdutosFlagsRepository _b2cConsultaProdutosFlagsRepository;
        private readonly IB2CConsultaProdutosImagensRepository _b2cConsultaProdutosImagensRepository;
        private readonly IB2CConsultaProdutosInformacoesRepository _b2cConsultaProdutosInformacoesRepository;
        private readonly IB2CConsultaProdutosPalavrasChavePesquisaRepository _b2cConsultaProdutosPalavrasChavePesquisaRepository;
        private readonly IB2CConsultaProdutosPromocaoRepository _b2cConsultaProdutosPromocaoRepository;
        private readonly IB2CConsultaProdutosRepository _b2cConsultaProdutosRepository;
        private readonly IB2CConsultaProdutosStatusRepository _b2cConsultaProdutosStatusRepository;
        private readonly IB2CConsultaProdutosTabelasPrecosRepository _b2cConsultaProdutosTabelasPrecosRepository;
        private readonly IB2CConsultaProdutosTabelasRepository _b2cConsultaProdutosTabelasRepository;
        private readonly IB2CConsultaProdutosTagsRepository _b2cConsultaProdutosTagsRepository;
        private readonly IB2CConsultaSetoresRepository _b2cConsultaSetoresRepository;
        private readonly IB2CConsultaStatusRepository _b2cConsultaStatusRepository;
        private readonly IB2CConsultaTagsRepository _b2cConsultaTagsRepository;
        private readonly IB2CConsultaTipoEncomendaRepository _b2cConsultaTipoEncomendaRepository;
        private readonly IB2CConsultaTiposCobrancaFreteRepository _b2cConsultaTiposCobrancaFreteRepository;
        private readonly IB2CConsultaTransportadoresRepository _b2cConsultaTransportadoresRepository;
        private readonly IB2CConsultaUnidadeRepository _b2cConsultaUnidadeRepository;
        private readonly IB2CConsultaVendedoresRepository _b2cConsultaVendedoresRepository;

        public B2CLinxMicrovixService(
            ILinxAPIParamRepository linxAPIParamRepository,
            IB2CConsultaClassificacaoRepository b2cConsultaClassificacaoRepository,
            IB2CConsultaClientesContatosRepository b2cConsultaClientesContatosRepository,
            IB2CConsultaClientesContatosParentescoRepository b2cConsultaClientesContatosParentescoRepository,
            IB2CConsultaClientesEnderecosEntregaRepository b2cConsultaClientesEnderecosEntregaRepository,
            IB2CConsultaClientesEstadoCivilRepository b2cConsultaClientesEstadoCivilRepository,
            IB2CConsultaClientesRepository b2cConsultaClientesRepository,
            IB2CConsultaClientesSaldoLinxRepository b2cConsultaClientesSaldoLinxRepository,
            IB2CConsultaClientesSaldoRepository b2cConsultaClientesSaldoRepository,
            IB2CConsultaCNPJsChaveRepository b2cConsultaCNPJsChaveRepository,
            IB2CConsultaCodigoRastreioRepository b2cConsultaCodigoRastreioRepository,
            IB2CConsultaColecoesRepository b2cConsultaColecoesRepository,
            IB2CConsultaEmpresasRepository b2cConsultaEmpresasRepository,
            IB2CConsultaEspessurasRepository b2cConsultaEspessurasRepository,
            IB2CConsultaFlagsRepository b2cConsultaFlagsRepository,
            IB2CConsultaFormasPagamentoRepository b2cConsultaFormasPagamentoRepository,
            IB2CConsultaFornecedoresRepository b2cConsultaFornecedoresRepository,
            IB2CConsultaGrade1Repository b2cConsultaGrade1Repository,
            IB2CConsultaGrade2Repository b2cConsultaGrade2Repository,
            IB2CConsultaImagensHDRepository b2cConsultaImagensHDRepository,
            IB2CConsultaImagensRepository b2cConsultaImagensRepository,
            IB2CConsultaLegendasCadastrosAuxiliaresRepository b2cConsultaLegendasRepository,
            IB2CConsultaLinhasRepository b2cConsultaLinhasRepository,
            IB2CConsultaMarcasRepository b2cConsultaMarcasRepository,
            IB2CConsultaNFeRepository b2cConsultaNFeRepository,
            IB2CConsultaNFeSituacaoRepository b2cConsultaNFeSituacaoRepository,
            IB2CConsultaPalavrasChavePesquisaRepository b2cConsultaPalavrasChavePesquisaRepository,
            IB2CConsultaPedidosIdentificadorRepository b2cConsultaPedidosIdentificadorRepository,
            IB2CConsultaPedidosItensRepository b2cConsultaPedidosItensRepository,
            IB2CConsultaPedidosPlanosRepository b2cConsultaPedidosPlanosRepository,
            IB2CConsultaPedidosRepository b2cConsultaPedidosRepository,
            IB2CConsultaPedidosStatusRepository b2cConsultaPedidosStatusRepository,
            IB2CConsultaPedidosTiposRepository b2cConsultaPedidosTipRepository,
            IB2CConsultaPlanosParcelasRepository b2cConsultaPlanosParcelasRepository,
            IB2CConsultaPlanosRepository b2cConsultaPlanosRepository,
            IB2CConsultaProdutosAssociadosRepository b2cConsultaProdutosAssociadosRepository,
            IB2CConsultaProdutosCampanhasRepository b2cConsultaProdutosCampanhasRepository,
            IB2CConsultaProdutosCamposAdicionaisDetalhesRepository b2cConsultaProdutosCamposAdicionaisDetalhesRepository,
            IB2CConsultaProdutosCamposAdicionaisNomesRepository b2cConsultaProdutosCamposAdicionaisNomesRepository,
            IB2CConsultaProdutosCamposAdicionaisValoresRepository b2cConsultaProdutosCamposAdicionaisValoresRepository,
            IB2CConsultaProdutosCodebarRepository b2cConsultaProdutosCodebarRepository,
            IB2CConsultaProdutosCustosRepository b2cConsultaProdutosCustosRepository,
            IB2CConsultaProdutosDepositosRepository b2cConsultaProdutosDepositosRepository,
            IB2CConsultaProdutosDetalhesDepositosRepository b2cConsultaProdutosDetalhesDepositosRepository,
            IB2CConsultaProdutosDetalhesRepository b2cConsultaProdutosDetalhesDetalhesRepository,
            IB2CConsultaProdutosDimensoesRepository b2cConsultaProdutosDimensoesRepository,
            IB2CConsultaProdutosFlagsRepository b2cConsultaProdutosFlagsRepository,
            IB2CConsultaProdutosImagensRepository b2cConsultaProdutosImagensRepository,
            IB2CConsultaProdutosInformacoesRepository b2cConsultaProdutosInformacoesRepository,
            IB2CConsultaProdutosPalavrasChavePesquisaRepository b2cConsultaProdutosPalavrasChavePesquisaRepository,
            IB2CConsultaProdutosPromocaoRepository b2cConsultaProdutosPromocaoRepository,
            IB2CConsultaProdutosRepository b2cConsultaProdutosRepository,
            IB2CConsultaProdutosStatusRepository b2cConsultaProdutosStatusRepository,
            IB2CConsultaProdutosTabelasPrecosRepository b2cConsultaProdutosTabelasPrecosRepository,
            IB2CConsultaProdutosTabelasRepository b2cConsultaProdutosTabelasRepository,
            IB2CConsultaProdutosTagsRepository b2cConsultaProdutosTagsRepository,
            IB2CConsultaSetoresRepository b2cConsultaSetoresRepository,
            IB2CConsultaStatusRepository b2cConsultaStatusRepository,
            IB2CConsultaTagsRepository b2cConsultaTagsRepository,
            IB2CConsultaTipoEncomendaRepository b2cConsultaTipoEncomendaRepository,
            IB2CConsultaTiposCobrancaFreteRepository b2cConsultaTiposCobrancaFreteRepository,
            IB2CConsultaTransportadoresRepository b2cConsultaTransportadoresRepository,
            IB2CConsultaUnidadeRepository b2cConsultaUnidadeRepository,
            IB2CConsultaVendedoresRepository b2cConsultaVendedoresRepository
        )
        {
            _linxAPIParamRepository = linxAPIParamRepository;
            _b2cConsultaClassificacaoRepository = b2cConsultaClassificacaoRepository;
            _b2cConsultaClientesContatosRepository = b2cConsultaClientesContatosRepository;
            _b2cConsultaClientesContatosParentescoRepository = b2cConsultaClientesContatosParentescoRepository;
            _b2cConsultaClientesEnderecosEntregaRepository = b2cConsultaClientesEnderecosEntregaRepository;
            _b2cConsultaClientesEstadoCivilRepository = b2cConsultaClientesEstadoCivilRepository;
            _b2cConsultaClientesRepository = b2cConsultaClientesRepository;
            _b2cConsultaClientesSaldoLinxRepository = b2cConsultaClientesSaldoLinxRepository;
            _b2cConsultaClientesSaldoRepository = b2cConsultaClientesSaldoRepository;
            _b2cConsultaCNPJsChaveRepository = b2cConsultaCNPJsChaveRepository;
            _b2cConsultaCodigoRastreioRepository = b2cConsultaCodigoRastreioRepository;
            _b2cConsultaColecoesRepository = b2cConsultaColecoesRepository;
            _b2cConsultaEmpresasRepository = b2cConsultaEmpresasRepository;
            _b2cConsultaEspessurasRepository = b2cConsultaEspessurasRepository;
            _b2cConsultaFlagsRepository = b2cConsultaFlagsRepository;
            _b2cConsultaFormasPagamentoRepository = b2cConsultaFormasPagamentoRepository;
            _b2cConsultaFornecedoresRepository = b2cConsultaFornecedoresRepository;
            _b2cConsultaGrade1Repository = b2cConsultaGrade1Repository;
            _b2cConsultaGrade2Repository = b2cConsultaGrade2Repository;
            _b2cConsultaImagensHDRepository = b2cConsultaImagensHDRepository;
            _b2cConsultaImagensRepository = b2cConsultaImagensRepository;
            _b2cConsultaLegendasCadastrosAuxiliaresRepository = b2cConsultaLegendasRepository;
            _b2cConsultaLinhasRepository = b2cConsultaLinhasRepository;
            _b2cConsultaMarcasRepository = b2cConsultaMarcasRepository;
            _b2cConsultaNFeRepository = b2cConsultaNFeRepository;
            _b2cConsultaNFeSituacaoRepository = b2cConsultaNFeSituacaoRepository;
            _b2cConsultaPalavrasChavePesquisaRepository = b2cConsultaPalavrasChavePesquisaRepository;
            _b2cConsultaPedidosIdentificadorRepository = b2cConsultaPedidosIdentificadorRepository;
            _b2cConsultaPedidosItensRepository = b2cConsultaPedidosItensRepository;
            _b2cConsultaPedidosPlanosRepository = b2cConsultaPedidosPlanosRepository;
            _b2cConsultaPedidosRepository = b2cConsultaPedidosRepository;
            _b2cConsultaPedidosStatusRepository = b2cConsultaPedidosStatusRepository;
            _b2cConsultaPedidosTipRepository = b2cConsultaPedidosTipRepository;
            _b2cConsultaPlanosParcelasRepository = b2cConsultaPlanosParcelasRepository;
            _b2cConsultaPlanosRepository = b2cConsultaPlanosRepository;
            _b2cConsultaProdutosAssociadosRepository = b2cConsultaProdutosAssociadosRepository;
            _b2cConsultaProdutosCampanhasRepository = b2cConsultaProdutosCampanhasRepository;
            _b2cConsultaProdutosCamposAdicionaisDetalhesRepository = b2cConsultaProdutosCamposAdicionaisDetalhesRepository;
            _b2cConsultaProdutosCamposAdicionaisNomesRepository = b2cConsultaProdutosCamposAdicionaisNomesRepository;
            _b2cConsultaProdutosCamposAdicionaisValoresRepository = b2cConsultaProdutosCamposAdicionaisValoresRepository;
            _b2cConsultaProdutosCodebarRepository = b2cConsultaProdutosCodebarRepository;
            _b2cConsultaProdutosCustosRepository = b2cConsultaProdutosCustosRepository;
            _b2cConsultaProdutosDepositosRepository = b2cConsultaProdutosDepositosRepository;
            _b2cConsultaProdutosDetalhesDepositosRepository = b2cConsultaProdutosDetalhesDepositosRepository;
            _b2cConsultaProdutosDetalhesDetalhesRepository = b2cConsultaProdutosDetalhesDetalhesRepository;
            _b2cConsultaProdutosDimensoesRepository = b2cConsultaProdutosDimensoesRepository;
            _b2cConsultaProdutosFlagsRepository = b2cConsultaProdutosFlagsRepository;
            _b2cConsultaProdutosImagensRepository = b2cConsultaProdutosImagensRepository;
            _b2cConsultaProdutosInformacoesRepository = b2cConsultaProdutosInformacoesRepository;
            _b2cConsultaProdutosPalavrasChavePesquisaRepository = b2cConsultaProdutosPalavrasChavePesquisaRepository;
            _b2cConsultaProdutosPromocaoRepository = b2cConsultaProdutosPromocaoRepository;
            _b2cConsultaProdutosRepository = b2cConsultaProdutosRepository;
            _b2cConsultaProdutosStatusRepository = b2cConsultaProdutosStatusRepository;
            _b2cConsultaProdutosTabelasPrecosRepository = b2cConsultaProdutosTabelasPrecosRepository;
            _b2cConsultaProdutosTabelasRepository = b2cConsultaProdutosTabelasRepository;
            _b2cConsultaProdutosTagsRepository = b2cConsultaProdutosTagsRepository;
            _b2cConsultaSetoresRepository = b2cConsultaSetoresRepository;
            _b2cConsultaStatusRepository = b2cConsultaStatusRepository;
            _b2cConsultaTagsRepository = b2cConsultaTagsRepository;
            _b2cConsultaTipoEncomendaRepository = b2cConsultaTipoEncomendaRepository;
            _b2cConsultaTiposCobrancaFreteRepository = b2cConsultaTiposCobrancaFreteRepository;
            _b2cConsultaTransportadoresRepository = b2cConsultaTransportadoresRepository;
            _b2cConsultaUnidadeRepository = b2cConsultaUnidadeRepository;
            _b2cConsultaVendedoresRepository = b2cConsultaVendedoresRepository;
        }

        public async Task<bool> CreateTablesIfNotExists(Parameter parameters, List<LinxMethods> listMethods)
        {
            try
            {
                _linxAPIParamRepository.CreateTableIfNotExists(
                           databaseName: parameters.databaseName,
                           "LinxAPIParam"
                       );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClassificacao")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClassificacaoRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClassificacao")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClientesContatosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClientes")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClientesRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClientes")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClientesContatosParentescoRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClientesEnderecosEntregaRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClientesEstadoCivilRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClientesSaldoRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaClientesSaldoLinxRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                    listMethods
                        .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                        .First()
                        .IsActive
                    )
                    _b2cConsultaCNPJsChaveRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaCodigoRastreioRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaColecoes")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaColecoesRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaColecoes")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaEmpresas")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaEmpresasRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaEmpresas")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaEspessuras")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaEspessurasRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaEspessuras")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaFlags")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaFlagsRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaFlags")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaFormasPagamentoRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaFornecedores")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaFornecedoresRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaFornecedores")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaGrade1")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaGrade1Repository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaGrade1")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaGrade2")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaGrade2Repository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaGrade2")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaImagensHD")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaImagensHDRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaImagensHD")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaImagens")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaImagensRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaImagens")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaLegendasCadastrosAuxiliaresRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaLinhas")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaLinhasRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaLinhas")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaMarcas")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaMarcasRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaMarcas")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaNFe")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaNFeRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaNFe")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaNFeSituacaoRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPalavrasChavePesquisaRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPedidosIdentificadorRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPedidosItensRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPedidosPlanosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPedidosStatusRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPedidos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPedidosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPedidos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPedidosTipRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPlanos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPlanosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPlanos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaPlanosParcelasRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosAssociadosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosCampanhasRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosCamposAdicionaisDetalhesRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosCamposAdicionaisNomesRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosCamposAdicionaisValoresRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosCodebarRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosCustosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosDepositosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosDetalhesDetalhesRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosDetalhesDepositosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosDimensoesRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosFlagsRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosImagensRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosInformacoesRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosPalavrasChavePesquisaRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosPromocaoRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosStatusRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosTabelasRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosTabelasPrecosRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaProdutosTagsRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaSetores")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaSetoresRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaSetores")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaStatus")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaStatusRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaStatus")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaTags")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaTagsRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaTags")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaTipoEncomendaRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaTiposCobrancaFreteRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaTransportadores")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaTransportadoresRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaTransportadores")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaUnidade")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaUnidadeRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaUnidade")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                if (
                   listMethods
                       .Where(m => m.MethodName == "B2CConsultaVendedores")
                       .First()
                       .IsActive
                   )
                    _b2cConsultaVendedoresRepository.CreateDataTableIfNotExists(
                            databaseName: parameters.databaseName,
                            jobName: listMethods
                                    .Where(m => m.MethodName == "B2CConsultaVendedores")
                                    .First()
                                    .MethodName,
                            untreatedDatabaseName: parameters.untreatedDatabaseName
                        );

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateTablesMerges(Parameter parameters, List<LinxMethods> listMethods)
        {
            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClassificacao")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClassificacaoRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClassificacao")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesContatosParentescoRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientes")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientes")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesContatosParentescoRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesEnderecosEntregaRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesEstadoCivilRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesSaldoRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesSaldoLinxRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                                .First()
                                .MethodName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                    .First()
                    .IsActive
                )
                await _b2cConsultaCNPJsChaveRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                   .First()
                   .IsActive
               )
                await _b2cConsultaCodigoRastreioRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaColecoes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaColecoesRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaColecoes")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaEmpresas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaEmpresasRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaEmpresas")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaEspessuras")
                   .First()
                   .IsActive
               )
                await _b2cConsultaEspessurasRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaEspessuras")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaFlags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaFlagsRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaFlags")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                   .First()
                   .IsActive
               )
                await _b2cConsultaFormasPagamentoRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaFornecedores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaFornecedoresRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaFornecedores")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaGrade1")
                   .First()
                   .IsActive
               )
                await _b2cConsultaGrade1Repository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaGrade1")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaGrade2")
                   .First()
                   .IsActive
               )
                await _b2cConsultaGrade2Repository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaGrade2")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaImagensHD")
                   .First()
                   .IsActive
               )
                await _b2cConsultaImagensHDRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaImagensHD")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaImagens")
                   .First()
                   .IsActive
               )
                await _b2cConsultaImagensRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaImagens")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                   .First()
                   .IsActive
               )
                await _b2cConsultaLegendasCadastrosAuxiliaresRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaLinhas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaLinhasRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaLinhas")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaMarcas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaMarcasRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaMarcas")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaNFe")
                   .First()
                   .IsActive
               )
                await _b2cConsultaNFeRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaNFe")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                   .First()
                   .IsActive
               )
                await _b2cConsultaNFeSituacaoRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPalavrasChavePesquisaRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosIdentificadorRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosItensRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosPlanosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosStatusRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosTipRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPlanos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPlanosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPlanos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPlanosParcelasRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosAssociadosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCampanhasRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCamposAdicionaisDetalhesRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCamposAdicionaisNomesRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCamposAdicionaisValoresRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCodebarRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCustosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDepositosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDetalhesDetalhesRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDetalhesDepositosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDimensoesRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosFlagsRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosImagensRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosInformacoesRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosPalavrasChavePesquisaRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosPromocaoRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosStatusRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosTabelasRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosTabelasPrecosRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosTagsRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaSetores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaSetoresRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaSetores")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaStatus")
                   .First()
                   .IsActive
               )
                await _b2cConsultaStatusRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaStatus")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTagsRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTags")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTipoEncomendaRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTiposCobrancaFreteRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTransportadores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTransportadoresRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTransportadores")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaUnidade")
                   .First()
                   .IsActive
               )
                await _b2cConsultaUnidadeRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaUnidade")
                                .First()
                                .MethodName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaVendedores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaVendedoresRepository.CreateTableMerge(
                        databaseName: parameters.databaseName,
                        tableName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaVendedores")
                                .First()
                                .MethodName
                    );

            return true;
        }

        public async Task<bool> InsertParametersIfNotExists(Parameter parameters, List<LinxMethods> listMethods)
        {
            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClassificacao")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClassificacaoRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClassificacao")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesContatosParentescoRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientes")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientes")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesContatosParentescoRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesContatosParentesco")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesEnderecosEntregaRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesEnderecosEntrega")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesEstadoCivilRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesEstadoCivil")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesSaldoRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesSaldo")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesSaldoLinxRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaClientesSaldoLinx")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
                listMethods
                    .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                    .First()
                    .IsActive
                )
                await _b2cConsultaCNPJsChaveRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaCNPJsChave")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                   .First()
                   .IsActive
               )
                await _b2cConsultaCodigoRastreioRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaCodigoRastreio")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaColecoes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaColecoesRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaColecoes")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaEmpresas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaEmpresasRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaEmpresas")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaEspessuras")
                   .First()
                   .IsActive
               )
                await _b2cConsultaEspessurasRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaEspessuras")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaFlags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaFlagsRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaFlags")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                   .First()
                   .IsActive
               )
                await _b2cConsultaFormasPagamentoRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaFormasPagamento")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaFornecedores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaFornecedoresRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaFornecedores")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaGrade1")
                   .First()
                   .IsActive
               )
                await _b2cConsultaGrade1Repository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaGrade1")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaGrade2")
                   .First()
                   .IsActive
               )
                await _b2cConsultaGrade2Repository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaGrade2")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaImagensHD")
                   .First()
                   .IsActive
               )
                await _b2cConsultaImagensHDRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaImagensHD")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaImagens")
                   .First()
                   .IsActive
               )
                await _b2cConsultaImagensRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaImagens")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                   .First()
                   .IsActive
               )
                await _b2cConsultaLegendasCadastrosAuxiliaresRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaLegendasCadastrosAuxiliares")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaLinhas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaLinhasRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaLinhas")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaMarcas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaMarcasRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaMarcas")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaNFe")
                   .First()
                   .IsActive
               )
                await _b2cConsultaNFeRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaNFe")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                   .First()
                   .IsActive
               )
                await _b2cConsultaNFeSituacaoRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaNFeSituacao")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPalavrasChavePesquisaRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPalavrasChavePesquisa")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosIdentificadorRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosIdentificador")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosItensRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosItens")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosPlanosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosPlanos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosStatusRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosStatus")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPedidosTipRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPedidosTipos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPlanos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPlanosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPlanos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaPlanosParcelasRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaPlanosParcelas")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosAssociadosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosAssociados")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCampanhasRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCampanhas")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCamposAdicionaisDetalhesRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisDetalhes")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCamposAdicionaisNomesRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisNomes")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCamposAdicionaisValoresRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCamposAdicionaisValores")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCodebarRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCodebar")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosCustosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosCustos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDepositosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDepositos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDetalhesDetalhesRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDetalhes")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDetalhesDepositosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDetalhesDepositos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosDimensoesRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosDimensoes")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosFlagsRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosFlags")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosImagensRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosImagens")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosInformacoesRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosInformacoes")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosPalavrasChavePesquisaRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosPalavrasChavePesquisa")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosPromocaoRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosPromocao")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosStatusRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosStatus")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosTabelasRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosTabelas")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosTabelasPrecosRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosTabelasPrecos")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaProdutosTagsRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaProdutosTags")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaSetores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaSetoresRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaSetores")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaStatus")
                   .First()
                   .IsActive
               )
                await _b2cConsultaStatusRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaStatus")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTags")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTagsRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTags")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTipoEncomendaRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTipoEncomenda")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTiposCobrancaFreteRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTiposCobrancaFrete")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaTransportadores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaTransportadoresRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaTransportadores")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaUnidade")
                   .First()
                   .IsActive
               )
                await _b2cConsultaUnidadeRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaUnidade")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            if (
               listMethods
                   .Where(m => m.MethodName == "B2CConsultaVendedores")
                   .First()
                   .IsActive
               )
                await _b2cConsultaVendedoresRepository.InsertParametersIfNotExists(
                        databaseName: parameters.databaseName,
                        jobName: listMethods
                                .Where(m => m.MethodName == "B2CConsultaVendedores")
                                .First()
                                .MethodName,
                        parametersTableName: parameters.parametersTableName
                    );

            return true;
        }
    }
}
