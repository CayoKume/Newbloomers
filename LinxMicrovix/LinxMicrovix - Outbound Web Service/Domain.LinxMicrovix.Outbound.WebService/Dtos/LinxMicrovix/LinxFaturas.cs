namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFaturas
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? codigo_fatura { get; set; }
        public string? data_emissao { get; set; }
        public string? cod_cliente { get; set; }
        public string? nome_cliente { get; set; }
        public string? data_vencimento { get; set; }
        public string? data_baixa { get; set; }
        public string? valor_fatura { get; set; }
        public string? valor_pago { get; set; }
        public string? valor_desconto { get; set; }
        public string? valor_juros { get; set; }
        public string? documento { get; set; }
        public string? serie { get; set; }
        public string? ecf { get; set; }
        public string? observacao { get; set; }
        public string? qtde_parcelas { get; set; }
        public string? ordem_parcela { get; set; }
        public string? receber_pagar { get; set; }
        public string? vendedor { get; set; }
        public string? excluido { get; set; }
        public string? cancelado { get; set; }
        public string? identificador { get; set; }
        public string? nsu { get; set; }
        public string? cod_autorizacao { get; set; }
        public string? documento_sem_tef { get; set; }
        public string? autorizacao_sem_tef { get; set; }
        public string? plano { get; set; }
        public string? conta_credito { get; set; }
        public string? conta_debito { get; set; }
        public string? conta_fluxo { get; set; }
        public string? cod_historico { get; set; }
        public string? forma_pgto { get; set; }
        public string? ordem_cartao { get; set; }
        public string? banco_codigo { get; set; }
        public string? banco_agencia { get; set; }
        public string? banco_conta { get; set; }
        public string? banco_autorizacao_garantidora { get; set; }
        public string? numero_bilhete_seguro { get; set; }
        public string? timestamp { get; set; }
        public string? empresa { get; set; }
        public string? id_categorias_financeiras { get; set; }
        public string? taxa_financeira { get; set; }
        public string? valor_abatimento { get; set; }
        public string? valor_multa { get; set; }
        public string? centrocusto { get; set; }
        public string? perc_taxa_adquirente { get; set; }
        public string? fatura_origem_importacao_erp { get; set; }

        public LinxFaturas()
        {
        }

        public LinxFaturas(string? portal, string? cnpj_emp, string? codigo_fatura, string? data_emissao, string? cod_cliente, string? nome_cliente, string? data_vencimento, string? data_baixa, string? valor_fatura, string? valor_pago, string? valor_desconto, string? valor_juros, string? documento, string? serie, string? ecf, string? observacao, string? qtde_parcelas, string? ordem_parcela, string? receber_pagar, string? vendedor, string? excluido, string? cancelado, string? identificador, string? nsu, string? cod_autorizacao, string? documento_sem_tef, string? autorizacao_sem_tef, string? plano, string? conta_credito, string? conta_debito, string? conta_fluxo, string? cod_historico, string? forma_pgto, string? ordem_cartao, string? banco_codigo, string? banco_agencia, string? banco_conta, string? banco_autorizacao_garantidora, string? numero_bilhete_seguro, string? timestamp, string? empresa, string? id_categorias_financeiras, string? taxa_financeira, string? valor_abatimento, string? valor_multa, string? centrocusto, string? perc_taxa_adquirente, string? fatura_origem_importacao_erp)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.codigo_fatura = codigo_fatura;
            this.data_emissao = data_emissao;
            this.cod_cliente = cod_cliente;
            this.nome_cliente = nome_cliente;
            this.data_vencimento = data_vencimento;
            this.data_baixa = data_baixa;
            this.valor_fatura = valor_fatura;
            this.valor_pago = valor_pago;
            this.valor_desconto = valor_desconto;
            this.valor_juros = valor_juros;
            this.documento = documento;
            this.serie = serie;
            this.ecf = ecf;
            this.observacao = observacao;
            this.qtde_parcelas = qtde_parcelas;
            this.ordem_parcela = ordem_parcela;
            this.receber_pagar = receber_pagar;
            this.vendedor = vendedor;
            this.excluido = excluido;
            this.cancelado = cancelado;
            this.identificador = identificador;
            this.nsu = nsu;
            this.cod_autorizacao = cod_autorizacao;
            this.documento_sem_tef = documento_sem_tef;
            this.autorizacao_sem_tef = autorizacao_sem_tef;
            this.plano = plano;
            this.conta_credito = conta_credito;
            this.conta_debito = conta_debito;
            this.conta_fluxo = conta_fluxo;
            this.cod_historico = cod_historico;
            this.forma_pgto = forma_pgto;
            this.ordem_cartao = ordem_cartao;
            this.banco_codigo = banco_codigo;
            this.banco_agencia = banco_agencia;
            this.banco_conta = banco_conta;
            this.banco_autorizacao_garantidora = banco_autorizacao_garantidora;
            this.numero_bilhete_seguro = numero_bilhete_seguro;
            this.timestamp = timestamp;
            this.empresa = empresa;
            this.id_categorias_financeiras = id_categorias_financeiras;
            this.taxa_financeira = taxa_financeira;
            this.valor_abatimento = valor_abatimento;
            this.valor_multa = valor_multa;
            this.centrocusto = centrocusto;
            this.perc_taxa_adquirente = perc_taxa_adquirente;
            this.fatura_origem_importacao_erp = fatura_origem_importacao_erp;
        }
    }
}
