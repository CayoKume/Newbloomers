namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxSpedTipoBaseCredito
    {
        public string? id_sped_tipo_base_credito { get; set; }
        public string? codigo_sped_tipo_base_credito { get; set; }
        public string? descricao { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }

        public LinxSpedTipoBaseCredito() { }

        public LinxSpedTipoBaseCredito(
            string? id_sped_tipo_base_credito,
            string? descricao,
            string? timestamp,
            string? codigo_sped_tipo_base_credito,
            string? portal
        )
        {
            this.id_sped_tipo_base_credito = id_sped_tipo_base_credito;
            this.descricao = descricao;
            this.codigo_sped_tipo_base_credito = codigo_sped_tipo_base_credito;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}