namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcms
    {
        public string? id_motivos_desoneracao_icms { get; set; }
        public string? portal { get; set; }
        public string? descricao { get; set; }
        public string? timestamp { get; set; }

        public LinxMotivosDesoneracaoIcms()
        {
        }

        public LinxMotivosDesoneracaoIcms(string? id_motivos_desoneracao_icms, string? portal, string? descricao, string? timestamp)
        {
            this.id_motivos_desoneracao_icms = id_motivos_desoneracao_icms;
            this.portal = portal;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}
