namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoRemessasAcertosItens
    {
        public string? id_remessas_acertos { get; set; }
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? transacao { get; set; }
        public string? qtde_total { get; set; }
        public string? id_remessa_operacoes { get; set; }
        public string? id_remessas_itens { get; set; }
        public string? timestamp { get; set; }
    }
}
