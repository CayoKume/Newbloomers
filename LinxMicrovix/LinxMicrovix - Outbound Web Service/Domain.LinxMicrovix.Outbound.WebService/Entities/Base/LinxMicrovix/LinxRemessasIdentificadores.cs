namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxRemessasIdentificadores
    {
        public string? identificador_venda { get; set; }
        public string? identificador_remessa { get; set; }
        public string? id_remessas { get; set; }
        public string? id_remessas_acertos { get; set; }
        public string? transacao_acerto { get; set; }
        public string? qtde_total_acerto { get; set; }
        public string? identificador_devolucao { get; set; }
        public string? transacao_remessa { get; set; }
        public string? id_remessa_operacoes { get; set; }
    }
}
