namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoAcoesPromocionais
    {
        public string? identificador { get; set; }
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? transacao { get; set; }
        public string? id_acoes_promocionais { get; set; }
        public string? desconto_item { get; set; }
        public string? quantidade { get; set; }
    }
}
