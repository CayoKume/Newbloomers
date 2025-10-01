using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.LinxMicrovix.ERP
{
    [ApiController]
    [Authorize]
#if RELEASE
    [ApiExplorerSettings(IgnoreApi = true)]
#endif
    [Route("LinxMicrovixJobs/LinxMicrovixIntegrityLocks")]
    public class LinxMicrovixIntegrityLocksController : Controller
    {
        private readonly LinxAPIParam _linxMicrovixJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly ILinxProdutosTabelasPrecosService _linxProdutosTabelasPrecosService;
        private readonly ILinxClientesEnderecosEntregaService _linxClientesEnderecosEntregaService;
        private readonly ILinxClientesFornecService _linxClientesFornecService;
        private readonly ILinxMovimentoService _linxMovimentoService;
        private readonly ILinxMovimentoTrocasService _linxMovimentoTrocasService;
        private readonly ILinxMovimentoPlanosService _linxMovimentoPlanosService;
        private readonly ILinxMovimentoCartoesService _linxMovimentoCartoesService;
        private readonly ILinxB2CPedidosService _linxB2CPedidosService;
        private readonly ILinxB2CPedidosItensService _linxB2CPedidosItensService;
        private readonly ILinxB2CPedidosStatusService _linxB2CPedidosStatusService;
        private readonly ILinxB2CStatusService _linxB2CStatusService;
        private readonly ILinxNaturezaOperacaoService _linxNaturezaOperacaoService;
        private readonly ILinxPlanosService _linxPlanosService;
        private readonly ILinxPedidosVendaService _linxPedidosVendaService;
        private readonly ILinxPedidosCompraService _linxPedidosCompraService;
        private readonly ILinxProdutosService _linxProdutosService;
        private readonly ILinxProdutosInventarioService _linxProdutosInventarioService;
        private readonly ILinxProdutosDetalhesService _linxProdutosDetalhesService;
        private readonly ILinxProdutosDepositosService _linxProdutosDepositosService;
        private readonly ILinxProdutosTabelasService _linxProdutosTabelasService;
        private readonly ILinxProdutosPromocoesService _linxProdutosPromocoesService;
        private readonly ILinxProdutosCamposAdicionaisService _linxProdutosCamposAdicionaisService;
        private readonly ILinxGrupoLojasService _linxGrupoLojasService;
        private readonly ILinxLojasService _linxLojasService;
        private readonly ILinxSetoresService _linxSetoresService;
        private readonly ILinxVendedoresService _linxVendedoresService;
        private readonly ILinxXMLDocumentosService _linxXMLDocumentosService;
        private readonly ILinxRotinaOrigemService _linxRotinaOrigemService;
        private readonly ILinxCfopFiscalService _linxCfopFiscalService;
        private readonly ILinxUsuariosService _linxUsuariosService;
        private readonly ILinxProdutosCodBarService _linxProdutosCodBarService;

        public LinxMicrovixIntegrityLocksController(
            IConfiguration configuration,
            ILinxProdutosTabelasPrecosService linxProdutosTabelasPrecosService,
            ILinxClientesEnderecosEntregaService linxClientesEnderecosEntregaService,
            ILinxClientesFornecService linxClientesFornecService,
            ILinxMovimentoService linxMovimentoService,
            ILinxMovimentoTrocasService linxMovimentoTrocasService,
            ILinxMovimentoPlanosService linxMovimentoPlanosService,
            ILinxMovimentoCartoesService linxMovimentoCartoesService,
            ILinxNaturezaOperacaoService linxNaturezaOperacaoService,
            ILinxPlanosService linxPlanosService,
            ILinxB2CPedidosService linxB2CPedidosService,
            ILinxB2CPedidosItensService linxB2CPedidosItensService,
            ILinxB2CPedidosStatusService linxB2CPedidosStatusService,
            ILinxB2CStatusService linxB2CStatusService,
            ILinxProdutosService linxProdutosService,
            ILinxProdutosInventarioService linxProdutosInventarioService,
            ILinxProdutosDetalhesService linxProdutosDetalhesService,
            ILinxProdutosDepositosService linxProdutosDepositosService,
            ILinxProdutosTabelasService linxProdutosTabelasService,
            ILinxProdutosPromocoesService linxProdutosPromocoesService,
            ILinxProdutosCamposAdicionaisService linxProdutosCamposAdicionaisService,
            ILinxPedidosVendaService linxPedidosVendaService,
            ILinxPedidosCompraService linxPedidosCompraService,
            ILinxLojasService linxLojasService,
            ILinxGrupoLojasService linxGrupoLojasService,
            ILinxSetoresService linxSetoresService,
            ILinxVendedoresService linxVendedoresService,
            ILinxXMLDocumentosService linxXMLDocumentosService,
            ILinxRotinaOrigemService linxRotinaOrigemService,
            ILinxCfopFiscalService linxCfopFiscalService,
            ILinxUsuariosService linxUsuariosService,
            ILinxProdutosCodBarService linxProdutosCodBarService
        )
        {
            _configuration = configuration;
            _linxProdutosTabelasPrecosService = linxProdutosTabelasPrecosService;
            _linxClientesEnderecosEntregaService = linxClientesEnderecosEntregaService;
            _linxClientesFornecService = linxClientesFornecService;
            _linxMovimentoService = linxMovimentoService;
            _linxMovimentoTrocasService = linxMovimentoTrocasService;
            _linxMovimentoPlanosService = linxMovimentoPlanosService;
            _linxMovimentoCartoesService = linxMovimentoCartoesService;
            _linxNaturezaOperacaoService = linxNaturezaOperacaoService;
            _linxPlanosService = linxPlanosService;
            _linxB2CPedidosService = linxB2CPedidosService;
            _linxB2CPedidosItensService = linxB2CPedidosItensService;
            _linxB2CPedidosStatusService = linxB2CPedidosStatusService;
            _linxB2CStatusService = linxB2CStatusService;
            _linxProdutosService = linxProdutosService;
            _linxProdutosInventarioService = linxProdutosInventarioService;
            _linxProdutosDetalhesService = linxProdutosDetalhesService;
            _linxProdutosDepositosService = linxProdutosDepositosService;
            _linxProdutosTabelasService = linxProdutosTabelasService;
            _linxProdutosPromocoesService = linxProdutosPromocoesService;
            _linxProdutosCamposAdicionaisService = linxProdutosCamposAdicionaisService;
            _linxPedidosVendaService = linxPedidosVendaService;
            _linxPedidosCompraService = linxPedidosCompraService;
            _linxGrupoLojasService = linxGrupoLojasService;
            _linxLojasService = linxLojasService;
            _linxSetoresService = linxSetoresService;
            _linxVendedoresService = linxVendedoresService;
            _linxXMLDocumentosService = linxXMLDocumentosService;
            _linxRotinaOrigemService = linxRotinaOrigemService;
            _linxCfopFiscalService = linxCfopFiscalService;
            _linxUsuariosService = linxUsuariosService;
            _linxProdutosCodBarService = linxProdutosCodBarService;

            _linxMicrovixJobParameter = new LinxAPIParam(
                docMainCompany: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("DocMainCompany")
                                .Value,

                schema: "linx_microvix_erp",

                databaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("LinxMicrovix")
                                .Value,

                untreatedDatabaseName: _configuration
                                .GetSection("ConfigureServer")
                                .GetSection("Databases")
                                .GetSection("Untreated")
                                .Value,

                projectName: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ProjectName")
                                .Value,

                parametersInterval: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ParametersDateInterval")
                                .Value,

                parametersTableName: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("ParametersTableName")
                                .Value,

                keyAuthorization: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("Key")
                                .Value,

                userAuthentication: _configuration
                                .GetSection("LinxMicrovix")
                                .GetSection("Authentication")
                                .Value
            );

            _methods = _configuration
                            .GetSection("LinxMicrovix")
                            .GetSection("Methods")
                            .Get<List<LinxMethods>>();
        }

        [HttpPost("IntegrityLockLinxPedidosCompraRegisters")]
        public async Task<ActionResult> IntegrityLockLinxPedidosCompraRegisters()
        {
            var method = _methods
                .Where(m => m.MethodName == "LinxPedidosCompra")
                .FirstOrDefault();

            var result = await _linxPedidosCompraService.IntegrityLockRegisters(
                _linxMicrovixJobParameter.SetParameters(
                    jobName: method.MethodName,
                    tableName: method.MethodName
                )
            );

            return Ok($"Records integrated successfully.");
        }
    } 
}
