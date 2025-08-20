namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxRamosAtividade
    {
        public string? id_ramo_atividade { get; set; }
        public string? nome_ramo_atividade { get; set; }
        public string? codigo_ramo_atividade { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxRamosAtividade() { }

        public LinxRamosAtividade(
            string? id_ramo_atividade,
            string? nome_ramo_atividade,
            string? codigo_ramo_atividade,
            string? timestamp,
            string? portal)
        {
            this.id_ramo_atividade = id_ramo_atividade;
            this.nome_ramo_atividade = nome_ramo_atividade;
            this.codigo_ramo_atividade = codigo_ramo_atividade;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}