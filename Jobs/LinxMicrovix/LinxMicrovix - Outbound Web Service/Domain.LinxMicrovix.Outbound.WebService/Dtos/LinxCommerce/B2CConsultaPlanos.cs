namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaPlanos
    {
        public string? plano { get; private set; }
        public string? nome_plano { get; private set; }
        public string? forma_pagamento { get; private set; }
        public string? qtde_parcelas { get; private set; }
        public string? valor_minimo_parcela { get; private set; }
        public string? indice { get; private set; }
        public string? timestamp { get; private set; }
        public string? desativado { get; private set; }
        public string? tipo_plano { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaPlanos() { }

        public B2CConsultaPlanos(
            string? plano,
            string? nome_plano,
            string? forma_pagamento,
            string? qtde_parcelas,
            string? valor_minimo_parcela,
            string? indice,
            string? timestamp,
            string? desativado,
            string? tipo_plano,
            string? portal
        )
        {
            this.plano = plano;
            this.nome_plano = nome_plano;
            this.forma_pagamento = forma_pagamento;
            this.qtde_parcelas = qtde_parcelas;
            this.valor_minimo_parcela = valor_minimo_parcela;
            this.indice = indice;
            this.timestamp = timestamp;
            this.desativado = desativado;
            this.tipo_plano = tipo_plano;
            this.portal = portal;
        }
    }
}