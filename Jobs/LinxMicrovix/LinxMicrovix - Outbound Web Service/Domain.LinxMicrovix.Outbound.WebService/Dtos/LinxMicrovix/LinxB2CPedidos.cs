namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxB2CPedidos
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
        public string? mensagem_falha_faturamento { get; set; }
        public string? portal { get; set; }
        public string? id_tipo_b2c { get; set; }
        public string? ecommerce_origem { get; set; }
        public string? marketplace_loja { get; set; }
        public string? order_id { get; set; }

        public LinxB2CPedidos()
        {
        }

        public LinxB2CPedidos(string? id_pedido, string? dt_pedido, string? cod_cliente_erp, string? cod_cliente_b2c, string? vl_frete, string? forma_pgto, string? plano_pagamento, string? anotacao, string? taxa_impressao, string? finalizado, string? valor_frete_gratis, string? tipo_frete, string? id_status, string? cod_transportador, string? tipo_cobranca_frete, string? ativo, string? empresa, string? id_tabela_preco, string? valor_credito, string? cod_vendedor, string? timestamp, string? dt_insert, string? dt_disponivel_faturamento, string? mensagem_falha_faturamento, string? portal, string? id_tipo_b2c, string? ecommerce_origem, string? marketplace_loja, string? order_id)
        {
            this.id_pedido = id_pedido;
            this.dt_pedido = dt_pedido;
            this.cod_cliente_erp = cod_cliente_erp;
            this.cod_cliente_b2c = cod_cliente_b2c;
            this.vl_frete = vl_frete;
            this.forma_pgto = forma_pgto;
            this.plano_pagamento = plano_pagamento;
            this.anotacao = anotacao;
            this.taxa_impressao = taxa_impressao;
            this.finalizado = finalizado;
            this.valor_frete_gratis = valor_frete_gratis;
            this.tipo_frete = tipo_frete;
            this.id_status = id_status;
            this.cod_transportador = cod_transportador;
            this.tipo_cobranca_frete = tipo_cobranca_frete;
            this.ativo = ativo;
            this.empresa = empresa;
            this.id_tabela_preco = id_tabela_preco;
            this.valor_credito = valor_credito;
            this.cod_vendedor = cod_vendedor;
            this.timestamp = timestamp;
            this.dt_insert = dt_insert;
            this.dt_disponivel_faturamento = dt_disponivel_faturamento;
            this.mensagem_falha_faturamento = mensagem_falha_faturamento;
            this.portal = portal;
            this.id_tipo_b2c = id_tipo_b2c;
            this.ecommerce_origem = ecommerce_origem;
            this.marketplace_loja = marketplace_loja;
            this.order_id = order_id;
        }
    }
}
