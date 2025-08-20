namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoAcoesPromocionais
    {
        public string? identificador { get; set; }
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? transacao { get; set; }
        public string? id_acoes_promocionais { get; set; }
        public string? desconto_item { get; set; }
        public string? quantidade { get; set; }

        public LinxMovimentoAcoesPromocionais()
        {
        }

        public LinxMovimentoAcoesPromocionais(string? identificador, string? portal, string? cnpj_emp, string? transacao, string? id_acoes_promocionais, string? desconto_item, string? quantidade)
        {
            this.identificador = identificador;
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.transacao = transacao;
            this.id_acoes_promocionais = id_acoes_promocionais;
            this.desconto_item = desconto_item;
            this.quantidade = quantidade;
        }
    }
}
