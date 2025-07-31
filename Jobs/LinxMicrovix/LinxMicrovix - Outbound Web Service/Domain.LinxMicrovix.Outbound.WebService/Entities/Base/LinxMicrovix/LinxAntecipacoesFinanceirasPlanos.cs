namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxAntecipacoesFinanceirasPlanos
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
    }
}
