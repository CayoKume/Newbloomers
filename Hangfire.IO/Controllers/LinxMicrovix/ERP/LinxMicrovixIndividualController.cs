using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hangfire.IO.Controllers.LinxMicrovix
{
    public class LinxMicrovixIndividualController : Controller
    {
        private readonly LinxAPIParam _linxMicrovixJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly ILinxProdutosTabelasPrecosService _linxProdutosTabelasPrecosService;
        private readonly ILinxClientesFornecService _linxClientesFornecService;
        private readonly ILinxMovimentoService _linxMovimentoService;
        private readonly ILinxMovimentoTrocasService _linxMovimentoTrocasService;
        private readonly ILinxMovimentoPlanosService _linxMovimentoPlanosService;
        private readonly ILinxMovimentoCartoesService _linxMovimentoCartoesService;
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

        public LinxMicrovixIndividualController(
            IConfiguration configuration,
            ILinxProdutosTabelasPrecosService linxProdutosTabelasPrecosService,
            ILinxClientesFornecService linxClientesFornecService,
            ILinxMovimentoService linxMovimentoService,
            ILinxMovimentoTrocasService linxMovimentoTrocasService,
            ILinxMovimentoPlanosService linxMovimentoPlanosService,
            ILinxMovimentoCartoesService linxMovimentoCartoesService,
            ILinxNaturezaOperacaoService linxNaturezaOperacaoService,
            ILinxPlanosService linxPlanosService,
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
            _linxClientesFornecService = linxClientesFornecService;
            _linxMovimentoService = linxMovimentoService;
            _linxMovimentoTrocasService = linxMovimentoTrocasService;
            _linxMovimentoPlanosService = linxMovimentoPlanosService;
            _linxMovimentoCartoesService = linxMovimentoCartoesService;
            _linxNaturezaOperacaoService = linxNaturezaOperacaoService;
            _linxPlanosService = linxPlanosService;
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
                                .GetSection("LINX_MICROVIX")
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
                                .GetSection("ParametersIndividual")
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

        [HttpPost("LinxClientesFornecIndividual")]
        public async Task<ActionResult> LinxClientesFornecIndividual([Required][FromQuery] string? doc_cliente)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxClientesFornec")
                    .FirstOrDefault();

                var result = await _linxClientesFornecService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: doc_cliente
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

        [HttpPost("LinxMovimentoIndividual")]
        public async Task<ActionResult> LinxMovimentoIndividual([Required][FromQuery] string? documento, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimento")
                    .FirstOrDefault();

                var result = await _linxMovimentoService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: documento,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxMovimentoCartoesIndividual")]
        public async Task<ActionResult> LinxMovimentoCartoesIndividual([Required][FromQuery] string? identificador, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimentoCartoes")
                    .FirstOrDefault();

                var result = await _linxMovimentoCartoesService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: identificador,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxMovimentoPlanosIndividual")]
        public async Task<ActionResult> LinxMovimentoPlanosIndividual([Required][FromQuery] string? identificador, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimentoPlanos")
                    .FirstOrDefault();

                var result = await _linxMovimentoPlanosService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: identificador,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxMovimentoTrocasIndividual")]
        public async Task<ActionResult> LinxMovimentoTrocasIndividual([Required][FromQuery] string? doc_origem, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxMovimentoTrocas")
                    .FirstOrDefault();

                var result = await _linxMovimentoTrocasService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: doc_origem,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxPlanosIndividual")]
        public async Task<ActionResult> LinxPlanosIndividual([Required][FromQuery] string? plano)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxPlanos")
                    .FirstOrDefault();

                var result = await _linxPlanosService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: plano
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

        [HttpPost("LinxNaturezaOperacaoIndividual")]
        public async Task<ActionResult> LinxNaturezaOperacaoIndividual([Required][FromQuery] string? cod_natureza_operacao)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxNaturezaOperacao")
                    .FirstOrDefault();

                var result = await _linxNaturezaOperacaoService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_natureza_operacao
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

        [HttpPost("LinxProdutosCodBarIndividual")]
        public async Task<ActionResult> LinxProdutosCodBarIndividual([Required][FromQuery] string? cod_produto)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosCodBar")
                    .FirstOrDefault();

                var result = await _linxProdutosCodBarService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_produto
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

        [HttpPost("LinxProdutosTabelasIndividual")]
        public async Task<ActionResult> LinxProdutosTabelasIndividual([Required][FromQuery] string? id_tabela, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosTabelas")
                    .FirstOrDefault();

                var result = await _linxProdutosTabelasService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: id_tabela,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxProdutosTabelasPrecosIndividual")]
        public async Task<ActionResult> LinxProdutosTabelasPrecosIndividual([Required][FromQuery] string? id_tabela, [Required][FromQuery] string? cod_produto, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosTabelasPrecos")
                    .FirstOrDefault();

                var result = await _linxProdutosTabelasPrecosService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_produto,
                    identificador2: id_tabela,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxProdutosDepositosIndividual")]
        public async Task<ActionResult> LinxProdutosDepositosIndividual([Required][FromQuery] string? cod_produto)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosDepositos")
                    .FirstOrDefault();

                var result = await _linxProdutosDepositosService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_produto
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

        [HttpPost("LinxProdutosInventarioIndividual")]
        public async Task<ActionResult> LinxProdutosInventarioIndividual([Required][FromQuery] string? cod_produto, [Required][FromQuery] string? data_inventario, [Required][FromQuery] string? cod_deposito, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosInventario")
                    .FirstOrDefault();

                var result = await _linxProdutosInventarioService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_produto,
                    identificador2: data_inventario,
                    identificador3: cod_deposito,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxProdutosDetalhesIndividual")]
        public async Task<ActionResult> LinxProdutosDetalhesIndividual([Required][FromQuery] string? cod_produto, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosDetalhes")
                    .FirstOrDefault();

                var result = await _linxProdutosDetalhesService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_produto,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxProdutosCamposAdicionaisIndividual")]
        public async Task<ActionResult> LinxProdutosCamposAdicionaisIndividual([Required][FromQuery] string? cod_produto)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutosCamposAdicionais")
                    .FirstOrDefault();

                var result = await _linxProdutosCamposAdicionaisService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_produto
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

        [HttpPost("LinxProdutosIndividual")]
        public async Task<ActionResult> LinxProdutosIndividual([Required][FromQuery] string? cod_produto)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxProdutos")
                    .FirstOrDefault();

                var result = await _linxProdutosService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_produto
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

        [HttpPost("LinxPedidosVendaIndividual")]
        public async Task<ActionResult> LinxPedidosVendaIndividual([Required][FromQuery] string? cod_pedido, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxPedidosVendaIndividual")
                    .FirstOrDefault();

                var result = await _linxPedidosVendaService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_pedido,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxSetoresIndividual")]
        public async Task<ActionResult> LinxSetoresIndividual([Required][FromQuery] string? id_setor)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxSetores")
                    .FirstOrDefault();

                var result = await _linxSetoresService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ), 
                    identificador: id_setor
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

        [HttpPost("LinxXMLDocumentosIndividual")]
        public async Task<ActionResult> LinxXMLDocumentosIndividual([Required][FromQuery] string? documento, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxXMLDocumentos")
                    .FirstOrDefault();

                var result = await _linxXMLDocumentosService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: documento,
                    cnpj_emp: cnpj_emp
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

        [HttpPost("LinxVendedoresIndividual")]
        public async Task<ActionResult> LinxVendedoresIndividual([Required][FromQuery] string? cod_vendedor, [Required][FromQuery] string? cnpj_emp)
        {
            try
            {
                var method = _methods
                    .Where(m => m.MethodName == "LinxVendedores")
                    .FirstOrDefault();

                var result = await _linxVendedoresService.GetRecord(
                    _linxMicrovixJobParameter.SetParameters(
                        jobName: method.MethodName,
                        tableName: method.MethodName
                    ),
                    identificador: cod_vendedor,
                    cnpj_emp: cnpj_emp
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
