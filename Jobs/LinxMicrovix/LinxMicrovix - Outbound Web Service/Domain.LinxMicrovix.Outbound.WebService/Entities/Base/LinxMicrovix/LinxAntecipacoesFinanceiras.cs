namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxAntecipacoesFinanceiras
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
    }
}
