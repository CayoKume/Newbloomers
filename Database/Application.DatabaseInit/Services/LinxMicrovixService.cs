using Application.DatabaseInit.Interfaces;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxMicrovix;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.Parameters;
using Domain.DatabaseInit.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Application.DatabaseInit.Services
{
    public class LinxMicrovixService : ILinxMicrovixService
    {
        private readonly ILinxAPIParamRepository _linxAPIParamRepository;
        private readonly ILinxAcoesPromocionaisCombinacaoProdutosItensRepository _linxAcoesPromocionaisCombinacaoProdutosItensRepository;
        private readonly ILinxAcoesPromocionaisProdutosCortesiaRepository _linxAcoesPromocionaisProdutosCortesiaRepository;
        private readonly ILinxAcoesPromocionaisRepository _linxAcoesPromocionaisRepository;
        private readonly ILinxAntecipacoesFinanceirasPlanosRepository _linxAntecipacoesFinanceirasPlanosRepository;
        private readonly ILinxAntecipacoesFinanceirasRepository _linxAntecipacoesFinanceirasRepository;
        private readonly ILinxB2CPedidosItensRepository _linxB2CPedidosItensRepository;
        private readonly ILinxB2CPedidosRepository _linxB2CPedidosRepository;
        private readonly ILinxB2CPedidosStatusRepository _linxB2CPedidosStatusRepository;
        private readonly ILinxB2CStatusRepository _linxB2CStatusRepository;
        private readonly ILinxCategoriasFinanceirasRepository _linxCategoriasFinanceirasRepository;
        private readonly ILinxCentroCustoRepository _linxCentroCustoRepository;
        private readonly ILinxCestRepository _linxCestRepository;
        private readonly ILinxCfopFiscalRepository _linxCfopFiscalRepository;
        private readonly ILinxClasseFiscalRepository _linxClasseFiscalRepository;
        private readonly ILinxClassificacoesRepository _linxClassificacoesRepository;
        private readonly ILinxClientesFornecCamposAdicionaisRepository _linxClientesFornecCamposAdicionaisRepository;
        private readonly ILinxClientesFornecClassesRepository _linxClientesFornecClassesRepository;
        private readonly ILinxClientesFornecContatosParentescoRepository _linxClientesFornecContatosParentescoRepository;
        private readonly ILinxClientesFornecContatosRepository _linxClientesFornecContatosRepository;
        private readonly ILinxClientesFornecCreditoAvulsoRepository _linxClientesFornecCreditoAvulsoRepository;
        private readonly ILinxClientesFornecRepository _linxClientesFornecRepository;
        private readonly ILinxClientesRedeRepository _linxClientesRedeRepository;
        private readonly ILinxColecoesRepository _linxColecoesRepository;
        private readonly ILinxComissoesVendedoresRepository _linxComissoesVendedoresRepository;
        private readonly ILinxConfiguracoesTributariasDetalhesRepository _linxConfiguracoesTributariasDetalhesRepository;
        private readonly ILinxConfiguracoesTributariasDetalhesSimplificadoRepository _linxConfiguracoesTributariasDetalhesSimplificadoRepository;
        private readonly ILinxConfiguracoesTributariasEmpresasRepository _linxConfiguracoesTributariasEmpresasRepository;
        private readonly ILinxConfiguracoesTributariasRepository _linxConfiguracoesTributariasRepository;
        private readonly ILinxCoresRepository _linxCoresRepository;
        private readonly ILinxCsosnFiscalRepository _linxCsosnFiscalRepository;
        private readonly ILinxCstCofinsFiscalRepository _linxCstCofinsFiscalRepository;
        private readonly ILinxCstIcmsFiscalRepository _linxCstIcmsFiscalRepository;
        private readonly ILinxCstIpiFiscalRepository _linxCstIpiFiscalRepository;
        private readonly ILinxCstPisFiscalRepository _linxCstPisFiscalRepository;
        private readonly ILinxCupomDescontoRepository _linxCupomDescontoRepository;
        private readonly ILinxCupomDescontoVendasRepository _linxCupomDescontoVendasRepository;
        private readonly ILinxDadosOpticosDavRepository _linxDadosOpticosDavRepository;
        private readonly ILinxDevolucaoRemanejoFabricaItemRepository _linxDevolucaoRemanejoFabricaItemRepository;
        private readonly ILinxDevolucaoRemanejoFabricaRepository _linxDevolucaoRemanejoFabricaRepository;
        private readonly ILinxDevolucaoRemanejoFabricaStatusRepository _linxDevolucaoRemanejoFabricaStatusRepository;
        private readonly ILinxDevolucaoRemanejoFabricaTipoRepository _linxDevolucaoRemanejoFabricaTipoRepository;
        private readonly ILinxECFFormasPagamentoRepository _linxECFFormasPagamentoRepository;
        private readonly ILinxECFRepository _linxECFRepository;
        private readonly ILinxEnquadramentoIpiRepository _linxEnquadramentoIpiRepository;
        private readonly ILinxEspessurasRepository _linxEspessurasRepository;
        private readonly ILinxFaturasOrigemRepository _linxFaturasOrigemRepository;
        private readonly ILinxFaturasRepository _linxFaturasRepository;
        private readonly ILinxFechamentoCaixaRepository _linxFechamentoCaixaRepository;
        private readonly ILinxFidelidadeRepository _linxFidelidadeRepository;
        private readonly ILinxGrupoLojasRepository _linxGrupoLojasRepository;
        private readonly ILinxLancContabilRepository _linxLancContabilRepository;
        private readonly ILinxLinhasRepository _linxLinhasRepository;
        private readonly ILinxListaDaVezRepository _linxListaDaVezRepository;
        private readonly ILinxListagemBalancoRepository _linxListagemBalancoRepository;
        private readonly ILinxLojasParametrosRepository _linxLojasParametrosRepository;
        private readonly ILinxLojasRepository _linxLojasRepository;
        private readonly ILinxLotesProdutosRepository _linxLotesProdutosRepository;
        private readonly ILinxMarcasRepository _linxMarcasRepository;
        private readonly ILinxMetasVendedoresDiaRepository _linxMetasVendedoresDiaRepository;
        private readonly ILinxMetasVendedoresRepository _linxMetasVendedoresRepository;
        private readonly ILinxMetodosRepository _linxMetodosRepository;
        private readonly ILinxMotivoDescontoRepository _linxMotivoDescontoRepository;
        private readonly ILinxMotivoDevolucaoRepository _linxMotivoDevolucaoRepository;
        private readonly ILinxMotivosDesoneracaoIcmsRepository _linxMotivosDesoneracaoIcmsRepository;
        private readonly ILinxMovimentoAcoesPromocionaisRepository _linxMovimentoAcoesPromocionaisRepository;
        private readonly ILinxMovimentoCamposAdicionaisRepository _linxMovimentoCamposAdicionaisRepository;
        private readonly ILinxMovimentoCartoesRepository _linxMovimentoCartoesRepository;
        private readonly ILinxMovimentoDevolucoesItensRepository _linxMovimentoDevolucoesItensRepository;
        private readonly ILinxMovimentoExtensaoRepository _linxMovimentoExtensaoRepository;
        private readonly ILinxMovimentoGiftCardRepository _linxMovimentoGiftCardRepository;
        private readonly ILinxMovimentoIndicacoesRepository _linxMovimentoIndicacoesRepository;
        private readonly ILinxMovimentoObservacaoCFRepository _linxMovimentoObservacaoCFRepository;
        private readonly ILinxMovimentoObservacoesRepository _linxMovimentoObservacoesRepository;
        private readonly ILinxMovimentoOrdemServicoExternaRepository _linxMovimentoOrdemServicoExternaRepository;
        private readonly ILinxMovimentoOrigemDevolucoesRepository _linxMovimentoOrigemDevolucoesRepository;
        private readonly ILinxMovimentoPlanosRepository _linxMovimentoPlanosRepository;
        private readonly ILinxMovimentoPrincipalRepository _linxMovimentoPrincipalRepository;
        private readonly ILinxMovimentoRemessasAcertosItensRepository _linxMovimentoRemessasAcertosItensRepository;
        private readonly ILinxMovimentoRemessasAcertosRepository _linxMovimentoRemessasAcertosRepository;
        private readonly ILinxMovimentoRemessasItensRepository _linxMovimentoRemessasItensRepository;
        private readonly ILinxMovimentoRemessasRepository _linxMovimentoRemessasRepository;
        private readonly ILinxMovimentoRepository _linxMovimentoRepository;
        private readonly ILinxMovimentoReshopItensRepository _linxMovimentoReshopItensRepository;
        private readonly ILinxMovimentoReshopRepository _linxMovimentoReshopRepository;
        private readonly ILinxMovimentoSerialRepository _linxMovimentoSerialRepository;
        private readonly ILinxMovimentoTrocafoneRepository _linxMovimentoTrocafoneRepository;
        private readonly ILinxMovimentoTrocasRepository _linxMovimentoTrocasRepository;
        private readonly ILinxMovimentoVendaConjugadaRepository _linxMovimentoVendaConjugadaRepository;
        private readonly ILinxNaturezaOperacaoRepository _linxNaturezaOperacaoRepository;
        private readonly ILinxNcmRepository _linxNcmRepository;
        private readonly ILinxNfceEstacaoRepository _linxNfceEstacaoRepository;
        private readonly ILinxNFeEventoRepository _linxNFeEventoRepository;
        private readonly ILinxNfseRepository _linxNfseRepository;
        private readonly ILinxOrcamentoComponenteFormulaRepository _linxOrcamentoComponenteFormulaRepository;
        private readonly ILinxOrdemServicoExternaDavRepository _linxOrdemServicoExternaDavRepository;
        private readonly ILinxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository _linxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository;
        private readonly ILinxOrdensServicoProdutosRepository _linxOrdensServicoProdutosRepository;
        private readonly ILinxOrdensServicoRepository _linxOrdensServicoRepository;
        private readonly ILinxOticoPrismaDescricaoRepository _linxOticoPrismaDescricaoRepository;
        private readonly ILinxOticoReceitasRepository _linxOticoReceitasRepository;
        private readonly ILinxPagamentoParcialDavRepository _linxPagamentoParcialDavRepository;
        private readonly ILinxPedidosCompraRepository _linxPedidosCompraRepository;
        private readonly ILinxPedidosVendaChecklistEntregaArmazenamentoRepository _linxPedidosVendaChecklistEntregaArmazenamentoRepository;
        private readonly ILinxPedidosVendaChecklistEntregaDificuldadeRepository _linxPedidosVendaChecklistEntregaDificuldadeRepository;
        private readonly ILinxPedidosVendaChecklistEntregaLocalRepository _linxPedidosVendaChecklistEntregaLocalRepository;
        private readonly ILinxPedidosVendaRepository _linxPedidosVendaRepository;
        private readonly ILinxPerguntaVendaRepository _linxPerguntaVendaRepository;
        private readonly ILinxPlanoContasRepository _linxPlanoContasRepository;
        private readonly ILinxPlanosBandeirasRepository _linxPlanosBandeirasRepository;
        private readonly ILinxPlanosRepository _linxPlanosRepository;
        private readonly ILinxPosicaoOsRamoOpticoRepository _linxPosicaoOsRamoOpticoRepository;
        private readonly ILinxProdutosAssociadosRepository _linxProdutosAssociadosRepository;
        private readonly ILinxProdutosCamposAdicionaisRepository _linxProdutosCamposAdicionaisRepository;
        private readonly ILinxProdutosCodBarRepository _linxProdutosCodBarRepository;
        private readonly ILinxProdutosDepositosRepository _linxProdutosDepositosRepository;
        private readonly ILinxProdutosDetalhesDepositosRepository _linxProdutosDetalhesDepositosRepository;
        private readonly ILinxProdutosDetalhesRepository _linxProdutosDetalhesRepository;
        private readonly ILinxProdutosDetalhesSimplificadoRepository _linxProdutosDetalhesSimplificadoRepository;
        private readonly ILinxProdutosFornecRepository _linxProdutosFornecRepository;
        private readonly ILinxProdutosInformacoesRepository _linxProdutosInformacoesRepository;
        private readonly ILinxProdutosInventarioRepository _linxProdutosInventarioRepository;
        private readonly ILinxProdutosLotesRepository _linxProdutosLotesRepository;
        private readonly ILinxProdutosOpticosFormatoAroRepository _linxProdutosOpticosFormatoAroRepository;
        private readonly ILinxProdutosOpticosTipoAroRepository _linxProdutosOpticosTipoAroRepository;
        private readonly ILinxProdutosOpticosTipoRepository _linxProdutosOpticosTipoRepository;
        private readonly ILinxProdutosPromocoesRepository _linxProdutosPromocoesRepository;
        private readonly ILinxProdutosRepository _linxProdutosRepository;
        private readonly ILinxProdutosSerialRepository _linxProdutosSerialRepository;
        private readonly ILinxProdutosTabelasPrecosRepository _linxProdutosTabelasPrecosRepository;
        private readonly ILinxProdutosTabelasRepository _linxProdutosTabelasRepository;
        private readonly ILinxRamosAtividadeRepository _linxRamosAtividadeRepository;
        private readonly ILinxReducoesZRepository _linxReducoesZRepository;
        private readonly ILinxRemessasIdentificadoresRepository _linxRemessasIdentificadoresRepository;
        private readonly ILinxRemessasOperacoesRepository _linxRemessasOperacoesRepository;
        private readonly ILinxRemessasRetornoTiposRepository _linxRemessasRetornoTiposRepository;
        private readonly ILinxRespostaVendaRepository _linxRespostaVendaRepository;
        private readonly ILinxRotinaOrigemRepository _linxRotinaOrigemRepository;
        private readonly ILinxSangriaSuprimentosRepository _linxSangriaSuprimentosRepository;
        private readonly ILinxSerialVendaRepository _linxSerialVendaRepository;
        private readonly ILinxSeriesRepository _linxSeriesRepository;
        private readonly ILinxServicosDetalhesRepository _linxServicosDetalhesRepository;
        private readonly ILinxServicosRepository _linxServicosRepository;
        private readonly ILinxSetoresRepository _linxSetoresRepository;
        private readonly ILinxSpedTipoBaseCreditoRepository _linxSpedTipoBaseCreditoRepository;
        private readonly ILinxSpedTipoItemRepository _linxSpedTipoItemRepository;
        private readonly ILinxSubClassesRepository _linxSubClassesRepository;
        private readonly ILinxTamanhosRepository _linxTamanhosRepository;
        private readonly ILinxTradeinParceiroRepository _linxTradeinParceiroRepository;
        private readonly ILinxTrocaUnificadaResumoBaixaRepository _linxTrocaUnificadaResumoBaixaRepository;
        private readonly ILinxTrocaUnificadaResumoVendasItensRepository _linxTrocaUnificadaResumoVendasItensRepository;
        private readonly ILinxTrocaUnificadaResumoVendasRepository _linxTrocaUnificadaResumoVendasRepository;
        private readonly ILinxUnidadesRepository _linxUnidadesRepository;
        private readonly ILinxValeOrdemServicoExternaRepository _linxValeOrdemServicoExternaRepository;
        private readonly ILinxValesComprasEnviadosAPIRepository _linxValesComprasEnviadosAPIRepository;
        private readonly ILinxVendedoresRepository _linxVendedoresRepository;
        private readonly ILinxXMLDocumentosRepository _linxXMLDocumentosRepository;

        public LinxMicrovixService(
            ILinxAPIParamRepository linxAPIParamRepository,
            ILinxAcoesPromocionaisCombinacaoProdutosItensRepository linxAcoesPromocionaisCombinacaoProdutosItensRepository,
            ILinxAcoesPromocionaisProdutosCortesiaRepository linxAcoesPromocionaisProdutosCortesiaRepository,
            ILinxAcoesPromocionaisRepository linxAcoesPromocionaisRepository,
            ILinxAntecipacoesFinanceirasPlanosRepository linxAntecipacoesFinanceirasPlanosRepository,
            ILinxAntecipacoesFinanceirasRepository linxAntecipacoesFinanceirasRepository,
            ILinxB2CPedidosItensRepository linxB2CPedidosItensRepository,
            ILinxB2CPedidosRepository linxB2CPedidosRepository,
            ILinxB2CPedidosStatusRepository linxB2CPedidosStatusRepository,
            ILinxB2CStatusRepository linxB2CStatusRepository,
            ILinxCategoriasFinanceirasRepository linxCategoriasFinanceirasRepository,
            ILinxCentroCustoRepository linxCentroCustoRepository,
            ILinxCestRepository linxCestRepository,
            ILinxCfopFiscalRepository linxCfopFiscalRepository,
            ILinxClasseFiscalRepository linxClasseFiscalRepository,
            ILinxClassificacoesRepository linxClassificacoesRepository,
            ILinxClientesFornecCamposAdicionaisRepository linxClientesFornecCamposAdicionaisRepository,
            ILinxClientesFornecClassesRepository linxClientesFornecClassesRepository,
            ILinxClientesFornecContatosParentescoRepository linxClientesFornecContatosParentescoRepository,
            ILinxClientesFornecContatosRepository linxClientesFornecContatosRepository,
            ILinxClientesFornecCreditoAvulsoRepository linxClientesFornecCreditoAvulsoRepository,
            ILinxClientesFornecRepository linxClientesFornecRepository,
            ILinxClientesRedeRepository linxClientesRedeRepository,
            ILinxColecoesRepository linxColecoesRepository,
            ILinxComissoesVendedoresRepository linxComissoesVendedoresRepository,
            ILinxConfiguracoesTributariasDetalhesRepository linxConfiguracoesTributariasDetalhesRepository,
            ILinxConfiguracoesTributariasDetalhesSimplificadoRepository linxConfiguracoesTributariasDetalhesSimplificadoRepository,
            ILinxConfiguracoesTributariasEmpresasRepository linxConfiguracoesTributariasEmpresasRepository,
            ILinxConfiguracoesTributariasRepository linxConfiguracoesTributariasRepository,
            ILinxCoresRepository linxCoresRepository,
            ILinxCsosnFiscalRepository linxCsosnFiscalRepository,
            ILinxCstCofinsFiscalRepository linxCstCofinsFiscalRepository,
            ILinxCstIcmsFiscalRepository linxCstIcmsFiscalRepository,
            ILinxCstIpiFiscalRepository linxCstIpiFiscalRepository,
            ILinxCstPisFiscalRepository linxCstPisFiscalRepository,
            ILinxCupomDescontoRepository linxCupomDescontoRepository,
            ILinxCupomDescontoVendasRepository linxCupomDescontoVendasRepository,
            ILinxDadosOpticosDavRepository linxDadosOpticosDavRepository,
            ILinxDevolucaoRemanejoFabricaItemRepository linxDevolucaoRemanejoFabricaItemRepository,
            ILinxDevolucaoRemanejoFabricaRepository linxDevolucaoRemanejoFabricaRepository,
            ILinxDevolucaoRemanejoFabricaStatusRepository linxDevolucaoRemanejoFabricaStatusRepository,
            ILinxDevolucaoRemanejoFabricaTipoRepository linxDevolucaoRemanejoFabricaTipoRepository,
            ILinxECFFormasPagamentoRepository linxECFFormasPagamentoRepository,
            ILinxECFRepository linxECFRepository,
            ILinxEnquadramentoIpiRepository linxEnquadramentoIpiRepository,
            ILinxEspessurasRepository linxEspessurasRepository,
            ILinxFaturasOrigemRepository linxFaturasOrigemRepository,
            ILinxFaturasRepository linxFaturasRepository,
            ILinxFechamentoCaixaRepository linxFechamentoCaixaRepository,
            ILinxFidelidadeRepository linxFidelidadeRepository,
            ILinxGrupoLojasRepository linxGrupoLojasRepository,
            ILinxLancContabilRepository linxLancContabilRepository,
            ILinxLinhasRepository linxLinhasRepository,
            ILinxListaDaVezRepository linxListaDaVezRepository,
            ILinxListagemBalancoRepository linxListagemBalancoRepository,
            ILinxLojasParametrosRepository linxLojasParametrosRepository,
            ILinxLojasRepository linxLojasRepository,
            ILinxLotesProdutosRepository linxLotesProdutosRepository,
            ILinxMarcasRepository linxMarcasRepository,
            ILinxMetasVendedoresDiaRepository linxMetasVendedoresDiaRepository,
            ILinxMetasVendedoresRepository linxMetasVendedoresRepository,
            ILinxMetodosRepository linxMetodosRepository,
            ILinxMotivoDescontoRepository linxMotivoDescontoRepository,
            ILinxMotivoDevolucaoRepository linxMotivoDevolucaoRepository,
            ILinxMotivosDesoneracaoIcmsRepository linxMotivosDesoneracaoIcmsRepository,
            ILinxMovimentoAcoesPromocionaisRepository linxMovimentoAcoesPromocionaisRepository,
            ILinxMovimentoCamposAdicionaisRepository linxMovimentoCamposAdicionaisRepository,
            ILinxMovimentoCartoesRepository linxMovimentoCartoesRepository,
            ILinxMovimentoDevolucoesItensRepository linxMovimentoDevolucoesItensRepository,
            ILinxMovimentoExtensaoRepository linxMovimentoExtensaoRepository,
            ILinxMovimentoGiftCardRepository linxMovimentoGiftCardRepository,
            ILinxMovimentoIndicacoesRepository linxMovimentoIndicacoesRepository,
            ILinxMovimentoObservacaoCFRepository linxMovimentoObservacaoCFRepository,
            ILinxMovimentoObservacoesRepository linxMovimentoObservacoesRepository,
            ILinxMovimentoOrdemServicoExternaRepository linxMovimentoOrdemServicoExternaRepository,
            ILinxMovimentoOrigemDevolucoesRepository linxMovimentoOrigemDevolucoesRepository,
            ILinxMovimentoPlanosRepository linxMovimentoPlanosRepository,
            ILinxMovimentoPrincipalRepository linxMovimentoPrincipalRepository,
            ILinxMovimentoRemessasAcertosItensRepository linxMovimentoRemessasAcertosItensRepository,
            ILinxMovimentoRemessasAcertosRepository linxMovimentoRemessasAcertosRepository,
            ILinxMovimentoRemessasItensRepository linxMovimentoRemessasItensRepository,
            ILinxMovimentoRemessasRepository linxMovimentoRemessasRepository,
            ILinxMovimentoRepository linxMovimentoRepository,
            ILinxMovimentoReshopItensRepository linxMovimentoReshopItensRepository,
            ILinxMovimentoReshopRepository linxMovimentoReshopRepository,
            ILinxMovimentoSerialRepository linxMovimentoSerialRepository,
            ILinxMovimentoTrocafoneRepository linxMovimentoTrocafoneRepository,
            ILinxMovimentoTrocasRepository linxMovimentoTrocasRepository,
            ILinxMovimentoVendaConjugadaRepository linxMovimentoVendaConjugadaRepository,
            ILinxNaturezaOperacaoRepository linxNaturezaOperacaoRepository,
            ILinxNcmRepository linxNcmRepository,
            ILinxNfceEstacaoRepository linxNfceEstacaoRepository,
            ILinxNFeEventoRepository linxNFeEventoRepository,
            ILinxNfseRepository linxNfseRepository,
            ILinxOrcamentoComponenteFormulaRepository linxOrcamentoComponenteFormulaRepository,
            ILinxOrdemServicoExternaDavRepository linxOrdemServicoExternaDavRepository,
            ILinxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository linxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository,
            ILinxOrdensServicoProdutosRepository linxOrdensServicoProdutosRepository,
            ILinxOrdensServicoRepository linxOrdensServicoRepository,
            ILinxOticoPrismaDescricaoRepository linxOticoPrismaDescricaoRepository,
            ILinxOticoReceitasRepository linxOticoReceitasRepository,
            ILinxPagamentoParcialDavRepository linxPagamentoParcialDavRepository,
            ILinxPedidosCompraRepository linxPedidosCompraRepository,
            ILinxPedidosVendaChecklistEntregaArmazenamentoRepository linxPedidosVendaChecklistEntregaArmazenamentoRepository,
            ILinxPedidosVendaChecklistEntregaDificuldadeRepository linxPedidosVendaChecklistEntregaDificuldadeRepository,
            ILinxPedidosVendaChecklistEntregaLocalRepository linxPedidosVendaChecklistEntregaLocalRepository,
            ILinxPedidosVendaRepository linxPedidosVendaRepository,
            ILinxPerguntaVendaRepository linxPerguntaVendaRepository,
            ILinxPlanoContasRepository linxPlanoContasRepository,
            ILinxPlanosBandeirasRepository linxPlanosBandeirasRepository,
            ILinxPlanosRepository linxPlanosRepository,
            ILinxPosicaoOsRamoOpticoRepository linxPosicaoOsRamoOpticoRepository,
            ILinxProdutosAssociadosRepository linxProdutosAssociadosRepository,
            ILinxProdutosCamposAdicionaisRepository linxProdutosCamposAdicionaisRepository,
            ILinxProdutosCodBarRepository linxProdutosCodBarRepository,
            ILinxProdutosDepositosRepository linxProdutosDepositosRepository,
            ILinxProdutosDetalhesDepositosRepository linxProdutosDetalhesDepositosRepository,
            ILinxProdutosDetalhesRepository linxProdutosDetalhesRepository,
            ILinxProdutosDetalhesSimplificadoRepository linxProdutosDetalhesSimplificadoRepository,
            ILinxProdutosFornecRepository linxProdutosFornecRepository,
            ILinxProdutosInformacoesRepository linxProdutosInformacoesRepository,
            ILinxProdutosInventarioRepository linxProdutosInventarioRepository,
            ILinxProdutosLotesRepository linxProdutosLotesRepository,
            ILinxProdutosOpticosFormatoAroRepository linxProdutosOpticosFormatoAroRepository,
            ILinxProdutosOpticosTipoAroRepository linxProdutosOpticosTipoAroRepository,
            ILinxProdutosOpticosTipoRepository linxProdutosOpticosTipoRepository,
            ILinxProdutosPromocoesRepository linxProdutosPromocoesRepository,
            ILinxProdutosRepository linxProdutosRepository,
            ILinxProdutosSerialRepository linxProdutosSerialRepository,
            ILinxProdutosTabelasPrecosRepository linxProdutosTabelasPrecosRepository,
            ILinxProdutosTabelasRepository linxProdutosTabelasRepository,
            ILinxRamosAtividadeRepository linxRamosAtividadeRepository,
            ILinxReducoesZRepository linxReducoesZRepository,
            ILinxRemessasIdentificadoresRepository linxRemessasIdentificadoresRepository,
            ILinxRemessasOperacoesRepository linxRemessasOperacoesRepository,
            ILinxRemessasRetornoTiposRepository linxRemessasRetornoTiposRepository,
            ILinxRespostaVendaRepository linxRespostaVendaRepository,
            ILinxRotinaOrigemRepository linxRotinaOrigemRepository,
            ILinxSangriaSuprimentosRepository linxSangriaSuprimentosRepository,
            ILinxSerialVendaRepository linxSerialVendaRepository,
            ILinxSeriesRepository linxSeriesRepository,
            ILinxServicosDetalhesRepository linxServicosDetalhesRepository,
            ILinxServicosRepository linxServicosRepository,
            ILinxSetoresRepository linxSetoresRepository,
            ILinxSpedTipoBaseCreditoRepository linxSpedTipoBaseCreditoRepository,
            ILinxSpedTipoItemRepository linxSpedTipoItemRepository,
            ILinxSubClassesRepository linxSubClassesRepository,
            ILinxTamanhosRepository linxTamanhosRepository,
            ILinxTradeinParceiroRepository linxTradeinParceiroRepository,
            ILinxTrocaUnificadaResumoBaixaRepository linxTrocaUnificadaResumoBaixaRepository,
            ILinxTrocaUnificadaResumoVendasItensRepository linxTrocaUnificadaResumoVendasItensRepository,
            ILinxTrocaUnificadaResumoVendasRepository linxTrocaUnificadaResumoVendasRepository,
            ILinxUnidadesRepository linxUnidadesRepository,
            ILinxValeOrdemServicoExternaRepository linxValeOrdemServicoExternaRepository,
            ILinxValesComprasEnviadosAPIRepository linxValesComprasEnviadosAPIRepository,
            ILinxVendedoresRepository linxVendedoresRepository,
            ILinxXMLDocumentosRepository linxXMLDocumentosRepository
        )
        {
            _linxAPIParamRepository = linxAPIParamRepository;
            _linxAcoesPromocionaisCombinacaoProdutosItensRepository = linxAcoesPromocionaisCombinacaoProdutosItensRepository;
            _linxAcoesPromocionaisProdutosCortesiaRepository = linxAcoesPromocionaisProdutosCortesiaRepository;
            _linxAcoesPromocionaisRepository = linxAcoesPromocionaisRepository;
            _linxAntecipacoesFinanceirasPlanosRepository = linxAntecipacoesFinanceirasPlanosRepository;
            _linxAntecipacoesFinanceirasRepository = linxAntecipacoesFinanceirasRepository;
            _linxB2CPedidosItensRepository = linxB2CPedidosItensRepository;
            _linxB2CPedidosRepository = linxB2CPedidosRepository;
            _linxB2CPedidosStatusRepository = linxB2CPedidosStatusRepository;
            _linxB2CStatusRepository = linxB2CStatusRepository;
            _linxCategoriasFinanceirasRepository = linxCategoriasFinanceirasRepository;
            _linxCentroCustoRepository = linxCentroCustoRepository;
            _linxCestRepository = linxCestRepository;
            _linxCfopFiscalRepository = linxCfopFiscalRepository;
            _linxClasseFiscalRepository = linxClasseFiscalRepository;
            _linxClassificacoesRepository = linxClassificacoesRepository;
            _linxClientesFornecCamposAdicionaisRepository = linxClientesFornecCamposAdicionaisRepository;
            _linxClientesFornecClassesRepository = linxClientesFornecClassesRepository;
            _linxClientesFornecContatosParentescoRepository = linxClientesFornecContatosParentescoRepository;
            _linxClientesFornecContatosRepository = linxClientesFornecContatosRepository;
            _linxClientesFornecCreditoAvulsoRepository = linxClientesFornecCreditoAvulsoRepository;
            _linxClientesFornecRepository = linxClientesFornecRepository;
            _linxClientesRedeRepository = linxClientesRedeRepository;
            _linxColecoesRepository = linxColecoesRepository;
            _linxComissoesVendedoresRepository = linxComissoesVendedoresRepository;
            _linxConfiguracoesTributariasDetalhesRepository = linxConfiguracoesTributariasDetalhesRepository;
            _linxConfiguracoesTributariasDetalhesSimplificadoRepository = linxConfiguracoesTributariasDetalhesSimplificadoRepository;
            _linxConfiguracoesTributariasEmpresasRepository = linxConfiguracoesTributariasEmpresasRepository;
            _linxConfiguracoesTributariasRepository = linxConfiguracoesTributariasRepository;
            _linxCoresRepository = linxCoresRepository;
            _linxCsosnFiscalRepository = linxCsosnFiscalRepository;
            _linxCstCofinsFiscalRepository = linxCstCofinsFiscalRepository;
            _linxCstIcmsFiscalRepository = linxCstIcmsFiscalRepository;
            _linxCstIpiFiscalRepository = linxCstIpiFiscalRepository;
            _linxCstPisFiscalRepository = linxCstPisFiscalRepository;
            _linxCupomDescontoRepository = linxCupomDescontoRepository;
            _linxCupomDescontoVendasRepository = linxCupomDescontoVendasRepository;
            _linxDadosOpticosDavRepository = linxDadosOpticosDavRepository;
            _linxDevolucaoRemanejoFabricaItemRepository = linxDevolucaoRemanejoFabricaItemRepository;
            _linxDevolucaoRemanejoFabricaRepository = linxDevolucaoRemanejoFabricaRepository;
            _linxDevolucaoRemanejoFabricaStatusRepository = linxDevolucaoRemanejoFabricaStatusRepository;
            _linxDevolucaoRemanejoFabricaTipoRepository = linxDevolucaoRemanejoFabricaTipoRepository;
            _linxECFFormasPagamentoRepository = linxECFFormasPagamentoRepository;
            _linxECFRepository = linxECFRepository;
            _linxEnquadramentoIpiRepository = linxEnquadramentoIpiRepository;
            _linxEspessurasRepository = linxEspessurasRepository;
            _linxFaturasOrigemRepository = linxFaturasOrigemRepository;
            _linxFaturasRepository = linxFaturasRepository;
            _linxFechamentoCaixaRepository = linxFechamentoCaixaRepository;
            _linxFidelidadeRepository = linxFidelidadeRepository;
            _linxGrupoLojasRepository = linxGrupoLojasRepository;
            _linxLancContabilRepository = linxLancContabilRepository;
            _linxLinhasRepository = linxLinhasRepository;
            _linxListaDaVezRepository = linxListaDaVezRepository;
            _linxListagemBalancoRepository = linxListagemBalancoRepository;
            _linxLojasParametrosRepository = linxLojasParametrosRepository;
            _linxLojasRepository = linxLojasRepository;
            _linxLotesProdutosRepository = linxLotesProdutosRepository;
            _linxMarcasRepository = linxMarcasRepository;
            _linxMetasVendedoresDiaRepository = linxMetasVendedoresDiaRepository;
            _linxMetasVendedoresRepository = linxMetasVendedoresRepository;
            _linxMetodosRepository = linxMetodosRepository;
            _linxMotivoDescontoRepository = linxMotivoDescontoRepository;
            _linxMotivoDevolucaoRepository = linxMotivoDevolucaoRepository;
            _linxMotivosDesoneracaoIcmsRepository = linxMotivosDesoneracaoIcmsRepository;
            _linxMovimentoAcoesPromocionaisRepository = linxMovimentoAcoesPromocionaisRepository;
            _linxMovimentoCamposAdicionaisRepository = linxMovimentoCamposAdicionaisRepository;
            _linxMovimentoCartoesRepository = linxMovimentoCartoesRepository;
            _linxMovimentoDevolucoesItensRepository = linxMovimentoDevolucoesItensRepository;
            _linxMovimentoExtensaoRepository = linxMovimentoExtensaoRepository;
            _linxMovimentoGiftCardRepository = linxMovimentoGiftCardRepository;
            _linxMovimentoIndicacoesRepository = linxMovimentoIndicacoesRepository;
            _linxMovimentoObservacaoCFRepository = linxMovimentoObservacaoCFRepository;
            _linxMovimentoObservacoesRepository = linxMovimentoObservacoesRepository;
            _linxMovimentoOrdemServicoExternaRepository = linxMovimentoOrdemServicoExternaRepository;
            _linxMovimentoOrigemDevolucoesRepository = linxMovimentoOrigemDevolucoesRepository;
            _linxMovimentoPlanosRepository = linxMovimentoPlanosRepository;
            _linxMovimentoPrincipalRepository = linxMovimentoPrincipalRepository;
            _linxMovimentoRemessasAcertosItensRepository = linxMovimentoRemessasAcertosItensRepository;
            _linxMovimentoRemessasAcertosRepository = linxMovimentoRemessasAcertosRepository;
            _linxMovimentoRemessasItensRepository = linxMovimentoRemessasItensRepository;
            _linxMovimentoRemessasRepository = linxMovimentoRemessasRepository;
            _linxMovimentoRepository = linxMovimentoRepository;
            _linxMovimentoReshopItensRepository = linxMovimentoReshopItensRepository;
            _linxMovimentoReshopRepository = linxMovimentoReshopRepository;
            _linxMovimentoSerialRepository = linxMovimentoSerialRepository;
            _linxMovimentoTrocafoneRepository = linxMovimentoTrocafoneRepository;
            _linxMovimentoTrocasRepository = linxMovimentoTrocasRepository;
            _linxMovimentoVendaConjugadaRepository = linxMovimentoVendaConjugadaRepository;
            _linxNaturezaOperacaoRepository = linxNaturezaOperacaoRepository;
            _linxNcmRepository = linxNcmRepository;
            _linxNfceEstacaoRepository = linxNfceEstacaoRepository;
            _linxNFeEventoRepository = linxNFeEventoRepository;
            _linxNfseRepository = linxNfseRepository;
            _linxOrcamentoComponenteFormulaRepository = linxOrcamentoComponenteFormulaRepository;
            _linxOrdemServicoExternaDavRepository = linxOrdemServicoExternaDavRepository;
            _linxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository = linxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository;
            _linxOrdensServicoProdutosRepository = linxOrdensServicoProdutosRepository;
            _linxOrdensServicoRepository = linxOrdensServicoRepository;
            _linxOticoPrismaDescricaoRepository = linxOticoPrismaDescricaoRepository;
            _linxOticoReceitasRepository = linxOticoReceitasRepository;
            _linxPagamentoParcialDavRepository = linxPagamentoParcialDavRepository;
            _linxPedidosCompraRepository = linxPedidosCompraRepository;
            _linxPedidosVendaChecklistEntregaArmazenamentoRepository = linxPedidosVendaChecklistEntregaArmazenamentoRepository;
            _linxPedidosVendaChecklistEntregaDificuldadeRepository = linxPedidosVendaChecklistEntregaDificuldadeRepository;
            _linxPedidosVendaChecklistEntregaLocalRepository = linxPedidosVendaChecklistEntregaLocalRepository;
            _linxPedidosVendaRepository = linxPedidosVendaRepository;
            _linxPerguntaVendaRepository = linxPerguntaVendaRepository;
            _linxPlanoContasRepository = linxPlanoContasRepository;
            _linxPlanosBandeirasRepository = linxPlanosBandeirasRepository;
            _linxPlanosRepository = linxPlanosRepository;
            _linxPosicaoOsRamoOpticoRepository = linxPosicaoOsRamoOpticoRepository;
            _linxProdutosAssociadosRepository = linxProdutosAssociadosRepository;
            _linxProdutosCamposAdicionaisRepository = linxProdutosCamposAdicionaisRepository;
            _linxProdutosCodBarRepository = linxProdutosCodBarRepository;
            _linxProdutosDepositosRepository = linxProdutosDepositosRepository;
            _linxProdutosDetalhesDepositosRepository = linxProdutosDetalhesDepositosRepository;
            _linxProdutosDetalhesRepository = linxProdutosDetalhesRepository;
            _linxProdutosDetalhesSimplificadoRepository = linxProdutosDetalhesSimplificadoRepository;
            _linxProdutosFornecRepository = linxProdutosFornecRepository;
            _linxProdutosInformacoesRepository = linxProdutosInformacoesRepository;
            _linxProdutosInventarioRepository = linxProdutosInventarioRepository;
            _linxProdutosLotesRepository = linxProdutosLotesRepository;
            _linxProdutosOpticosFormatoAroRepository = linxProdutosOpticosFormatoAroRepository;
            _linxProdutosOpticosTipoAroRepository = linxProdutosOpticosTipoAroRepository;
            _linxProdutosOpticosTipoRepository = linxProdutosOpticosTipoRepository;
            _linxProdutosPromocoesRepository = linxProdutosPromocoesRepository;
            _linxProdutosRepository = linxProdutosRepository;
            _linxProdutosSerialRepository = linxProdutosSerialRepository;
            _linxProdutosTabelasPrecosRepository = linxProdutosTabelasPrecosRepository;
            _linxProdutosTabelasRepository = linxProdutosTabelasRepository;
            _linxRamosAtividadeRepository = linxRamosAtividadeRepository;
            _linxReducoesZRepository = linxReducoesZRepository;
            _linxRemessasIdentificadoresRepository = linxRemessasIdentificadoresRepository;
            _linxRemessasOperacoesRepository = linxRemessasOperacoesRepository;
            _linxRemessasRetornoTiposRepository = linxRemessasRetornoTiposRepository;
            _linxRespostaVendaRepository = linxRespostaVendaRepository;
            _linxRotinaOrigemRepository = linxRotinaOrigemRepository;
            _linxSangriaSuprimentosRepository = linxSangriaSuprimentosRepository;
            _linxSerialVendaRepository = linxSerialVendaRepository;
            _linxSeriesRepository = linxSeriesRepository;
            _linxServicosDetalhesRepository = linxServicosDetalhesRepository;
            _linxServicosRepository = linxServicosRepository;
            _linxSetoresRepository = linxSetoresRepository;
            _linxSpedTipoBaseCreditoRepository = linxSpedTipoBaseCreditoRepository;
            _linxSpedTipoItemRepository = linxSpedTipoItemRepository;
            _linxSubClassesRepository = linxSubClassesRepository;
            _linxTamanhosRepository = linxTamanhosRepository;
            _linxTradeinParceiroRepository = linxTradeinParceiroRepository;
            _linxTrocaUnificadaResumoBaixaRepository = linxTrocaUnificadaResumoBaixaRepository;
            _linxTrocaUnificadaResumoVendasItensRepository = linxTrocaUnificadaResumoVendasItensRepository;
            _linxTrocaUnificadaResumoVendasRepository = linxTrocaUnificadaResumoVendasRepository;
            _linxUnidadesRepository = linxUnidadesRepository;
            _linxValeOrdemServicoExternaRepository = linxValeOrdemServicoExternaRepository;
            _linxValesComprasEnviadosAPIRepository = linxValesComprasEnviadosAPIRepository;
            _linxVendedoresRepository = linxVendedoresRepository;
            _linxXMLDocumentosRepository = linxXMLDocumentosRepository;
        }

        public async Task<bool> CreateTablesIfNotExists(Parameter parameters, List<LinxMethods>? listMethods)
        {
            try
            {
                _linxAPIParamRepository.CreateTableIfNotExists(
                    databaseName: parameters.databaseName,
                    "LinxAPIParam"
                );

                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAcoesPromocionaisCombinacaoProdutosItens")
                       .First()
                       .IsActive
                   )
                    _linxAcoesPromocionaisCombinacaoProdutosItensRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAcoesPromocionaisCombinacaoProdutosItens")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAcoesPromocionaisProdutosCortesia")
                       .First()
                       .IsActive
                   )
                    _linxAcoesPromocionaisProdutosCortesiaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAcoesPromocionaisProdutosCortesia")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAcoesPromocionais")
                       .First()
                       .IsActive
                   )
                    _linxAcoesPromocionaisRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAcoesPromocionais")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAntecipacoesFinanceirasPlanos")
                       .First()
                       .IsActive
                   )
                    _linxAntecipacoesFinanceirasPlanosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAntecipacoesFinanceirasPlanos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAntecipacoesFinanceiras")
                       .First()
                       .IsActive
                   )
                    _linxAntecipacoesFinanceirasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAntecipacoesFinanceiras")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CPedidosItens")
                       .First()
                       .IsActive
                   )
                    _linxB2CPedidosItensRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CPedidosItens")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CPedidos")
                       .First()
                       .IsActive
                   )
                    _linxB2CPedidosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CPedidos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CPedidosStatus")
                       .First()
                       .IsActive
                   )
                    _linxB2CPedidosStatusRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CPedidosStatus")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CStatus")
                       .First()
                       .IsActive
                   )
                    _linxB2CStatusRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CStatus")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCategoriasFinanceiras")
                       .First()
                       .IsActive
                   )
                    _linxCategoriasFinanceirasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCategoriasFinanceiras")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCentroCusto")
                       .First()
                       .IsActive
                   )
                    _linxCentroCustoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCentroCusto")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCest")
                       .First()
                       .IsActive
                   )
                    _linxCestRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCest")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCfopFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCfopFiscalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCfopFiscal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClasseFiscal")
                       .First()
                       .IsActive
                   )
                    _linxClasseFiscalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClasseFiscal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClassificacoes")
                       .First()
                       .IsActive
                   )
                    _linxClassificacoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClassificacoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecCamposAdicionais")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecCamposAdicionaisRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecCamposAdicionais")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecClasses")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecClassesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecClasses")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecContatosParentesco")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecContatosParentescoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecContatosParentesco")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecContatos")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecContatosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecContatos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecCreditoAvulso")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecCreditoAvulsoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecCreditoAvulso")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornec")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornec")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesRede")
                       .First()
                       .IsActive
                   )
                    _linxClientesRedeRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesRede")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxColecoes")
                       .First()
                       .IsActive
                   )
                    _linxColecoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxColecoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxComissoesVendedores")
                       .First()
                       .IsActive
                   )
                    _linxComissoesVendedoresRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxComissoesVendedores")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhes")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasDetalhesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhesSimplificado")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasDetalhesSimplificadoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhesSimplificado")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributariasEmpresas")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasEmpresasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributariasEmpresas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributarias")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributarias")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCores")
                       .First()
                       .IsActive
                   )
                    _linxCoresRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCores")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCsosnFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCsosnFiscalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCsosnFiscal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstCofinsFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstCofinsFiscalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstCofinsFiscal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstIcmsFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstIcmsFiscalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstIcmsFiscal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstIpiFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstIpiFiscalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstIpiFiscal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstPisFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstPisFiscalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstPisFiscal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCupomDesconto")
                       .First()
                       .IsActive
                   )
                    _linxCupomDescontoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCupomDesconto")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCupomDescontoVendas")
                       .First()
                       .IsActive
                   )
                    _linxCupomDescontoVendasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCupomDescontoVendas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDadosOpticosDav")
                       .First()
                       .IsActive
                   )
                    _linxDadosOpticosDavRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDadosOpticosDav")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaItem")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaItemRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaItem")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabrica")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabrica")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaStatus")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaStatusRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaStatus")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaTipo")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaTipoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaTipo")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxECFFormasPagamento")
                       .First()
                       .IsActive
                   )
                    _linxECFFormasPagamentoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxECFFormasPagamento")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxECF")
                       .First()
                       .IsActive
                   )
                    _linxECFRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxECF")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxEnquadramentoIpi")
                       .First()
                       .IsActive
                   )
                    _linxEnquadramentoIpiRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxEnquadramentoIpi")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxEspessuras")
                       .First()
                       .IsActive
                   )
                    _linxEspessurasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxEspessuras")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFaturasOrigem")
                       .First()
                       .IsActive
                   )
                    _linxFaturasOrigemRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFaturasOrigem")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFaturas")
                       .First()
                       .IsActive
                   )
                    _linxFaturasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFaturas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFechamentoCaixa")
                       .First()
                       .IsActive
                   )
                    _linxFechamentoCaixaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFechamentoCaixa")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFidelidade")
                       .First()
                       .IsActive
                   )
                    _linxFidelidadeRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFidelidade")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxGrupoLojas")
                       .First()
                       .IsActive
                   )
                    _linxGrupoLojasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxGrupoLojas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLancContabil")
                       .First()
                       .IsActive
                   )
                    _linxLancContabilRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLancContabil")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLinhas")
                       .First()
                       .IsActive
                   )
                    _linxLinhasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLinhas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxListaDaVez")
                       .First()
                       .IsActive
                   )
                    _linxListaDaVezRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxListaDaVez")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxListagemBalanco")
                       .First()
                       .IsActive
                   )
                    _linxListagemBalancoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxListagemBalanco")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLojasParametros")
                       .First()
                       .IsActive
                   )
                    _linxLojasParametrosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLojasParametros")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLojas")
                       .First()
                       .IsActive
                   )
                    _linxLojasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLojas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLotesProdutos")
                       .First()
                       .IsActive
                   )
                    _linxLotesProdutosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLotesProdutos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMarcas")
                       .First()
                       .IsActive
                   )
                    _linxMarcasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMarcas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMetasVendedoresDia")
                       .First()
                       .IsActive
                   )
                    _linxMetasVendedoresDiaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMetasVendedoresDia")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMetasVendedores")
                       .First()
                       .IsActive
                   )
                    _linxMetasVendedoresRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMetasVendedores")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMetodos")
                       .First()
                       .IsActive
                   )
                    _linxMetodosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMetodos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMotivoDesconto")
                       .First()
                       .IsActive
                   )
                    _linxMotivoDescontoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMotivoDesconto")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMotivoDevolucao")
                       .First()
                       .IsActive
                   )
                    _linxMotivoDevolucaoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMotivoDevolucao")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMotivosDesoneracaoIcms")
                       .First()
                       .IsActive
                   )
                    _linxMotivosDesoneracaoIcmsRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMotivosDesoneracaoIcms")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoAcoesPromocionais")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoAcoesPromocionaisRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoAcoesPromocionais")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoCamposAdicionais")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoCamposAdicionaisRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoCamposAdicionais")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoCartoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoCartoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoCartoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoDevolucoesItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoDevolucoesItensRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoDevolucoesItens")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoExtensao")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoExtensaoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoExtensao")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoGiftCard")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoGiftCardRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoGiftCard")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoIndicacoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoIndicacoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoIndicacoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoObservacaoCF")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoObservacaoCFRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoObservacaoCF")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoObservacoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoObservacoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoObservacoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoOrdemServicoExterna")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoOrdemServicoExternaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoOrdemServicoExterna")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoOrigemDevolucoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoOrigemDevolucoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoOrigemDevolucoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoPlanos")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoPlanosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoPlanos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoPrincipal")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoPrincipalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoPrincipal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessasAcertosItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasAcertosItensRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessasAcertosItens")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessasAcertos")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasAcertosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessasAcertos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessasItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasItensRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessasItens")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessas")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimento")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimento")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoReshopItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoReshopItensRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoReshopItens")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoReshop")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoReshopRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoReshop")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoSerial")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoSerialRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoSerial")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoTrocafone")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoTrocafoneRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoTrocafone")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoTrocas")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoTrocasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoTrocas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoVendaConjugada")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoVendaConjugadaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoVendaConjugada")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNaturezaOperacao")
                       .First()
                       .IsActive
                   )
                    _linxNaturezaOperacaoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNaturezaOperacao")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNcm")
                       .First()
                       .IsActive
                   )
                    _linxNcmRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNcm")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNfceEstacao")
                       .First()
                       .IsActive
                   )
                    _linxNfceEstacaoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNfceEstacao")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNFeEvento")
                       .First()
                       .IsActive
                   )
                    _linxNFeEventoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNFeEvento")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNfse")
                       .First()
                       .IsActive
                   )
                    _linxNfseRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNfse")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrcamentoComponenteFormula")
                       .First()
                       .IsActive
                   )
                    _linxOrcamentoComponenteFormulaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrcamentoComponenteFormula")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdemServicoExternaDav")
                       .First()
                       .IsActive
                   )
                    _linxOrdemServicoExternaDavRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdemServicoExternaDav")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdensServicoPosicaoOsRamoOpticoHistorico")
                       .First()
                       .IsActive
                   )
                    _linxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdensServicoPosicaoOsRamoOpticoHistorico")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdensServicoProdutos")
                       .First()
                       .IsActive
                   )
                    _linxOrdensServicoProdutosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdensServicoProdutos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdensServico")
                       .First()
                       .IsActive
                   )
                    _linxOrdensServicoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdensServico")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOticoPrismaDescricao")
                       .First()
                       .IsActive
                   )
                    _linxOticoPrismaDescricaoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOticoPrismaDescricao")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOticoReceitas")
                       .First()
                       .IsActive
                   )
                    _linxOticoReceitasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOticoReceitas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPagamentoParcialDav")
                       .First()
                       .IsActive
                   )
                    _linxPagamentoParcialDavRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPagamentoParcialDav")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosCompra")
                       .First()
                       .IsActive
                   )
                    _linxPedidosCompraRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosCompra")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaArmazenamento")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaChecklistEntregaArmazenamentoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaArmazenamento")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaDificuldade")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaChecklistEntregaDificuldadeRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaDificuldade")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaLocal")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaChecklistEntregaLocalRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaLocal")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVenda")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVenda")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPerguntaVenda")
                       .First()
                       .IsActive
                   )
                    _linxPerguntaVendaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPerguntaVenda")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanoContas")
                       .First()
                       .IsActive
                   )
                    _linxPlanoContasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanoContas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanosBandeiras")
                       .First()
                       .IsActive
                   )
                    _linxPlanosBandeirasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanosBandeiras")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanosBandeiras")
                       .First()
                       .IsActive
                   )
                    _linxPlanosBandeirasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanosBandeiras")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanos")
                       .First()
                       .IsActive
                   )
                    _linxPlanosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPosicaoOsRamoOptico")
                       .First()
                       .IsActive
                   )
                    _linxPosicaoOsRamoOpticoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPosicaoOsRamoOptico")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosAssociados")
                       .First()
                       .IsActive
                   )
                    _linxProdutosAssociadosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosAssociados")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosCamposAdicionais")
                       .First()
                       .IsActive
                   )
                    _linxProdutosCamposAdicionaisRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosCamposAdicionais")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosCodBar")
                       .First()
                       .IsActive
                   )
                    _linxProdutosCodBarRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosCodBar")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDepositos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDepositosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDepositos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDetalhesDepositos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDetalhesDepositosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDetalhesDepositos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDetalhes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDetalhesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDetalhes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDetalhesSimplificado")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDetalhesSimplificadoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDetalhesSimplificado")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosFornec")
                       .First()
                       .IsActive
                   )
                    _linxProdutosFornecRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosFornec")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosInformacoes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosInformacoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosInformacoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosInventario")
                       .First()
                       .IsActive
                   )
                    _linxProdutosInventarioRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosInventario")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosLotes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosLotesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosLotes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosOpticosFormatoAro")
                       .First()
                       .IsActive
                   )
                    _linxProdutosOpticosFormatoAroRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosOpticosFormatoAro")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosOpticosTipoAro")
                       .First()
                       .IsActive
                   )
                    _linxProdutosOpticosTipoAroRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosOpticosTipoAro")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosOpticosTipo")
                       .First()
                       .IsActive
                   )
                    _linxProdutosOpticosTipoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosOpticosTipo")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosPromocoes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosPromocoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosPromocoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosSerial")
                       .First()
                       .IsActive
                   )
                    _linxProdutosSerialRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosSerial")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosTabelasPrecos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosTabelasPrecosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosTabelasPrecos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosTabelas")
                       .First()
                       .IsActive
                   )
                    _linxProdutosTabelasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosTabelas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRamosAtividade")
                       .First()
                       .IsActive
                   )
                    _linxRamosAtividadeRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRamosAtividade")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxReducoesZ")
                       .First()
                       .IsActive
                   )
                    _linxReducoesZRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxReducoesZ")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRemessasIdentificadores")
                       .First()
                       .IsActive
                   )
                    _linxRemessasIdentificadoresRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRemessasIdentificadores")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRemessasOperacoes")
                       .First()
                       .IsActive
                   )
                    _linxRemessasOperacoesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRemessasOperacoes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRemessasRetornoTipos")
                       .First()
                       .IsActive
                   )
                    _linxRemessasRetornoTiposRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRemessasRetornoTipos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRespostaVenda")
                       .First()
                       .IsActive
                   )
                    _linxRespostaVendaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRespostaVenda")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRotinaOrigem")
                       .First()
                       .IsActive
                   )
                    _linxRotinaOrigemRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRotinaOrigem")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSangriaSuprimentos")
                       .First()
                       .IsActive
                   )
                    _linxSangriaSuprimentosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSangriaSuprimentos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSerialVenda")
                       .First()
                       .IsActive
                   )
                    _linxSerialVendaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSerialVenda")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSeries")
                       .First()
                       .IsActive
                   )
                    _linxSeriesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSeries")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxServicosDetalhes")
                       .First()
                       .IsActive
                   )
                    _linxServicosDetalhesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxServicosDetalhes")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxServicos")
                       .First()
                       .IsActive
                   )
                    _linxServicosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxServicos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSetores")
                       .First()
                       .IsActive
                   )
                    _linxSetoresRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSetores")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSpedTipoBaseCredito")
                       .First()
                       .IsActive
                   )
                    _linxSpedTipoBaseCreditoRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSpedTipoBaseCredito")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSpedTipoItem")
                       .First()
                       .IsActive
                   )
                    _linxSpedTipoItemRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSpedTipoItem")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSubClasses")
                       .First()
                       .IsActive
                   )
                    _linxSubClassesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSubClasses")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTamanhos")
                       .First()
                       .IsActive
                   )
                    _linxTamanhosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTamanhos")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTradeinParceiro")
                       .First()
                       .IsActive
                   )
                    _linxTradeinParceiroRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTradeinParceiro")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTrocaUnificadaResumoBaixa")
                       .First()
                       .IsActive
                   )
                    _linxTrocaUnificadaResumoBaixaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTrocaUnificadaResumoBaixa")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendasItens")
                       .First()
                       .IsActive
                   )
                    _linxTrocaUnificadaResumoVendasItensRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendasItens")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendas")
                       .First()
                       .IsActive
                   )
                    _linxTrocaUnificadaResumoVendasRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendas")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxUnidades")
                       .First()
                       .IsActive
                   )
                    _linxUnidadesRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxUnidades")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxValeOrdemServicoExterna")
                       .First()
                       .IsActive
                   )
                    _linxValeOrdemServicoExternaRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxValeOrdemServicoExterna")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxValesComprasEnviadosAPI")
                       .First()
                       .IsActive
                   )
                    _linxValesComprasEnviadosAPIRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxValesComprasEnviadosAPI")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxVendedores")
                       .First()
                       .IsActive
                   )
                    _linxVendedoresRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxVendedores")
                                        .First()
                                        .MethodName,
                                untreatedDatabaseName: parameters.untreatedDatabaseName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxXMLDocumentos")
                       .First()
                       .IsActive
                   )
                    _linxXMLDocumentosRepository.CreateTableIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxXMLDocumentos")
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

        public async Task<bool> CreateTablesMerges(Parameter parameters, List<LinxMethods>? listMethods)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertParametersIfNotExists(Parameter parameters, List<LinxMethods>? listMethods)
        {
            try
            {
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAcoesPromocionaisCombinacaoProdutosItens")
                       .First()
                       .IsActive
                   )
                    _linxAcoesPromocionaisCombinacaoProdutosItensRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAcoesPromocionaisCombinacaoProdutosItens")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAcoesPromocionaisProdutosCortesia")
                       .First()
                       .IsActive
                   )
                    _linxAcoesPromocionaisProdutosCortesiaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAcoesPromocionaisProdutosCortesia")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAcoesPromocionais")
                       .First()
                       .IsActive
                   )
                    _linxAcoesPromocionaisRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAcoesPromocionais")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAntecipacoesFinanceirasPlanos")
                       .First()
                       .IsActive
                   )
                    _linxAntecipacoesFinanceirasPlanosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAntecipacoesFinanceirasPlanos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxAntecipacoesFinanceiras")
                       .First()
                       .IsActive
                   )
                    _linxAntecipacoesFinanceirasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxAntecipacoesFinanceiras")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CPedidosItens")
                       .First()
                       .IsActive
                   )
                    _linxB2CPedidosItensRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CPedidosItens")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CPedidos")
                       .First()
                       .IsActive
                   )
                    _linxB2CPedidosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CPedidos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CPedidosStatus")
                       .First()
                       .IsActive
                   )
                    _linxB2CPedidosStatusRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CPedidosStatus")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxB2CStatus")
                       .First()
                       .IsActive
                   )
                    _linxB2CStatusRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxB2CStatus")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCategoriasFinanceiras")
                       .First()
                       .IsActive
                   )
                    _linxCategoriasFinanceirasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCategoriasFinanceiras")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCentroCusto")
                       .First()
                       .IsActive
                   )
                    _linxCentroCustoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCentroCusto")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCest")
                       .First()
                       .IsActive
                   )
                    _linxCestRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCest")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCfopFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCfopFiscalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCfopFiscal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClasseFiscal")
                       .First()
                       .IsActive
                   )
                    _linxClasseFiscalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClasseFiscal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClassificacoes")
                       .First()
                       .IsActive
                   )
                    _linxClassificacoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClassificacoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecCamposAdicionais")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecCamposAdicionaisRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecCamposAdicionais")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecClasses")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecClassesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecClasses")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecContatosParentesco")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecContatosParentescoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecContatosParentesco")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecContatos")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecContatosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecContatos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornecCreditoAvulso")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecCreditoAvulsoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornecCreditoAvulso")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesFornec")
                       .First()
                       .IsActive
                   )
                    _linxClientesFornecRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesFornec")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxClientesRede")
                       .First()
                       .IsActive
                   )
                    _linxClientesRedeRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxClientesRede")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxColecoes")
                       .First()
                       .IsActive
                   )
                    _linxColecoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxColecoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxComissoesVendedores")
                       .First()
                       .IsActive
                   )
                    _linxComissoesVendedoresRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxComissoesVendedores")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhes")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasDetalhesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhesSimplificado")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasDetalhesSimplificadoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributariasDetalhesSimplificado")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributariasEmpresas")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasEmpresasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributariasEmpresas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxConfiguracoesTributarias")
                       .First()
                       .IsActive
                   )
                    _linxConfiguracoesTributariasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxConfiguracoesTributarias")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCores")
                       .First()
                       .IsActive
                   )
                    _linxCoresRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCores")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCsosnFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCsosnFiscalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCsosnFiscal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstCofinsFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstCofinsFiscalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstCofinsFiscal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstIcmsFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstIcmsFiscalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstIcmsFiscal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstIpiFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstIpiFiscalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstIpiFiscal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCstPisFiscal")
                       .First()
                       .IsActive
                   )
                    _linxCstPisFiscalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCstPisFiscal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCupomDesconto")
                       .First()
                       .IsActive
                   )
                    _linxCupomDescontoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCupomDesconto")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxCupomDescontoVendas")
                       .First()
                       .IsActive
                   )
                    _linxCupomDescontoVendasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxCupomDescontoVendas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDadosOpticosDav")
                       .First()
                       .IsActive
                   )
                    _linxDadosOpticosDavRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDadosOpticosDav")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaItem")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaItemRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaItem")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabrica")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabrica")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaStatus")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaStatusRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaStatus")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaTipo")
                       .First()
                       .IsActive
                   )
                    _linxDevolucaoRemanejoFabricaTipoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxDevolucaoRemanejoFabricaTipo")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxECFFormasPagamento")
                       .First()
                       .IsActive
                   )
                    _linxECFFormasPagamentoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxECFFormasPagamento")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxECF")
                       .First()
                       .IsActive
                   )
                    _linxECFRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxECF")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxEnquadramentoIpi")
                       .First()
                       .IsActive
                   )
                    _linxEnquadramentoIpiRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxEnquadramentoIpi")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxEspessuras")
                       .First()
                       .IsActive
                   )
                    _linxEspessurasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxEspessuras")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFaturasOrigem")
                       .First()
                       .IsActive
                   )
                    _linxFaturasOrigemRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFaturasOrigem")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFaturas")
                       .First()
                       .IsActive
                   )
                    _linxFaturasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFaturas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFechamentoCaixa")
                       .First()
                       .IsActive
                   )
                    _linxFechamentoCaixaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFechamentoCaixa")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxFidelidade")
                       .First()
                       .IsActive
                   )
                    _linxFidelidadeRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxFidelidade")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxGrupoLojas")
                       .First()
                       .IsActive
                   )
                    _linxGrupoLojasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxGrupoLojas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLancContabil")
                       .First()
                       .IsActive
                   )
                    _linxLancContabilRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLancContabil")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLinhas")
                       .First()
                       .IsActive
                   )
                    _linxLinhasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLinhas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxListaDaVez")
                       .First()
                       .IsActive
                   )
                    _linxListaDaVezRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxListaDaVez")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxListagemBalanco")
                       .First()
                       .IsActive
                   )
                    _linxListagemBalancoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxListagemBalanco")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLojasParametros")
                       .First()
                       .IsActive
                   )
                    _linxLojasParametrosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLojasParametros")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLojas")
                       .First()
                       .IsActive
                   )
                    _linxLojasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLojas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxLotesProdutos")
                       .First()
                       .IsActive
                   )
                    _linxLotesProdutosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxLotesProdutos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMarcas")
                       .First()
                       .IsActive
                   )
                    _linxMarcasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMarcas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMetasVendedoresDia")
                       .First()
                       .IsActive
                   )
                    _linxMetasVendedoresDiaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMetasVendedoresDia")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMetasVendedores")
                       .First()
                       .IsActive
                   )
                    _linxMetasVendedoresRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMetasVendedores")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMetodos")
                       .First()
                       .IsActive
                   )
                    _linxMetodosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMetodos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMotivoDesconto")
                       .First()
                       .IsActive
                   )
                    _linxMotivoDescontoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMotivoDesconto")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMotivoDevolucao")
                       .First()
                       .IsActive
                   )
                    _linxMotivoDevolucaoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMotivoDevolucao")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMotivosDesoneracaoIcms")
                       .First()
                       .IsActive
                   )
                    _linxMotivosDesoneracaoIcmsRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMotivosDesoneracaoIcms")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoAcoesPromocionais")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoAcoesPromocionaisRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoAcoesPromocionais")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoCamposAdicionais")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoCamposAdicionaisRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoCamposAdicionais")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoCartoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoCartoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoCartoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoDevolucoesItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoDevolucoesItensRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoDevolucoesItens")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoExtensao")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoExtensaoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoExtensao")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoGiftCard")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoGiftCardRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoGiftCard")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoIndicacoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoIndicacoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoIndicacoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoObservacaoCF")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoObservacaoCFRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoObservacaoCF")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoObservacoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoObservacoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoObservacoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoOrdemServicoExterna")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoOrdemServicoExternaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoOrdemServicoExterna")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoOrigemDevolucoes")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoOrigemDevolucoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoOrigemDevolucoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoPlanos")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoPlanosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoPlanos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoPrincipal")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoPrincipalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoPrincipal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessasAcertosItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasAcertosItensRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessasAcertosItens")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessasAcertos")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasAcertosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessasAcertos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessasItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasItensRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessasItens")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoRemessas")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRemessasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoRemessas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimento")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimento")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoReshopItens")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoReshopItensRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoReshopItens")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoReshop")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoReshopRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoReshop")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoSerial")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoSerialRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoSerial")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoTrocafone")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoTrocafoneRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoTrocafone")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoTrocas")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoTrocasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoTrocas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxMovimentoVendaConjugada")
                       .First()
                       .IsActive
                   )
                    _linxMovimentoVendaConjugadaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxMovimentoVendaConjugada")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNaturezaOperacao")
                       .First()
                       .IsActive
                   )
                    _linxNaturezaOperacaoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNaturezaOperacao")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNcm")
                       .First()
                       .IsActive
                   )
                    _linxNcmRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNcm")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNfceEstacao")
                       .First()
                       .IsActive
                   )
                    _linxNfceEstacaoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNfceEstacao")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNFeEvento")
                       .First()
                       .IsActive
                   )
                    _linxNFeEventoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNFeEvento")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxNfse")
                       .First()
                       .IsActive
                   )
                    _linxNfseRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxNfse")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrcamentoComponenteFormula")
                       .First()
                       .IsActive
                   )
                    _linxOrcamentoComponenteFormulaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrcamentoComponenteFormula")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdemServicoExternaDav")
                       .First()
                       .IsActive
                   )
                    _linxOrdemServicoExternaDavRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdemServicoExternaDav")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdensServicoPosicaoOsRamoOpticoHistorico")
                       .First()
                       .IsActive
                   )
                    _linxOrdensServicoPosicaoOsRamoOpticoHistoricoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdensServicoPosicaoOsRamoOpticoHistorico")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdensServicoProdutos")
                       .First()
                       .IsActive
                   )
                    _linxOrdensServicoProdutosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdensServicoProdutos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOrdensServico")
                       .First()
                       .IsActive
                   )
                    _linxOrdensServicoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOrdensServico")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOticoPrismaDescricao")
                       .First()
                       .IsActive
                   )
                    _linxOticoPrismaDescricaoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOticoPrismaDescricao")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxOticoReceitas")
                       .First()
                       .IsActive
                   )
                    _linxOticoReceitasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxOticoReceitas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPagamentoParcialDav")
                       .First()
                       .IsActive
                   )
                    _linxPagamentoParcialDavRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPagamentoParcialDav")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosCompra")
                       .First()
                       .IsActive
                   )
                    _linxPedidosCompraRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosCompra")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaArmazenamento")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaChecklistEntregaArmazenamentoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaArmazenamento")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaDificuldade")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaChecklistEntregaDificuldadeRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaDificuldade")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaLocal")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaChecklistEntregaLocalRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVendaChecklistEntregaLocal")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPedidosVenda")
                       .First()
                       .IsActive
                   )
                    _linxPedidosVendaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPedidosVenda")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPerguntaVenda")
                       .First()
                       .IsActive
                   )
                    _linxPerguntaVendaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPerguntaVenda")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanoContas")
                       .First()
                       .IsActive
                   )
                    _linxPlanoContasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanoContas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanosBandeiras")
                       .First()
                       .IsActive
                   )
                    _linxPlanosBandeirasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanosBandeiras")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanosBandeiras")
                       .First()
                       .IsActive
                   )
                    _linxPlanosBandeirasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanosBandeiras")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPlanos")
                       .First()
                       .IsActive
                   )
                    _linxPlanosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPlanos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxPosicaoOsRamoOptico")
                       .First()
                       .IsActive
                   )
                    _linxPosicaoOsRamoOpticoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxPosicaoOsRamoOptico")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosAssociados")
                       .First()
                       .IsActive
                   )
                    _linxProdutosAssociadosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosAssociados")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosCamposAdicionais")
                       .First()
                       .IsActive
                   )
                    _linxProdutosCamposAdicionaisRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosCamposAdicionais")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosCodBar")
                       .First()
                       .IsActive
                   )
                    _linxProdutosCodBarRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosCodBar")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDepositos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDepositosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDepositos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDetalhesDepositos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDetalhesDepositosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDetalhesDepositos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDetalhes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDetalhesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDetalhes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosDetalhesSimplificado")
                       .First()
                       .IsActive
                   )
                    _linxProdutosDetalhesSimplificadoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosDetalhesSimplificado")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosFornec")
                       .First()
                       .IsActive
                   )
                    _linxProdutosFornecRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosFornec")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosInformacoes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosInformacoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosInformacoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosInventario")
                       .First()
                       .IsActive
                   )
                    _linxProdutosInventarioRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosInventario")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosLotes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosLotesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosLotes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosOpticosFormatoAro")
                       .First()
                       .IsActive
                   )
                    _linxProdutosOpticosFormatoAroRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosOpticosFormatoAro")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosOpticosTipoAro")
                       .First()
                       .IsActive
                   )
                    _linxProdutosOpticosTipoAroRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosOpticosTipoAro")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosOpticosTipo")
                       .First()
                       .IsActive
                   )
                    _linxProdutosOpticosTipoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosOpticosTipo")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosPromocoes")
                       .First()
                       .IsActive
                   )
                    _linxProdutosPromocoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosPromocoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosSerial")
                       .First()
                       .IsActive
                   )
                    _linxProdutosSerialRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosSerial")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosTabelasPrecos")
                       .First()
                       .IsActive
                   )
                    _linxProdutosTabelasPrecosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosTabelasPrecos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxProdutosTabelas")
                       .First()
                       .IsActive
                   )
                    _linxProdutosTabelasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxProdutosTabelas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRamosAtividade")
                       .First()
                       .IsActive
                   )
                    _linxRamosAtividadeRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRamosAtividade")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxReducoesZ")
                       .First()
                       .IsActive
                   )
                    _linxReducoesZRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxReducoesZ")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRemessasIdentificadores")
                       .First()
                       .IsActive
                   )
                    _linxRemessasIdentificadoresRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRemessasIdentificadores")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRemessasOperacoes")
                       .First()
                       .IsActive
                   )
                    _linxRemessasOperacoesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRemessasOperacoes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRemessasRetornoTipos")
                       .First()
                       .IsActive
                   )
                    _linxRemessasRetornoTiposRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRemessasRetornoTipos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRespostaVenda")
                       .First()
                       .IsActive
                   )
                    _linxRespostaVendaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRespostaVenda")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxRotinaOrigem")
                       .First()
                       .IsActive
                   )
                    _linxRotinaOrigemRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxRotinaOrigem")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSangriaSuprimentos")
                       .First()
                       .IsActive
                   )
                    _linxSangriaSuprimentosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSangriaSuprimentos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSerialVenda")
                       .First()
                       .IsActive
                   )
                    _linxSerialVendaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSerialVenda")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSeries")
                       .First()
                       .IsActive
                   )
                    _linxSeriesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSeries")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxServicosDetalhes")
                       .First()
                       .IsActive
                   )
                    _linxServicosDetalhesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxServicosDetalhes")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxServicos")
                       .First()
                       .IsActive
                   )
                    _linxServicosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxServicos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSetores")
                       .First()
                       .IsActive
                   )
                    _linxSetoresRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSetores")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSpedTipoBaseCredito")
                       .First()
                       .IsActive
                   )
                    _linxSpedTipoBaseCreditoRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSpedTipoBaseCredito")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSpedTipoItem")
                       .First()
                       .IsActive
                   )
                    _linxSpedTipoItemRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSpedTipoItem")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxSubClasses")
                       .First()
                       .IsActive
                   )
                    _linxSubClassesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxSubClasses")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTamanhos")
                       .First()
                       .IsActive
                   )
                    _linxTamanhosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTamanhos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTradeinParceiro")
                       .First()
                       .IsActive
                   )
                    _linxTradeinParceiroRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTradeinParceiro")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTrocaUnificadaResumoBaixa")
                       .First()
                       .IsActive
                   )
                    _linxTrocaUnificadaResumoBaixaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTrocaUnificadaResumoBaixa")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendasItens")
                       .First()
                       .IsActive
                   )
                    _linxTrocaUnificadaResumoVendasItensRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendasItens")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendas")
                       .First()
                       .IsActive
                   )
                    _linxTrocaUnificadaResumoVendasRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxTrocaUnificadaResumoVendas")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxUnidades")
                       .First()
                       .IsActive
                   )
                    _linxUnidadesRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxUnidades")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxValeOrdemServicoExterna")
                       .First()
                       .IsActive
                   )
                    _linxValeOrdemServicoExternaRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxValeOrdemServicoExterna")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxValesComprasEnviadosAPI")
                       .First()
                       .IsActive
                   )
                    _linxValesComprasEnviadosAPIRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxValesComprasEnviadosAPI")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxVendedores")
                       .First()
                       .IsActive
                   )
                    _linxVendedoresRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxVendedores")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );
                if (
                   listMethods
                       .Where(m => m.MethodName == "LinxXMLDocumentos")
                       .First()
                       .IsActive
                   )
                    _linxXMLDocumentosRepository.InsertParametersIfNotExists(
                                databaseName: parameters.databaseName,
                                jobName: listMethods
                                        .Where(m => m.MethodName == "LinxXMLDocumentos")
                                        .First()
                                        .MethodName,
                                parametersTableName: parameters.parametersTableName
                            );

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
