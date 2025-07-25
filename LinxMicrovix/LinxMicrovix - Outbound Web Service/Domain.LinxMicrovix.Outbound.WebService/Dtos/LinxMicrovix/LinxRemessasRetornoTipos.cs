namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxRemessasRetornoTipos
    {
        public string? id_remessa_retorno_tipo { get; set; }
        public string? descricao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxRemessasRetornoTipos() { }

        public LinxRemessasRetornoTipos(
            string? id_remessa_retorno_tipo,
            string? descricao,
            string? timestamp,
            string? portal)
        {
            this.id_remessa_retorno_tipo = id_remessa_retorno_tipo;
            this.descricao = descricao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}