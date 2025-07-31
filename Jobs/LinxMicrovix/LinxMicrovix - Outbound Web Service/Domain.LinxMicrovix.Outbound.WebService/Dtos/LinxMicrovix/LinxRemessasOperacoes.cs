namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxRemessasOperacoes
    {
        public string? id_remessa_operacao { get; set; }
        public string? descricao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxRemessasOperacoes()
        {
        }

        public LinxRemessasOperacoes(
            string? id_remessa_operacao,
            string? id_remessa,
            string? descricao,
            string? timestamp,
            string? portal)
        {
            this.id_remessa_operacao = id_remessa_operacao;
            this.descricao = descricao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}