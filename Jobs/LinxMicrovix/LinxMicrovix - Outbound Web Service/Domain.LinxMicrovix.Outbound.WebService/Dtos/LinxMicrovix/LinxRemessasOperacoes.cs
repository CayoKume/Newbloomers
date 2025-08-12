namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxRemessasOperacoes
    {
        public string? id_remessa_operacoes { get; set; }
        public string? descricao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxRemessasOperacoes()
        {
        }

        public LinxRemessasOperacoes(
            string? id_remessa_operacoes,
            string? id_remessa,
            string? descricao,
            string? timestamp,
            string? portal)
        {
            this.id_remessa_operacoes = id_remessa_operacoes;
            this.descricao = descricao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}