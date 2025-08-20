namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxPagamentoParcialDav
    {
        public string? id_pagamento_parcial_tmp { get; set; }
        public string? id_vendas_pos { get; set; }
        public string? valor { get; set; }
        public string? ajuste_valor_desc_acresc_plano { get; set; }
        public string? timestamp { get; set; }
        public string? plano { get; set; }
        public string? forma_pgto { get; set; }
        public string? id_bandeira { get; set; }
        public string? qtde_parcelas { get; set; }
        public string? credito_debito { get; set; }
        public string? portal { get; set; }
    }
}
