

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPagamentoParcialDav
    {
        public string? id_pagamento_parcial_tmp { get; private set; }
        public string? id_vendas_pos { get; private set; }
        public string? valor { get; private set; }
        public string? ajuste_valor_desc_acresc_plano { get; private set; }
        public string? timestamp { get; private set; }
        public string? plano { get; private set; }
        public string? forma_pgto { get; private set; }
        public string? id_bandeira { get; private set; }
        public string? qtde_parcelas { get; private set; }
        public string? credito_debito { get; private set; }
        public string? portal { get; private set; }

        public LinxPagamentoParcialDav() { }

        public LinxPagamentoParcialDav(
            string? id_pagamento_parcial_tmp,
            string? id_vendas_pos,
            string? valor,
            string? ajuste_valor_desc_acresc_plano,
            string? timestamp,
            string? plano,
            string? forma_pgto,
            string? id_bandeira,
            string? qtde_parcelas,
            string? credito_debito,
            string? portal
        )
        {
            this.id_pagamento_parcial_tmp = id_pagamento_parcial_tmp;
            this.id_vendas_pos = id_vendas_pos;
            this.valor = valor;
            this.ajuste_valor_desc_acresc_plano = ajuste_valor_desc_acresc_plano;
            this.timestamp = timestamp;
            this.plano = plano;
            this.forma_pgto = forma_pgto;
            this.id_bandeira = id_bandeira;
            this.qtde_parcelas = qtde_parcelas;
            this.credito_debito = credito_debito;
            this.portal = portal;
        }
    }
}