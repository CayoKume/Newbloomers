using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Microsoft.Azure.WebJobs;

namespace AzureJobs.RecurringJobs
{
    public class LinxMicrovix
    {
        private readonly LinxAPIParam _linxMicrovixJobParameter;
        private readonly List<LinxMethods>? _methods;
        private readonly IConfiguration _configuration;

        private readonly ILinxProdutosTabelasPrecosService _linxProdutosTabelasPrecosService;
        private readonly ILinxClientesFornecService _linxClientesFornecService;
        private readonly ILinxClientesEnderecosEntregaService _linxClientesEnderecosEntregaService;
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
        private readonly ILinxRotinaOrigemService _linxRotinaOrigemService;
        private readonly ILinxCfopFiscalService _linxCfopFiscalService;
        private readonly ILinxXMLDocumentosService _linxXMLDocumentosService;
        private readonly ILinxUsuariosService _linxUsuariosService;
        private readonly ILinxProdutosCodBarService _linxProdutosCodBarService;

        public LinxMicrovix(
            IConfiguration configuration,
            ILinxProdutosTabelasPrecosService linxProdutosTabelasPrecosService,
            ILinxClientesFornecService linxClientesFornecService,
            ILinxClientesEnderecosEntregaService linxClientesEnderecosEntregaService,
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
            _linxClientesFornecService = linxClientesFornecService;
            _linxClientesEnderecosEntregaService = linxClientesEnderecosEntregaService;
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

        //public async Task LinxB2CPedidos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxB2CPedidos")
        //            .FirstOrDefault();

        //        var result = await _linxB2CPedidosService.GetRecords(
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

        //public async Task LinxB2CPedidosItens([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxB2CPedidosItens")
        //            .FirstOrDefault();

        //        var result = await _linxB2CPedidosItensService.GetRecords(
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

        //public async Task LinxB2CPedidosStatus([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxB2CPedidosStatus")
        //            .FirstOrDefault();

        //        var result = await _linxB2CPedidosStatusService.GetRecords(
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

        //public async Task LinxB2CStatus([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxB2CStatus")
        //            .FirstOrDefault();

        //        var result = await _linxB2CStatusService.GetRecords(
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

        //public async Task LinxLojas([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxLojas")
        //            .FirstOrDefault();

        //        var result = await _linxLojasService.GetRecords(
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

        //public async Task LinxGrupoLojas([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxGrupoLojas")
        //            .FirstOrDefault();

        //        var result = await _linxGrupoLojasService.GetRecords(
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

        //public async Task LinxSetores([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxSetores")
        //            .FirstOrDefault();

        //        var result = await _linxSetoresService.GetRecords(
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

        //public async Task LinxNaturezaOperacao([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxNaturezaOperacao")
        //            .FirstOrDefault();

        //        var result = await _linxNaturezaOperacaoService.GetRecords(
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

        //public async Task LinxMovimento([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxMovimento")
        //            .FirstOrDefault();

        //        var result = await _linxMovimentoService.GetRecords(
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

        //public async Task LinxMovimentoPlanos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxMovimentoPlanos")
        //            .FirstOrDefault();

        //        var result = await _linxMovimentoPlanosService.GetRecords(
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

        //public async Task LinxMovimentoCartoes([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxMovimentoCartoes")
        //            .FirstOrDefault();

        //        var result = await _linxMovimentoCartoesService.GetRecords(
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

        //public async Task LinxMovimentoTrocas([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxMovimentoTrocas")
        //            .FirstOrDefault();

        //        var result = await _linxMovimentoTrocasService.GetRecords(
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

        //public async Task LinxPlanos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxPlanos")
        //            .FirstOrDefault();

        //        var result = await _linxPlanosService.GetRecords(
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

        //public async Task LinxPedidosVenda([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxPedidosVenda")
        //            .FirstOrDefault();

        //        var result = await _linxPedidosVendaService.GetRecords(
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

        //public async Task LinxPedidosCompra([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxPedidosCompra")
        //            .FirstOrDefault();

        //        var result = await _linxPedidosCompraService.GetRecords(
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

        //public async Task LinxClientesFornec([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxClientesFornec")
        //            .FirstOrDefault();

        //        var result = await _linxClientesFornecService.GetRecords(
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

        //public async Task LinxClientesEnderecosEntrega([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxClientesEnderecosEntrega")
        //            .FirstOrDefault();

        //        var result = await _linxClientesEnderecosEntregaService.GetRecords(
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

        //public async Task LinxVendedores([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxVendedores")
        //            .FirstOrDefault();

        //        var result = await _linxVendedoresService.GetRecords(
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

        //public async Task LinxProdutos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutos")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosService.GetRecords(
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

        //public async Task LinxProdutosInventario([TimerTrigger("0 */30 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosInventario")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosInventarioService.GetRecords(
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

        //public async Task LinxProdutosDetalhes([TimerTrigger("0 */30 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosDetalhes")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosDetalhesService.GetRecords(
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

        //public async Task LinxProdutosCodBar([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosCodBar")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosCodBarService.GetRecords(
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

        //public async Task LinxProdutosPromocoes([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosPromocoes")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosPromocoesService.GetRecords(
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

        //public async Task LinxProdutosDepositos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosDepositos")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosDepositosService.GetRecords(
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

        //public async Task LinxProdutosTabelas([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosTabelas")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosTabelasService.GetRecords(
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

        //public async Task LinxProdutosTabelasPrecos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosTabelasPrecos")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosTabelasPrecosService.GetRecords(
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

        //public async Task LinxProdutosCamposAdicionais([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxProdutosCamposAdicionais")
        //            .FirstOrDefault();

        //        var result = await _linxProdutosCamposAdicionaisService.GetRecords(
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

        //public async Task LinxUsuarios([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxUsuarios")
        //        .FirstOrDefault();

        //        var result = await _linxUsuariosService.GetRecords(
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

        //public async Task LinxCfopFiscal([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxCfopFiscal")
        //        .FirstOrDefault();

        //        var result = await _linxCfopFiscalService.GetRecords(
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

        //public async Task LinxRotinaOrigem([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxRotinaOrigem")
        //        .FirstOrDefault();

        //        var result = await _linxRotinaOrigemService.GetRecords(
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

        //public async Task LinxXmlDocumentos([TimerTrigger("0 */3 * * * *", RunOnStartup = true, UseMonitor = true)] TimerInfo timerInfo)
        //{
        //    try
        //    {
        //        var method = _methods
        //            .Where(m => m.MethodName == "LinxXmlDocumentos")
        //        .FirstOrDefault();

        //        var result = await _linxXMLDocumentosService.GetRecords(
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
