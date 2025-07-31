namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaPedidosPlanos
    {
        public string? id_pedido_planos { get; set; }
        public string? id_pedido { get; set; }
        public string? plano_pagamento { get; set; }
        public string? valor_plano { get; set; }
        public string? nsu_sitef { get; set; }
        public string? cod_autorizacao { get; set; }
        public string? texto_comprovante { get; set; }
        public string? cod_loja_sitef { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
