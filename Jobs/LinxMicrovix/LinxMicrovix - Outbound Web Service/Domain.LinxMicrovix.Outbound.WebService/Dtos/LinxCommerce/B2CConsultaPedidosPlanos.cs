namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaPedidosPlanos
    {
        public string? id_pedido_planos { get; private set; }
        public string? id_pedido { get; private set; }
        public string? plano_pagamento { get; private set; }
        public string? valor_plano { get; private set; }
        public string? nsu_sitef { get; private set; }
        public string? cod_autorizacao { get; private set; }
        public string? texto_comprovante { get; private set; }
        public string? cod_loja_sitef { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaPedidosPlanos() { }

        public B2CConsultaPedidosPlanos(
            string? id_pedido_planos,
            string? id_pedido,
            string? plano_pagamento,
            string? valor_plano,
            string? nsu_sitef,
            string? cod_autorizacao,
            string? texto_comprovante,
            string? cod_loja_sitef,
            string? timestamp,
            string? portal
        )
        {
            this.id_pedido_planos = id_pedido_planos;
            this.id_pedido = id_pedido;
            this.plano_pagamento = plano_pagamento;
            this.valor_plano = valor_plano;
            this.nsu_sitef = nsu_sitef;
            this.cod_autorizacao = cod_autorizacao;
            this.texto_comprovante = texto_comprovante;
            this.cod_loja_sitef = cod_loja_sitef;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}