namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasPlanos
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_antecipacoes_financeiras { get; set; }
        public string? numero_antecipacao { get; set; }
        public string? forma_pgto { get; set; }
        public string? plano { get; set; }
        public string? nome_plano { get; set; }
        public string? valor { get; set; }
        public string? timestamp { get; set; }
        public string? id_ordservprod { get; set; }
        public string? id_vendas_pos_produtos_tmp { get; set; }
        public string? id_vendas_pos { get; set; }
        public string? cancelado { get; set; }
        public string? previsao_entrega { get; set; }
        public string? numero_ficha { get; set; }
        public string? id_vendas_pos_produtos_campos_adicionais_tmp { get; set; }
        public string? id_link_pagamento_linx_pay_hub { get; set; }
        public string? codigo_gerencial { get; set; }
        public string? empresa { get; set; }

        public LinxAntecipacoesFinanceirasPlanos()
        {
        }

        public LinxAntecipacoesFinanceirasPlanos(string? portal, string? cnpj_emp, string? id_antecipacoes_financeiras, string? numero_antecipacao, string? forma_pgto, string? plano, string? nome_plano, string? valor, string? timestamp, string? id_ordservprod, string? id_vendas_pos_produtos_tmp, string? id_vendas_pos, string? cancelado, string? previsao_entrega, string? numero_ficha, string? id_vendas_pos_produtos_campos_adicionais_tmp, string? id_link_pagamento_linx_pay_hub, string? codigo_gerencial, string? empresa)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_antecipacoes_financeiras = id_antecipacoes_financeiras;
            this.numero_antecipacao = numero_antecipacao;
            this.forma_pgto = forma_pgto;
            this.plano = plano;
            this.nome_plano = nome_plano;
            this.valor = valor;
            this.timestamp = timestamp;
            this.id_ordservprod = id_ordservprod;
            this.id_vendas_pos_produtos_tmp = id_vendas_pos_produtos_tmp;
            this.id_vendas_pos = id_vendas_pos;
            this.cancelado = cancelado;
            this.previsao_entrega = previsao_entrega;
            this.numero_ficha = numero_ficha;
            this.id_vendas_pos_produtos_campos_adicionais_tmp = id_vendas_pos_produtos_campos_adicionais_tmp;
            this.id_link_pagamento_linx_pay_hub = id_link_pagamento_linx_pay_hub;
            this.codigo_gerencial = codigo_gerencial;
            this.empresa = empresa;
        }
    }
}
