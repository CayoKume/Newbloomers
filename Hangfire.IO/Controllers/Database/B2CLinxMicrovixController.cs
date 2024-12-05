using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.Database
{
    [ApiController]
    [Route("DatabaseInit/B2CLinxMicrovix")]
    public class B2CLinxMicrovixController : Controller
    {
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

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
        private readonly IB2CConsultaLegendasCadastrosAuxiliaresRepository _b2cConsultaLegendasRepository;
        private readonly IB2CConsultaLinhasRepository _b2cConsultaLinhasRepository;
        private readonly IB2CConsultaMarcasRepository _b2cConsultaMotorasRepository;
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

        public B2CLinxMicrovixController(
            IConfiguration configuration,
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
            IB2CConsultaMarcasRepository b2cConsultaMotorasRepository,
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
            _configuration = configuration;
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
            _b2cConsultaLegendasRepository = b2cConsultaLegendasRepository;
            _b2cConsultaLinhasRepository = b2cConsultaLinhasRepository;
            _b2cConsultaMotorasRepository = b2cConsultaMotorasRepository;
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

            _methods = _configuration
                            .GetSection("B2CLinxMicrovix")
                            .GetSection("Methods")
                            .Get<List<LinxMethods>>();
        }

        [HttpPost("CreateDatabasesIfNotExists")]
        public async Task<ActionResult> CreateDatabasesIfNotExists()
        {
            return Ok($"Database created successfully.");
        }

        [HttpPost("CreateTablesIfNotExists")]
        public async Task<ActionResult> CreateTablesIfNotExists()
        {
            if (
                _methods
                    .Where(m => m.MethodName == "B2CConsultaClassificacao")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClassificacaoRepository.CreateDataTableIfNotExists(
                        new LinxMicrovixJobParameter()
                    );

            if (
                _methods
                    .Where(m => m.MethodName == "B2CConsultaClientesContatos")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesContatosParentescoRepository.CreateDataTableIfNotExists(
                        new LinxMicrovixJobParameter()
                    );

            if (
                _methods
                    .Where(m => m.MethodName == "B2CConsultaClientes")
                    .First()
                    .IsActive
                )
                await _b2cConsultaClientesRepository.CreateDataTableIfNotExists(
                        new LinxMicrovixJobParameter()
                    );

            return Ok($"Tables created successfully.");

        }

        [HttpPost("CreateTablesMerges")]
        public async Task<ActionResult> CreateTablesMerges()
        {
            throw new NotImplementedException();
        }

        [HttpPost("InsertParametersIfNotExists")]
        public async Task<ActionResult> InsertParametersIfNotExists()
        {
            throw new NotImplementedException();
        }
    }
}
