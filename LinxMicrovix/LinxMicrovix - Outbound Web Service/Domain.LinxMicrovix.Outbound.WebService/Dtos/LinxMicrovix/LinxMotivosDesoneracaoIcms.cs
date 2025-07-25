namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcms
    {
        public string? id_motivo_desoneracao_icms { get; set; }
        public string? descricao_motivo_desoneracao_icms { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMotivosDesoneracaoIcms() { }

        public LinxMotivosDesoneracaoIcms(string? id_motivo_desoneracao_icms, string? descricao_motivo_desoneracao_icms, string? timestamp, string? portal)
        {
            this.id_motivo_desoneracao_icms = id_motivo_desoneracao_icms;
            this.descricao_motivo_desoneracao_icms = descricao_motivo_desoneracao_icms;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}