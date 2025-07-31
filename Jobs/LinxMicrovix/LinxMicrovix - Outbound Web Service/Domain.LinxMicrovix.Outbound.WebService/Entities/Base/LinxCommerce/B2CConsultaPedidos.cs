namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaPedidos
    {
        public string? id_pedido { get; set; }
        public string? dt_pedido { get; set; }
        public string? cod_cliente_erp { get; set; }
        public string? cod_cliente_b2c { get; set; }
        public string? vl_frete { get; set; }
        public string? forma_pgto { get; set; }
        public string? plano_pagamento { get; set; }
        public string? anotacao { get; set; }
        public string? taxa_impressao { get; set; }
        public string? finalizado { get; set; }
        public string? valor_frete_gratis { get; set; }
        public string? tipo_frete { get; set; }
        public string? id_status { get; set; }
        public string? cod_transportador { get; set; }
        public string? tipo_cobranca_frete { get; set; }
        public string? ativo { get; set; }
        public string? empresa { get; set; }
        public string? id_tabela_preco { get; set; }
        public string? valor_credito { get; set; }
        public string? cod_vendedor { get; set; }
        public string? timestamp { get; set; }
        public string? dt_insert { get; set; }
        public string? dt_disponivel_faturamento { get; set; }
        public string? portal { get; set; }
        public string? mensagem_falha_faturamento { get; set; }
        public string? id_tipo_b2c { get; set; }
        public string? ecommerce_origem { get; set; }
        public string? order_id { get; set; }
    }
}
