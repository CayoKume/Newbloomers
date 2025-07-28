namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxAcoesPromocionais
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_acoes_promocionais { get; set; }
        public string? descricao { get; set; }
        public string? vigencia_inicio { get; set; }
        public string? vigencia_fim { get; set; }
        public string? observacao { get; set; }
        public string? ativa { get; set; }
        public string? excluida { get; set; }
        public string? integrada { get; set; }
        public string? qtde_integrada { get; set; }
        public string? valor_pago_franqueadora { get; set; }
    }
}
