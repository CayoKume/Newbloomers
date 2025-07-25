using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Schemas;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data
{
    public partial class LinxMicrovixOutboundTreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LinxMicrovixOutboundTreatedDbContext(DbContextOptions<LinxMicrovixOutboundTreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        public DbSet<LinxAcoesPromocionais> LinxAcoesPromocionais { get; set; } = null!;
        public DbSet<LinxAcoesPromocionaisCombinacaoProdutosItens> LinxAcoesPromocionaisCombinacaoProdutosItens { get; set; } = null!;
        public DbSet<LinxAcoesPromocionaisProdutosCortesia> LinxAcoesPromocionaisProdutosCortesia { get; set; } = null!;
        public DbSet<LinxAntecipacoesFinanceiras> LinxAntecipacoesFinanceiras { get; set; } = null!;
        public DbSet<LinxAntecipacoesFinanceirasPlanos> LinxAntecipacoesFinanceirasPlanos { get; set; } = null!;
        public DbSet<LinxB2CPedidos> LinxB2CPedidos { get; set; } = null!;
        public DbSet<LinxB2CPedidosItens> LinxB2CPedidosItens { get; set; } = null!;
        public DbSet<LinxB2CPedidosStatus> LinxB2CPedidosStatus { get; set; } = null!;
        public DbSet<LinxB2CStatus> LinxB2CStatus { get; set; } = null!;
        public DbSet<LinxCategoriasFinanceiras> LinxCategoriasFinanceiras { get; set; } = null!;
        public DbSet<LinxCentroCusto> LinxCentroCusto { get; set; } = null!;
        public DbSet<LinxCest> LinxCest { get; set; } = null!;
        public DbSet<LinxCfopFiscal> LinxCfopFiscal { get; set; } = null!;
        public DbSet<LinxClasseFiscal> LinxClasseFiscal { get; set; } = null!;
        public DbSet<LinxClassificacoes> LinxClassificacoes { get; set; } = null!;
        public DbSet<LinxClientesEnderecosEntrega> LinxClientesEnderecosEntrega { get; set; } = null!;
        public DbSet<LinxClientesFornec> LinxClientesFornec { get; set; } = null!;
        public DbSet<LinxClientesFornecCamposAdicionais> LinxClientesFornecCamposAdicionais { get; set; } = null!;
        public DbSet<LinxClientesFornecClasses> LinxClientesFornecClasses { get; set; } = null!;
        public DbSet<LinxClientesFornecContatos> LinxClientesFornecContatos { get; set; } = null!;
        public DbSet<LinxClientesFornecContatosParentesco> LinxClientesFornecContatosParentesco { get; set; } = null!;
        public DbSet<LinxClientesFornecCreditoAvulso> LinxClientesFornecCreditoAvulso { get; set; } = null!;
        public DbSet<LinxClientesRede> LinxClientesRede { get; set; } = null!;
        public DbSet<LinxColecoes> LinxColecoes { get; set; } = null!;
        public DbSet<LinxComissoesVendedores> LinxComissoesVendedores { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributarias> LinxConfiguracoesTributarias { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributariasDetalhes> LinxConfiguracoesTributariasDetalhes { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributariasDetalhesSimplificado> LinxConfiguracoesTributariasDetalhesSimplificado { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributariasEmpresas> LinxConfiguracoesTributariasEmpresas { get; set; } = null!;
        public DbSet<LinxCores> LinxCores { get; set; } = null!;
        public DbSet<LinxCsosnFiscal> LinxCsosnFiscal { get; set; } = null!;
        public DbSet<LinxCstCofinsFiscal> LinxCstCofinsFiscal { get; set; } = null!;
        public DbSet<LinxCstIcmsFiscal> LinxCstIcmsFiscal { get; set; } = null!;
        public DbSet<LinxCstIpiFiscal> LinxCstIpiFiscal { get; set; } = null!;
        public DbSet<LinxCstPisFiscal> LinxCstPisFiscal { get; set; } = null!;
        public DbSet<LinxCupomDesconto> LinxCupomDesconto { get; set; } = null!;
        public DbSet<LinxCupomDescontoVendas> LinxCupomDescontoVendas { get; set; } = null!;
        public DbSet<LinxDadosOpticosDav> LinxDadosOpticosDav { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabrica> LinxDevolucaoRemanejoFabrica { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabricaItem> LinxDevolucaoRemanejoFabricaItem { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabricaStatus> LinxDevolucaoRemanejoFabricaStatus { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabricaTipo> LinxDevolucaoRemanejoFabricaTipo { get; set; } = null!;
        public DbSet<LinxECF> LinxECF { get; set; } = null!;
        public DbSet<LinxECFFormasPagamento> LinxECFFormasPagamento { get; set; } = null!;
        public DbSet<LinxEnquadramentoIpi> LinxEnquadramentoIpi { get; set; } = null!;
        public DbSet<LinxEspessuras> LinxEspessuras { get; set; } = null!;
        public DbSet<LinxFaturas> LinxFaturas { get; set; } = null!;
        public DbSet<LinxFaturasOrigem> LinxFaturasOrigem { get; set; } = null!;
        public DbSet<LinxFechamentoCaixa> LinxFechamentoCaixa { get; set; } = null!;
        public DbSet<LinxFidelidade> LinxFidelidade { get; set; } = null!;
        public DbSet<LinxGrupoLojas> LinxGrupoLojas { get; set; } = null!;
        public DbSet<LinxLancContabil> LinxLancContabil { get; set; } = null!;
        public DbSet<LinxLinhas> LinxLinhas { get; set; } = null!;
        public DbSet<LinxListaDaVez> LinxListaDaVez { get; set; } = null!;
        public DbSet<LinxListagemBalanco> LinxListagemBalanco { get; set; } = null!;
        public DbSet<LinxLojas> LinxLojas { get; set; } = null!;
        public DbSet<LinxLojasParametros> LinxLojasParametros { get; set; } = null!;
        public DbSet<LinxLotesProdutos> LinxLotesProdutos { get; set; } = null!;
        public DbSet<LinxMarcas> LinxMarcas { get; set; } = null!;
        public DbSet<LinxMetasVendedores> LinxMetasVendedores { get; set; } = null!;
        public DbSet<LinxMetasVendedoresDia> LinxMetasVendedoresDia { get; set; } = null!;
        public DbSet<LinxMetodos> LinxMetodos { get; set; } = null!;
        public DbSet<LinxMotivoDesconto> LinxMotivoDesconto { get; set; } = null!;
        public DbSet<LinxMotivoDevolucao> LinxMotivoDevolucao { get; set; } = null!;
        public DbSet<LinxMotivosDesoneracaoIcms> LinxMotivosDesoneracaoIcms { get; set; } = null!;
        public DbSet<LinxMovimento> LinxMovimento { get; set; } = null!;
        public DbSet<LinxMovimentoAcoesPromocionais> LinxMovimentoAcoesPromocionais { get; set; } = null!;
        public DbSet<LinxMovimentoCamposAdicionais> LinxMovimentoCamposAdicionais { get; set; } = null!;
        public DbSet<LinxMovimentoCartoes> LinxMovimentoCartoes { get; set; } = null!;
        public DbSet<LinxMovimentoDevolucoesItens> LinxMovimentoDevolucoesItens { get; set; } = null!;
        public DbSet<LinxMovimentoExtensao> LinxMovimentoExtensao { get; set; } = null!;
        public DbSet<LinxMovimentoGiftCard> LinxMovimentoGiftCard { get; set; } = null!;
        public DbSet<LinxMovimentoIndicacoes> LinxMovimentoIndicacoes { get; set; } = null!;
        public DbSet<LinxMovimentoObservacaoCF> LinxMovimentoObservacaoCF { get; set; } = null!;
        public DbSet<LinxMovimentoObservacoes> LinxMovimentoObservacoes { get; set; } = null!;
        public DbSet<LinxMovimentoOrdemServicoExterna> LinxMovimentoOrdemServicoExterna { get; set; } = null!;
        public DbSet<LinxMovimentoOrigemDevolucoes> LinxMovimentoOrigemDevolucoes { get; set; } = null!;
        public DbSet<LinxMovimentoPlanos> LinxMovimentoPlanos { get; set; } = null!;
        public DbSet<LinxMovimentoPrincipal> LinxMovimentoPrincipal { get; set; } = null!;
        public DbSet<LinxMovimentoRemessas> LinxMovimentoRemessas { get; set; } = null!;
        public DbSet<LinxMovimentoRemessasAcertos> LinxMovimentoRemessasAcertos { get; set; } = null!;
        public DbSet<LinxMovimentoRemessasAcertosItens> LinxMovimentoRemessasAcertosItens { get; set; } = null!;
        public DbSet<LinxMovimentoRemessasItens> LinxMovimentoRemessasItens { get; set; } = null!;
        public DbSet<LinxMovimentoReshop> LinxMovimentoReshop { get; set; } = null!;
        public DbSet<LinxMovimentoReshopItens> LinxMovimentoReshopItens { get; set; } = null!;
        public DbSet<LinxMovimentoSerial> LinxMovimentoSerial { get; set; } = null!;
        public DbSet<LinxMovimentoTrocafone> LinxMovimentoTrocafone { get; set; } = null!;
        public DbSet<LinxMovimentoTrocas> LinxMovimentoTrocas { get; set; } = null!;
        public DbSet<LinxMovimentoVendaConjugada> LinxMovimentoVendaConjugada { get; set; } = null!;
        public DbSet<LinxNaturezaOperacao> LinxNaturezaOperacao { get; set; } = null!;
        public DbSet<LinxNcm> LinxNcm { get; set; } = null!;
        public DbSet<LinxNfceEstacao> LinxNfceEstacao { get; set; } = null!;
        public DbSet<LinxNFeEvento> LinxNFeEvento { get; set; } = null!;
        public DbSet<LinxNfse> LinxNfse { get; set; } = null!;
        public DbSet<LinxOrcamentoComponenteFormula> LinxOrcamentoComponenteFormula { get; set; } = null!;
        public DbSet<LinxOrdemServicoExternaDav> LinxOrdemServicoExternaDav { get; set; } = null!;
        public DbSet<LinxOrdensServico> LinxOrdensServico { get; set; } = null!;
        public DbSet<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> LinxOrdensServicoPosicaoOsRamoOpticoHistorico { get; set; } = null!;
        public DbSet<LinxOrdensServicoProdutos> LinxOrdensServicoProdutos { get; set; } = null!;
        public DbSet<LinxOticoPrismaDescricao> LinxOticoPrismaDescricao { get; set; } = null!;
        public DbSet<LinxOticoReceitas> LinxOticoReceitas { get; set; } = null!;
        public DbSet<LinxPagamentoParcialDav> LinxPagamentoParcialDav { get; set; } = null!;
        public DbSet<LinxPedidosCompra> LinxPedidosCompra { get; set; } = null!;
        public DbSet<LinxPedidosVenda> LinxPedidosVenda { get; set; } = null!;
        public DbSet<LinxPedidosVendaChecklistEntregaArmazenamento> LinxPedidosVendaChecklistEntregaArmazenamento { get; set; } = null!;
        public DbSet<LinxPedidosVendaChecklistEntregaDificuldade> LinxPedidosVendaChecklistEntregaDificuldade { get; set; } = null!;
        public DbSet<LinxPedidosVendaChecklistEntregaLocal> LinxPedidosVendaChecklistEntregaLocal { get; set; } = null!;
        public DbSet<LinxPerguntaVenda> LinxPerguntaVenda { get; set; } = null!;
        public DbSet<LinxPlanoContas> LinxPlanoContas { get; set; } = null!;
        public DbSet<LinxPlanos> LinxPlanos { get; set; } = null!;
        public DbSet<LinxPlanosBandeiras> LinxPlanosBandeiras { get; set; } = null!;
        public DbSet<LinxPlanosPedidoVenda> LinxPlanosPedidoVenda { get; set; } = null!;
        public DbSet<LinxPosicaoOsRamoOptico> LinxPosicaoOsRamoOptico { get; set; } = null!;
        public DbSet<LinxProdutos> LinxProdutos { get; set; } = null!;
        public DbSet<LinxProdutosAssociados> LinxProdutosAssociados { get; set; } = null!;
        public DbSet<LinxProdutosCamposAdicionais> LinxProdutosCamposAdicionais { get; set; } = null!;
        public DbSet<LinxProdutosCodBar> LinxProdutosCodBar { get; set; } = null!;
        public DbSet<LinxProdutosDepositos> LinxProdutosDepositos { get; set; } = null!;
        public DbSet<LinxProdutosDetalhes> LinxProdutosDetalhes { get; set; } = null!;
        public DbSet<LinxProdutosDetalhesDepositos> LinxProdutosDetalhesDepositos { get; set; } = null!;
        public DbSet<LinxProdutosDetalhesSimplificado> LinxProdutosDetalhesSimplificado { get; set; } = null!;
        public DbSet<LinxProdutosFornec> LinxProdutosFornec { get; set; } = null!;
        public DbSet<LinxProdutosInformacoes> LinxProdutosInformacoes { get; set; } = null!;
        public DbSet<LinxProdutosInventario> LinxProdutosInventario { get; set; } = null!;
        public DbSet<LinxProdutosLotes> LinxProdutosLotes { get; set; } = null!;
        public DbSet<LinxProdutosOpticosFormatoAro> LinxProdutosOpticosFormatoAro { get; set; } = null!;
        public DbSet<LinxProdutosOpticosTipo> LinxProdutosOpticosTipo { get; set; } = null!;
        public DbSet<LinxProdutosOpticosTipoAro> LinxProdutosOpticosTipoAro { get; set; } = null!;
        public DbSet<LinxProdutosPromocoes> LinxProdutosPromocoes { get; set; } = null!;
        public DbSet<LinxProdutosSerial> LinxProdutosSerial { get; set; } = null!;
        public DbSet<LinxProdutosTabelas> LinxProdutosTabelas { get; set; } = null!;
        public DbSet<LinxProdutosTabelasPrecos> LinxProdutosTabelasPrecos { get; set; } = null!;
        public DbSet<LinxRamosAtividade> LinxRamosAtividade { get; set; } = null!;
        //public DbSet<LinxReducoesZ> LinxReducoesZ { get; set; } = null!;
        public DbSet<LinxRemessasIdentificadores> LinxRemessasIdentificadores { get; set; } = null!;
        public DbSet<LinxRemessasOperacoes> LinxRemessasOperacoes { get; set; } = null!;
        public DbSet<LinxRemessasRetornoTipos> LinxRemessasRetornoTipos { get; set; } = null!;
        public DbSet<LinxRespostaVenda> LinxRespostaVenda { get; set; } = null!;
        public DbSet<LinxRotinaOrigem> LinxRotinaOrigem { get; set; } = null!;
        public DbSet<LinxSangriaSuprimentos> LinxSangriaSuprimentos { get; set; } = null!;
        public DbSet<LinxSerialVenda> LinxSerialVenda { get; set; } = null!;
        public DbSet<LinxSeries> LinxSeries { get; set; } = null!;
        public DbSet<LinxServicos> LinxServicos { get; set; } = null!;
        //public DbSet<LinxServicosDetalhes> LinxServicosDetalhes { get; set; } = null!;
        public DbSet<LinxSetores> LinxSetores { get; set; } = null!;
        public DbSet<LinxSpedTipoBaseCredito> LinxSpedTipoBaseCredito { get; set; } = null!;
        public DbSet<LinxSpedTipoItem> LinxSpedTipoItem { get; set; } = null!;
        public DbSet<LinxSubClasses> LinxSubClasses { get; set; } = null!;
        public DbSet<LinxTamanhos> LinxTamanhos { get; set; } = null!;
        public DbSet<LinxTradeinParceiro> LinxTradeinParceiro { get; set; } = null!;
        public DbSet<LinxTrocaUnificadaResumoBaixa> LinxTrocaUnificadaResumoBaixa { get; set; } = null!;
        public DbSet<LinxTrocaUnificadaResumoVendas> LinxTrocaUnificadaResumoVendas { get; set; } = null!;
        public DbSet<LinxTrocaUnificadaResumoVendasItens> LinxTrocaUnificadaResumoVendasItens { get; set; } = null!;
        public DbSet<LinxUnidades> LinxUnidades { get; set; } = null!;
        public DbSet<LinxUsuarios> LinxUsuarios { get; set; } = null!;
        public DbSet<LinxValeOrdemServicoExterna> LinxValeOrdemServicoExterna { get; set; } = null!;
        public DbSet<LinxValesComprasEnviadosAPI> LinxValesComprasEnviadosAPI { get; set; } = null!;
        public DbSet<LinxVendedores> LinxVendedores { get; set; } = null!;
        public DbSet<LinxXMLDocumentos> LinxXMLDocumentos { get; set; } = null!;

        public DbSet<B2CConsultaClassificacao> B2CConsultaClassificacao { get; set; } = null!;
        public DbSet<B2CConsultaClientes> B2CConsultaClientes { get; set; } = null!;
        public DbSet<B2CConsultaClientesContatos> B2CConsultaClientesContatos { get; set; } = null!;
        public DbSet<B2CConsultaClientesContatosParentesco> B2CConsultaClientesContatosParentesco { get; set; } = null!;
        public DbSet<B2CConsultaClientesEnderecosEntrega> B2CConsultaClientesEnderecosEntrega { get; set; } = null!;
        public DbSet<B2CConsultaClientesEstadoCivil> B2CConsultaClientesEstadoCivil { get; set; } = null!;
        public DbSet<B2CConsultaClientesSaldo> B2CConsultaClientesSaldo { get; set; } = null!;
        public DbSet<B2CConsultaClientesSaldoLinx> B2CConsultaClientesSaldoLinx { get; set; } = null!;
        public DbSet<B2CConsultaCNPJsChave> B2CConsultaCNPJsChave { get; set; } = null!;
        public DbSet<B2CConsultaCodigoRastreio> B2CConsultaCodigoRastreio { get; set; } = null!;
        public DbSet<B2CConsultaColecoes> B2CConsultaColecoes { get; set; } = null!;
        public DbSet<B2CConsultaEmpresas> B2CConsultaEmpresas { get; set; } = null!;
        public DbSet<B2CConsultaEspessuras> B2CConsultaEspessuras { get; set; } = null!;
        public DbSet<B2CConsultaFlags> B2CConsultaFlags { get; set; } = null!;
        public DbSet<B2CConsultaFormasPagamento> B2CConsultaFormasPagamento { get; set; } = null!;
        public DbSet<B2CConsultaFornecedores> B2CConsultaFornecedores { get; set; } = null!;
        public DbSet<B2CConsultaGrade1> B2CConsultaGrade1 { get; set; } = null!;
        public DbSet<B2CConsultaGrade2> B2CConsultaGrade2 { get; set; } = null!;
        public DbSet<B2CConsultaImagens> B2CConsultaImagens { get; set; } = null!;
        public DbSet<B2CConsultaImagensHD> B2CConsultaImagensHD { get; set; } = null!;
        public DbSet<B2CConsultaLegendasCadastrosAuxiliares> B2CConsultaLegendasCadastrosAuxiliares { get; set; } = null!;
        public DbSet<B2CConsultaLinhas> B2CConsultaLinhas { get; set; } = null!;
        public DbSet<B2CConsultaMarcas> B2CConsultaMarcas { get; set; } = null!;
        public DbSet<B2CConsultaNFe> B2CConsultaNFe { get; set; } = null!;
        public DbSet<B2CConsultaNFeSituacao> B2CConsultaNFeSituacao { get; set; } = null!;
        public DbSet<B2CConsultaPalavrasChavePesquisa> B2CConsultaPalavrasChavePesquisa { get; set; } = null!;
        public DbSet<B2CConsultaPedidos> B2CConsultaPedidos { get; set; } = null!;
        public DbSet<B2CConsultaPedidosIdentificador> B2CConsultaPedidosIdentificador { get; set; } = null!;
        public DbSet<B2CConsultaPedidosItens> B2CConsultaPedidosItens { get; set; } = null!;
        public DbSet<B2CConsultaPedidosPlanos> B2CConsultaPedidosPlanos { get; set; } = null!;
        public DbSet<B2CConsultaPedidosStatus> B2CConsultaPedidosStatus { get; set; } = null!;
        public DbSet<B2CConsultaPedidosTipos> B2CConsultaPedidosTipos { get; set; } = null!;
        public DbSet<B2CConsultaPlanos> B2CConsultaPlanos { get; set; } = null!;
        public DbSet<B2CConsultaPlanosParcelas> B2CConsultaPlanosParcelas { get; set; } = null!;
        public DbSet<B2CConsultaProdutos> B2CConsultaProdutos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosAssociados> B2CConsultaProdutosAssociados { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCampanhas> B2CConsultaProdutosCampanhas { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCamposAdicionaisDetalhes> B2CConsultaProdutosCamposAdicionaisDetalhes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCamposAdicionaisNomes> B2CConsultaProdutosCamposAdicionaisNomes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCamposAdicionaisValores> B2CConsultaProdutosCamposAdicionaisValores { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCodebar> B2CConsultaProdutosCodebar { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCustos> B2CConsultaProdutosCustos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDepositos> B2CConsultaProdutosDepositos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDetalhes> B2CConsultaProdutosDetalhes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDetalhesDepositos> B2CConsultaProdutosDetalhesDepositos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDimensoes> B2CConsultaProdutosDimensoes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosFlags> B2CConsultaProdutosFlags { get; set; } = null!;
        public DbSet<B2CConsultaProdutosImagens> B2CConsultaProdutosImagens { get; set; } = null!;
        public DbSet<B2CConsultaProdutosInformacoes> B2CConsultaProdutosInformacoes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosPalavrasChavePesquisa> B2CConsultaProdutosPalavrasChavePesquisa { get; set; } = null!;
        public DbSet<B2CConsultaProdutosPromocao> B2CConsultaProdutosPromocao { get; set; } = null!;
        public DbSet<B2CConsultaProdutosStatus> B2CConsultaProdutosStatus { get; set; } = null!;
        public DbSet<B2CConsultaProdutosTabelas> B2CConsultaProdutosTabelas { get; set; } = null!;
        public DbSet<B2CConsultaProdutosTabelasPrecos> B2CConsultaProdutosTabelasPrecos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosTags> B2CConsultaProdutosTags { get; set; } = null!;
        public DbSet<B2CConsultaSetores> B2CConsultaSetores { get; set; } = null!;
        public DbSet<B2CConsultaStatus> B2CConsultaStatus { get; set; } = null!;
        public DbSet<B2CConsultaTags> B2CConsultaTags { get; set; } = null!;
        public DbSet<B2CConsultaTipoEncomenda> B2CConsultaTipoEncomenda { get; set; } = null!;
        public DbSet<B2CConsultaTiposCobrancaFrete> B2CConsultaTiposCobrancaFrete { get; set; } = null!;
        public DbSet<B2CConsultaTransportadores> B2CConsultaTransportadores { get; set; } = null!;
        public DbSet<B2CConsultaUnidade> B2CConsultaUnidade { get; set; } = null!;
        public DbSet<B2CConsultaVendedores> B2CConsultaVendedores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var linxMicrovixMethods = _configuration
                .GetSection("LinxMicrovix:Methods")
                .Get<List<LinxMethods>>() ?? new List<LinxMethods>();

            var b2cLinxMicrovixMethods = _configuration
                .GetSection("B2CLinxMicrovix:Methods")
                .Get<List<LinxMethods>>() ?? new List<LinxMethods>();

            entitiesToIgnore.AddRange(linxMicrovixMethods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix.{x.MethodName}"));

            entitiesToIgnore.AddRange(b2cLinxMicrovixMethods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce.{x.MethodName}"));

            var configTypes = typeof(LinxMicrovixOutboundTreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                if (config.EntityType.Namespace?.Contains("Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce") == true)
                    SchemaContext.RegisterSchema(config.EntityType, "linx_microvix_commerce");

                if (config.EntityType.Namespace?.Contains("Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix") == true)
                    SchemaContext.RegisterSchema(config.EntityType, "linx_microvix_erp");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.LinxMicrovix.Outbound.WebService", entitiesToIgnore);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var schema = String.Empty;
                var clrType = entityType.ClrType;

                if (clrType.Namespace?.Contains("Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce") == true)
                    schema = "linx_microvix_commerce";

                if (clrType.Namespace?.Contains("Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix") == true)
                    schema = "linx_microvix_erp";

                entityType.SetSchema(schema);
            }
        }
    }

    public partial class LinxMicrovixOutboundUntreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LinxMicrovixOutboundUntreatedDbContext(DbContextOptions<LinxMicrovixOutboundUntreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        public DbSet<LinxAcoesPromocionais> LinxAcoesPromocionais { get; set; } = null!;
        public DbSet<LinxAcoesPromocionaisCombinacaoProdutosItens> LinxAcoesPromocionaisCombinacaoProdutosItens { get; set; } = null!;
        public DbSet<LinxAcoesPromocionaisProdutosCortesia> LinxAcoesPromocionaisProdutosCortesia { get; set; } = null!;
        public DbSet<LinxAntecipacoesFinanceiras> LinxAntecipacoesFinanceiras { get; set; } = null!;
        public DbSet<LinxAntecipacoesFinanceirasPlanos> LinxAntecipacoesFinanceirasPlanos { get; set; } = null!;
        public DbSet<LinxB2CPedidos> LinxB2CPedidos { get; set; } = null!;
        public DbSet<LinxB2CPedidosItens> LinxB2CPedidosItens { get; set; } = null!;
        public DbSet<LinxB2CPedidosStatus> LinxB2CPedidosStatus { get; set; } = null!;
        public DbSet<LinxB2CStatus> LinxB2CStatus { get; set; } = null!;
        public DbSet<LinxCategoriasFinanceiras> LinxCategoriasFinanceiras { get; set; } = null!;
        public DbSet<LinxCentroCusto> LinxCentroCusto { get; set; } = null!;
        public DbSet<LinxCest> LinxCest { get; set; } = null!;
        public DbSet<LinxCfopFiscal> LinxCfopFiscal { get; set; } = null!;
        public DbSet<LinxClasseFiscal> LinxClasseFiscal { get; set; } = null!;
        public DbSet<LinxClassificacoes> LinxClassificacoes { get; set; } = null!;
        public DbSet<LinxClientesEnderecosEntrega> LinxClientesEnderecosEntrega { get; set; } = null!;
        public DbSet<LinxClientesFornec> LinxClientesFornec { get; set; } = null!;
        public DbSet<LinxClientesFornecCamposAdicionais> LinxClientesFornecCamposAdicionais { get; set; } = null!;
        public DbSet<LinxClientesFornecClasses> LinxClientesFornecClasses { get; set; } = null!;
        public DbSet<LinxClientesFornecContatos> LinxClientesFornecContatos { get; set; } = null!;
        public DbSet<LinxClientesFornecContatosParentesco> LinxClientesFornecContatosParentesco { get; set; } = null!;
        public DbSet<LinxClientesFornecCreditoAvulso> LinxClientesFornecCreditoAvulso { get; set; } = null!;
        public DbSet<LinxClientesRede> LinxClientesRede { get; set; } = null!;
        public DbSet<LinxColecoes> LinxColecoes { get; set; } = null!;
        public DbSet<LinxComissoesVendedores> LinxComissoesVendedores { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributarias> LinxConfiguracoesTributarias { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributariasDetalhes> LinxConfiguracoesTributariasDetalhes { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributariasDetalhesSimplificado> LinxConfiguracoesTributariasDetalhesSimplificado { get; set; } = null!;
        public DbSet<LinxConfiguracoesTributariasEmpresas> LinxConfiguracoesTributariasEmpresas { get; set; } = null!;
        public DbSet<LinxCores> LinxCores { get; set; } = null!;
        public DbSet<LinxCsosnFiscal> LinxCsosnFiscal { get; set; } = null!;
        public DbSet<LinxCstCofinsFiscal> LinxCstCofinsFiscal { get; set; } = null!;
        public DbSet<LinxCstIcmsFiscal> LinxCstIcmsFiscal { get; set; } = null!;
        public DbSet<LinxCstIpiFiscal> LinxCstIpiFiscal { get; set; } = null!;
        public DbSet<LinxCstPisFiscal> LinxCstPisFiscal { get; set; } = null!;
        public DbSet<LinxCupomDesconto> LinxCupomDesconto { get; set; } = null!;
        public DbSet<LinxCupomDescontoVendas> LinxCupomDescontoVendas { get; set; } = null!;
        public DbSet<LinxDadosOpticosDav> LinxDadosOpticosDav { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabrica> LinxDevolucaoRemanejoFabrica { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabricaItem> LinxDevolucaoRemanejoFabricaItem { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabricaStatus> LinxDevolucaoRemanejoFabricaStatus { get; set; } = null!;
        public DbSet<LinxDevolucaoRemanejoFabricaTipo> LinxDevolucaoRemanejoFabricaTipo { get; set; } = null!;
        public DbSet<LinxECF> LinxECF { get; set; } = null!;
        public DbSet<LinxECFFormasPagamento> LinxECFFormasPagamento { get; set; } = null!;
        public DbSet<LinxEnquadramentoIpi> LinxEnquadramentoIpi { get; set; } = null!;
        public DbSet<LinxEspessuras> LinxEspessuras { get; set; } = null!;
        public DbSet<LinxFaturas> LinxFaturas { get; set; } = null!;
        public DbSet<LinxFaturasOrigem> LinxFaturasOrigem { get; set; } = null!;
        public DbSet<LinxFechamentoCaixa> LinxFechamentoCaixa { get; set; } = null!;
        public DbSet<LinxFidelidade> LinxFidelidade { get; set; } = null!;
        public DbSet<LinxGrupoLojas> LinxGrupoLojas { get; set; } = null!;
        public DbSet<LinxLancContabil> LinxLancContabil { get; set; } = null!;
        public DbSet<LinxLinhas> LinxLinhas { get; set; } = null!;
        public DbSet<LinxListaDaVez> LinxListaDaVez { get; set; } = null!;
        public DbSet<LinxListagemBalanco> LinxListagemBalanco { get; set; } = null!;
        public DbSet<LinxLojas> LinxLojas { get; set; } = null!;
        public DbSet<LinxLojasParametros> LinxLojasParametros { get; set; } = null!;
        public DbSet<LinxLotesProdutos> LinxLotesProdutos { get; set; } = null!;
        public DbSet<LinxMarcas> LinxMarcas { get; set; } = null!;
        public DbSet<LinxMetasVendedores> LinxMetasVendedores { get; set; } = null!;
        public DbSet<LinxMetasVendedoresDia> LinxMetasVendedoresDia { get; set; } = null!;
        public DbSet<LinxMetodos> LinxMetodos { get; set; } = null!;
        public DbSet<LinxMotivoDesconto> LinxMotivoDesconto { get; set; } = null!;
        public DbSet<LinxMotivoDevolucao> LinxMotivoDevolucao { get; set; } = null!;
        public DbSet<LinxMotivosDesoneracaoIcms> LinxMotivosDesoneracaoIcms { get; set; } = null!;
        public DbSet<LinxMovimento> LinxMovimento { get; set; } = null!;
        public DbSet<LinxMovimentoAcoesPromocionais> LinxMovimentoAcoesPromocionais { get; set; } = null!;
        public DbSet<LinxMovimentoCamposAdicionais> LinxMovimentoCamposAdicionais { get; set; } = null!;
        public DbSet<LinxMovimentoCartoes> LinxMovimentoCartoes { get; set; } = null!;
        public DbSet<LinxMovimentoDevolucoesItens> LinxMovimentoDevolucoesItens { get; set; } = null!;
        public DbSet<LinxMovimentoExtensao> LinxMovimentoExtensao { get; set; } = null!;
        public DbSet<LinxMovimentoGiftCard> LinxMovimentoGiftCard { get; set; } = null!;
        public DbSet<LinxMovimentoIndicacoes> LinxMovimentoIndicacoes { get; set; } = null!;
        public DbSet<LinxMovimentoObservacaoCF> LinxMovimentoObservacaoCF { get; set; } = null!;
        public DbSet<LinxMovimentoObservacoes> LinxMovimentoObservacoes { get; set; } = null!;
        public DbSet<LinxMovimentoOrdemServicoExterna> LinxMovimentoOrdemServicoExterna { get; set; } = null!;
        public DbSet<LinxMovimentoOrigemDevolucoes> LinxMovimentoOrigemDevolucoes { get; set; } = null!;
        public DbSet<LinxMovimentoPlanos> LinxMovimentoPlanos { get; set; } = null!;
        public DbSet<LinxMovimentoPrincipal> LinxMovimentoPrincipal { get; set; } = null!;
        public DbSet<LinxMovimentoRemessas> LinxMovimentoRemessas { get; set; } = null!;
        public DbSet<LinxMovimentoRemessasAcertos> LinxMovimentoRemessasAcertos { get; set; } = null!;
        public DbSet<LinxMovimentoRemessasAcertosItens> LinxMovimentoRemessasAcertosItens { get; set; } = null!;
        public DbSet<LinxMovimentoRemessasItens> LinxMovimentoRemessasItens { get; set; } = null!;
        public DbSet<LinxMovimentoReshop> LinxMovimentoReshop { get; set; } = null!;
        public DbSet<LinxMovimentoReshopItens> LinxMovimentoReshopItens { get; set; } = null!;
        public DbSet<LinxMovimentoSerial> LinxMovimentoSerial { get; set; } = null!;
        public DbSet<LinxMovimentoTrocafone> LinxMovimentoTrocafone { get; set; } = null!;
        public DbSet<LinxMovimentoTrocas> LinxMovimentoTrocas { get; set; } = null!;
        public DbSet<LinxMovimentoVendaConjugada> LinxMovimentoVendaConjugada { get; set; } = null!;
        public DbSet<LinxNaturezaOperacao> LinxNaturezaOperacao { get; set; } = null!;
        public DbSet<LinxNcm> LinxNcm { get; set; } = null!;
        public DbSet<LinxNfceEstacao> LinxNfceEstacao { get; set; } = null!;
        public DbSet<LinxNFeEvento> LinxNFeEvento { get; set; } = null!;
        public DbSet<LinxNfse> LinxNfse { get; set; } = null!;
        public DbSet<LinxOrcamentoComponenteFormula> LinxOrcamentoComponenteFormula { get; set; } = null!;
        public DbSet<LinxOrdemServicoExternaDav> LinxOrdemServicoExternaDav { get; set; } = null!;
        public DbSet<LinxOrdensServico> LinxOrdensServico { get; set; } = null!;
        public DbSet<LinxOrdensServicoPosicaoOsRamoOpticoHistorico> LinxOrdensServicoPosicaoOsRamoOpticoHistorico { get; set; } = null!;
        public DbSet<LinxOrdensServicoProdutos> LinxOrdensServicoProdutos { get; set; } = null!;
        public DbSet<LinxOticoPrismaDescricao> LinxOticoPrismaDescricao { get; set; } = null!;
        public DbSet<LinxOticoReceitas> LinxOticoReceitas { get; set; } = null!;
        public DbSet<LinxPagamentoParcialDav> LinxPagamentoParcialDav { get; set; } = null!;
        public DbSet<LinxPedidosCompra> LinxPedidosCompra { get; set; } = null!;
        public DbSet<LinxPedidosVenda> LinxPedidosVenda { get; set; } = null!;
        public DbSet<LinxPedidosVendaChecklistEntregaArmazenamento> LinxPedidosVendaChecklistEntregaArmazenamento { get; set; } = null!;
        public DbSet<LinxPedidosVendaChecklistEntregaDificuldade> LinxPedidosVendaChecklistEntregaDificuldade { get; set; } = null!;
        public DbSet<LinxPedidosVendaChecklistEntregaLocal> LinxPedidosVendaChecklistEntregaLocal { get; set; } = null!;
        public DbSet<LinxPerguntaVenda> LinxPerguntaVenda { get; set; } = null!;
        public DbSet<LinxPlanoContas> LinxPlanoContas { get; set; } = null!;
        public DbSet<LinxPlanos> LinxPlanos { get; set; } = null!;
        public DbSet<LinxPlanosBandeiras> LinxPlanosBandeiras { get; set; } = null!;
        public DbSet<LinxPlanosPedidoVenda> LinxPlanosPedidoVenda { get; set; } = null!;
        public DbSet<LinxPosicaoOsRamoOptico> LinxPosicaoOsRamoOptico { get; set; } = null!;
        public DbSet<LinxProdutos> LinxProdutos { get; set; } = null!;
        public DbSet<LinxProdutosAssociados> LinxProdutosAssociados { get; set; } = null!;
        public DbSet<LinxProdutosCamposAdicionais> LinxProdutosCamposAdicionais { get; set; } = null!;
        public DbSet<LinxProdutosCodBar> LinxProdutosCodBar { get; set; } = null!;
        public DbSet<LinxProdutosDepositos> LinxProdutosDepositos { get; set; } = null!;
        public DbSet<LinxProdutosDetalhes> LinxProdutosDetalhes { get; set; } = null!;
        public DbSet<LinxProdutosDetalhesDepositos> LinxProdutosDetalhesDepositos { get; set; } = null!;
        public DbSet<LinxProdutosDetalhesSimplificado> LinxProdutosDetalhesSimplificado { get; set; } = null!;
        public DbSet<LinxProdutosFornec> LinxProdutosFornec { get; set; } = null!;
        public DbSet<LinxProdutosInformacoes> LinxProdutosInformacoes { get; set; } = null!;
        public DbSet<LinxProdutosInventario> LinxProdutosInventario { get; set; } = null!;
        public DbSet<LinxProdutosLotes> LinxProdutosLotes { get; set; } = null!;
        public DbSet<LinxProdutosOpticosFormatoAro> LinxProdutosOpticosFormatoAro { get; set; } = null!;
        public DbSet<LinxProdutosOpticosTipo> LinxProdutosOpticosTipo { get; set; } = null!;
        public DbSet<LinxProdutosOpticosTipoAro> LinxProdutosOpticosTipoAro { get; set; } = null!;
        public DbSet<LinxProdutosPromocoes> LinxProdutosPromocoes { get; set; } = null!;
        public DbSet<LinxProdutosSerial> LinxProdutosSerial { get; set; } = null!;
        public DbSet<LinxProdutosTabelas> LinxProdutosTabelas { get; set; } = null!;
        public DbSet<LinxProdutosTabelasPrecos> LinxProdutosTabelasPrecos { get; set; } = null!;
        public DbSet<LinxRamosAtividade> LinxRamosAtividade { get; set; } = null!;
        //public DbSet<LinxReducoesZ> LinxReducoesZ { get; set; } = null!;
        public DbSet<LinxRemessasIdentificadores> LinxRemessasIdentificadores { get; set; } = null!;
        public DbSet<LinxRemessasOperacoes> LinxRemessasOperacoes { get; set; } = null!;
        public DbSet<LinxRemessasRetornoTipos> LinxRemessasRetornoTipos { get; set; } = null!;
        public DbSet<LinxRespostaVenda> LinxRespostaVenda { get; set; } = null!;
        public DbSet<LinxRotinaOrigem> LinxRotinaOrigem { get; set; } = null!;
        public DbSet<LinxSangriaSuprimentos> LinxSangriaSuprimentos { get; set; } = null!;
        public DbSet<LinxSerialVenda> LinxSerialVenda { get; set; } = null!;
        public DbSet<LinxSeries> LinxSeries { get; set; } = null!;
        public DbSet<LinxServicos> LinxServicos { get; set; } = null!;
        //public DbSet<LinxServicosDetalhes> LinxServicosDetalhes { get; set; } = null!;
        public DbSet<LinxSetores> LinxSetores { get; set; } = null!;
        public DbSet<LinxSpedTipoBaseCredito> LinxSpedTipoBaseCredito { get; set; } = null!;
        public DbSet<LinxSpedTipoItem> LinxSpedTipoItem { get; set; } = null!;
        public DbSet<LinxSubClasses> LinxSubClasses { get; set; } = null!;
        public DbSet<LinxTamanhos> LinxTamanhos { get; set; } = null!;
        public DbSet<LinxTradeinParceiro> LinxTradeinParceiro { get; set; } = null!;
        public DbSet<LinxTrocaUnificadaResumoBaixa> LinxTrocaUnificadaResumoBaixa { get; set; } = null!;
        public DbSet<LinxTrocaUnificadaResumoVendas> LinxTrocaUnificadaResumoVendas { get; set; } = null!;
        public DbSet<LinxTrocaUnificadaResumoVendasItens> LinxTrocaUnificadaResumoVendasItens { get; set; } = null!;
        public DbSet<LinxUnidades> LinxUnidades { get; set; } = null!;
        public DbSet<LinxUsuarios> LinxUsuarios { get; set; } = null!;
        public DbSet<LinxValeOrdemServicoExterna> LinxValeOrdemServicoExterna { get; set; } = null!;
        public DbSet<LinxValesComprasEnviadosAPI> LinxValesComprasEnviadosAPI { get; set; } = null!;
        public DbSet<LinxVendedores> LinxVendedores { get; set; } = null!;
        public DbSet<LinxXMLDocumentos> LinxXMLDocumentos { get; set; } = null!;

        public DbSet<B2CConsultaClassificacao> B2CConsultaClassificacao { get; set; } = null!;
        public DbSet<B2CConsultaClientes> B2CConsultaClientes { get; set; } = null!;
        public DbSet<B2CConsultaClientesContatos> B2CConsultaClientesContatos { get; set; } = null!;
        public DbSet<B2CConsultaClientesContatosParentesco> B2CConsultaClientesContatosParentesco { get; set; } = null!;
        public DbSet<B2CConsultaClientesEnderecosEntrega> B2CConsultaClientesEnderecosEntrega { get; set; } = null!;
        public DbSet<B2CConsultaClientesEstadoCivil> B2CConsultaClientesEstadoCivil { get; set; } = null!;
        public DbSet<B2CConsultaClientesSaldo> B2CConsultaClientesSaldo { get; set; } = null!;
        public DbSet<B2CConsultaClientesSaldoLinx> B2CConsultaClientesSaldoLinx { get; set; } = null!;
        public DbSet<B2CConsultaCNPJsChave> B2CConsultaCNPJsChave { get; set; } = null!;
        public DbSet<B2CConsultaCodigoRastreio> B2CConsultaCodigoRastreio { get; set; } = null!;
        public DbSet<B2CConsultaColecoes> B2CConsultaColecoes { get; set; } = null!;
        public DbSet<B2CConsultaEmpresas> B2CConsultaEmpresas { get; set; } = null!;
        public DbSet<B2CConsultaEspessuras> B2CConsultaEspessuras { get; set; } = null!;
        public DbSet<B2CConsultaFlags> B2CConsultaFlags { get; set; } = null!;
        public DbSet<B2CConsultaFormasPagamento> B2CConsultaFormasPagamento { get; set; } = null!;
        public DbSet<B2CConsultaFornecedores> B2CConsultaFornecedores { get; set; } = null!;
        public DbSet<B2CConsultaGrade1> B2CConsultaGrade1 { get; set; } = null!;
        public DbSet<B2CConsultaGrade2> B2CConsultaGrade2 { get; set; } = null!;
        public DbSet<B2CConsultaImagens> B2CConsultaImagens { get; set; } = null!;
        public DbSet<B2CConsultaImagensHD> B2CConsultaImagensHD { get; set; } = null!;
        public DbSet<B2CConsultaLegendasCadastrosAuxiliares> B2CConsultaLegendasCadastrosAuxiliares { get; set; } = null!;
        public DbSet<B2CConsultaLinhas> B2CConsultaLinhas { get; set; } = null!;
        public DbSet<B2CConsultaMarcas> B2CConsultaMarcas { get; set; } = null!;
        public DbSet<B2CConsultaNFe> B2CConsultaNFe { get; set; } = null!;
        public DbSet<B2CConsultaNFeSituacao> B2CConsultaNFeSituacao { get; set; } = null!;
        public DbSet<B2CConsultaPalavrasChavePesquisa> B2CConsultaPalavrasChavePesquisa { get; set; } = null!;
        public DbSet<B2CConsultaPedidos> B2CConsultaPedidos { get; set; } = null!;
        public DbSet<B2CConsultaPedidosIdentificador> B2CConsultaPedidosIdentificador { get; set; } = null!;
        public DbSet<B2CConsultaPedidosItens> B2CConsultaPedidosItens { get; set; } = null!;
        public DbSet<B2CConsultaPedidosPlanos> B2CConsultaPedidosPlanos { get; set; } = null!;
        public DbSet<B2CConsultaPedidosStatus> B2CConsultaPedidosStatus { get; set; } = null!;
        public DbSet<B2CConsultaPedidosTipos> B2CConsultaPedidosTipos { get; set; } = null!;
        public DbSet<B2CConsultaPlanos> B2CConsultaPlanos { get; set; } = null!;
        public DbSet<B2CConsultaPlanosParcelas> B2CConsultaPlanosParcelas { get; set; } = null!;
        public DbSet<B2CConsultaProdutos> B2CConsultaProdutos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosAssociados> B2CConsultaProdutosAssociados { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCampanhas> B2CConsultaProdutosCampanhas { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCamposAdicionaisDetalhes> B2CConsultaProdutosCamposAdicionaisDetalhes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCamposAdicionaisNomes> B2CConsultaProdutosCamposAdicionaisNomes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCamposAdicionaisValores> B2CConsultaProdutosCamposAdicionaisValores { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCodebar> B2CConsultaProdutosCodebar { get; set; } = null!;
        public DbSet<B2CConsultaProdutosCustos> B2CConsultaProdutosCustos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDepositos> B2CConsultaProdutosDepositos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDetalhes> B2CConsultaProdutosDetalhes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDetalhesDepositos> B2CConsultaProdutosDetalhesDepositos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosDimensoes> B2CConsultaProdutosDimensoes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosFlags> B2CConsultaProdutosFlags { get; set; } = null!;
        public DbSet<B2CConsultaProdutosImagens> B2CConsultaProdutosImagens { get; set; } = null!;
        public DbSet<B2CConsultaProdutosInformacoes> B2CConsultaProdutosInformacoes { get; set; } = null!;
        public DbSet<B2CConsultaProdutosPalavrasChavePesquisa> B2CConsultaProdutosPalavrasChavePesquisa { get; set; } = null!;
        public DbSet<B2CConsultaProdutosPromocao> B2CConsultaProdutosPromocao { get; set; } = null!;
        public DbSet<B2CConsultaProdutosStatus> B2CConsultaProdutosStatus { get; set; } = null!;
        public DbSet<B2CConsultaProdutosTabelas> B2CConsultaProdutosTabelas { get; set; } = null!;
        public DbSet<B2CConsultaProdutosTabelasPrecos> B2CConsultaProdutosTabelasPrecos { get; set; } = null!;
        public DbSet<B2CConsultaProdutosTags> B2CConsultaProdutosTags { get; set; } = null!;
        public DbSet<B2CConsultaSetores> B2CConsultaSetores { get; set; } = null!;
        public DbSet<B2CConsultaStatus> B2CConsultaStatus { get; set; } = null!;
        public DbSet<B2CConsultaTags> B2CConsultaTags { get; set; } = null!;
        public DbSet<B2CConsultaTipoEncomenda> B2CConsultaTipoEncomenda { get; set; } = null!;
        public DbSet<B2CConsultaTiposCobrancaFrete> B2CConsultaTiposCobrancaFrete { get; set; } = null!;
        public DbSet<B2CConsultaTransportadores> B2CConsultaTransportadores { get; set; } = null!;
        public DbSet<B2CConsultaUnidade> B2CConsultaUnidade { get; set; } = null!;
        public DbSet<B2CConsultaVendedores> B2CConsultaVendedores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var linxMicrovixMethods = _configuration
                .GetSection("LinxMicrovix:Methods")
                .Get<List<LinxMethods>>() ?? new List<LinxMethods>();

            var b2cLinxMicrovixMethods = _configuration
                .GetSection("B2CLinxMicrovix:Methods")
                .Get<List<LinxMethods>>() ?? new List<LinxMethods>();

            entitiesToIgnore.AddRange(linxMicrovixMethods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix.{x.MethodName}"));

            entitiesToIgnore.AddRange(b2cLinxMicrovixMethods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce.{x.MethodName}"));

            var configTypes = typeof(LinxMicrovixOutboundTreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "untreated");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.LinxMicrovix.Outbound.WebService.DependencyInjection.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.LinxMicrovix.Outbound.WebService", entitiesToIgnore);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var schema = String.Empty;
                var clrType = entityType.ClrType;

                schema = "untreated";

                entityType.SetSchema(schema);
            }
        }
    }
}