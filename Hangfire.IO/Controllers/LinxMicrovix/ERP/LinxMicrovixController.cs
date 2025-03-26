using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.IO.Controllers.LinxMicrovix.ERP
{
    public class LinxMicrovixController : Controller
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
        private readonly ILinxProdutosCodBarService _linxProdutosCodBarService;

        public LinxMicrovixController(
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

        [HttpPost("LinxClientesFornec")]
        public async Task<ActionResult> LinxClientesFornec()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxClientesFornec")
                    .FirstOrDefault();

                var result = await _linxClientesFornecService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxClientesEnderecosEntrega")]
        public async Task<ActionResult> LinxClientesEnderecosEntrega()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxClientesEnderecosEntrega")
                    .FirstOrDefault();

                var result = await _linxClientesEnderecosEntregaService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxMovimento")]
        public async Task<ActionResult> LinxMovimento()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimento")
                    .FirstOrDefault();

                var result = await _linxMovimentoService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxMovimentoCartoes")]
        public async Task<ActionResult> LinxMovimentoCartoes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimentoCartoes")
                    .FirstOrDefault();

                var result = await _linxMovimentoCartoesService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxMovimentoPlanos")]
        public async Task<ActionResult> LinxMovimentoPlanos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimentoPlanos")
                    .FirstOrDefault();

                var result = await _linxMovimentoPlanosService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxMovimentoTrocas")]
        public async Task<ActionResult> LinxMovimentoTrocas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimentoTrocas")
                    .FirstOrDefault();

                var result = await _linxMovimentoTrocasService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxGrupoLojas")]
        public async Task<ActionResult> LinxGrupoLojas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxGrupoLojas")
                    .FirstOrDefault();

                var result = await _linxGrupoLojasService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxLojas")]
        public async Task<ActionResult> LinxLojas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxLojas")
                    .FirstOrDefault();

                var result = await _linxLojasService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxB2CPedidos")]
        public async Task<ActionResult> LinxB2CPedidos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxB2CPedidos")
                    .FirstOrDefault();

                var result = await _linxB2CPedidosService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxB2CPedidosItens")]
        public async Task<ActionResult> LinxB2CPedidosItens()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxB2CPedidosItens")
                    .FirstOrDefault();

                var result = await _linxB2CPedidosItensService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxB2CPedidosStatus")]
        public async Task<ActionResult> LinxB2CPedidosStatus()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxB2CPedidosStatus")
                    .FirstOrDefault();

                var result = await _linxB2CPedidosStatusService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxB2CStatus")]
        public async Task<ActionResult> LinxB2CStatus()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxB2CStatus")
                    .FirstOrDefault();

                var result = await _linxB2CStatusService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxPlanos")]
        public async Task<ActionResult> LinxPlanos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxPlanos")
                    .FirstOrDefault();

                var result = await _linxPlanosService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxNaturezaOperacao")]
        public async Task<ActionResult> LinxNaturezaOperacao()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxNaturezaOperacao")
                    .FirstOrDefault();

                var result = await _linxNaturezaOperacaoService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosCodBar")]
        public async Task<ActionResult> LinxProdutosCodBar()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosCodBar")
                    .FirstOrDefault();

                var result = await _linxProdutosCodBarService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosTabelas")]
        public async Task<ActionResult> LinxProdutosTabelas()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosTabelas")
                    .FirstOrDefault();

                var result = await _linxProdutosTabelasService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosTabelasPrecos")]
        public async Task<ActionResult> LinxProdutosTabelasPrecos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosTabelasPrecos")
                    .FirstOrDefault();

                var result = await _linxProdutosTabelasPrecosService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosDepositos")]
        public async Task<ActionResult> LinxProdutosDepositos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosDepositos")
                    .FirstOrDefault();

                var result = await _linxProdutosDepositosService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosInventario")]
        public async Task<ActionResult> LinxProdutosInventario()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosInventario")
                    .FirstOrDefault();

                var result = await _linxProdutosInventarioService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosDetalhes")]
        public async Task<ActionResult> LinxProdutosDetalhes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosDetalhes")
                    .FirstOrDefault();

                var result = await _linxProdutosDetalhesService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosPromocoes")]
        public async Task<ActionResult> LinxProdutosPromocoes()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosPromocoes")
                    .FirstOrDefault();

                var result = await _linxProdutosPromocoesService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutosCamposAdicionais")]
        public async Task<ActionResult> LinxProdutosCamposAdicionais()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosCamposAdicionais")
                    .FirstOrDefault();

                var result = await _linxProdutosCamposAdicionaisService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxProdutos")]
        public async Task<ActionResult> LinxProdutos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutos")
                    .FirstOrDefault();

                var result = await _linxProdutosService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxPedidosVenda")]
        public async Task<ActionResult> LinxPedidosVenda()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxPedidosVenda")
                    .FirstOrDefault();

                var result = await _linxPedidosVendaService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxPedidosCompra")]
        public async Task<ActionResult> LinxPedidosCompra()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxPedidosCompra")
                    .FirstOrDefault();

                var result = await _linxPedidosCompraService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxSetores")]
        public async Task<ActionResult> LinxSetores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxSetores")
                    .FirstOrDefault();

                var result = await _linxSetoresService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxVendedores")]
        public async Task<ActionResult> LinxVendedores()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxVendedores")
                    .FirstOrDefault();

                var result = await _linxVendedoresService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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

        [HttpPost("LinxXMLDocumentos")]
        public async Task<ActionResult> LinxXMLDocumentos()
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxXMLDocumentos")
                    .FirstOrDefault();

                var result = await _linxXMLDocumentosService.GetRecords(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    )
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
