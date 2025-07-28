namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAntecipacoesFinanceiras
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? empresa { get; set; }
        public string? cod_cliente { get; set; }
        public string? numero_antecipacao { get; set; }
        public string? data_antecipacao { get; set; }
        public string? previsao_entrega { get; set; }
        public string? dav_pv { get; set; }
        public string? numero_origem { get; set; }
        public string? dav_remessa { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? preco_unitario_produto { get; set; }
        public string? valor_pago_antecipacao { get; set; }
        public string? entregue { get; set; }
        public string? identificador { get; set; }
        public string? timestamp { get; set; }
        public string? cancelado { get; set; }
        public string? id_antecipacoes_financeiras { get; set; }
        public string? id_antecipacoes_financeiras_detalhes { get; set; }
        public string? id_vendas_pos_produtos { get; set; }

        public LinxAntecipacoesFinanceiras()
        {
        }

        public LinxAntecipacoesFinanceiras(string? portal, string? cnpj_emp, string? empresa, string? cod_cliente, string? numero_antecipacao, string? data_antecipacao, string? previsao_entrega, string? dav_pv, string? numero_origem, string? dav_remessa, string? codigoproduto, string? quantidade, string? preco_unitario_produto, string? valor_pago_antecipacao, string? entregue, string? identificador, string? timestamp, string? cancelado, string? id_antecipacoes_financeiras, string? id_antecipacoes_financeiras_detalhes, string? id_vendas_pos_produtos)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.empresa = empresa;
            this.cod_cliente = cod_cliente;
            this.numero_antecipacao = numero_antecipacao;
            this.data_antecipacao = data_antecipacao;
            this.previsao_entrega = previsao_entrega;
            this.dav_pv = dav_pv;
            this.numero_origem = numero_origem;
            this.dav_remessa = dav_remessa;
            this.codigoproduto = codigoproduto;
            this.quantidade = quantidade;
            this.preco_unitario_produto = preco_unitario_produto;
            this.valor_pago_antecipacao = valor_pago_antecipacao;
            this.entregue = entregue;
            this.identificador = identificador;
            this.timestamp = timestamp;
            this.cancelado = cancelado;
            this.id_antecipacoes_financeiras = id_antecipacoes_financeiras;
            this.id_antecipacoes_financeiras_detalhes = id_antecipacoes_financeiras_detalhes;
            this.id_vendas_pos_produtos = id_vendas_pos_produtos;
        }
    }
}
