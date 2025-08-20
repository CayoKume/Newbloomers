namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaEspessuras
    {
        public string? codigo_espessura { get; private set; }
        public string? nome_espessura { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaEspessuras() { }

        public B2CConsultaEspessuras(
            string? codigo_espessura,
            string? nome_espessura,
            string? timestamp,
            string? portal
        )
        {
            this.codigo_espessura = codigo_espessura;
            this.nome_espessura = nome_espessura;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}