namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaCodigoRastreio
    {
        public string? id_pedido { get; private set; }
        public string? documento { get; private set; }
        public string? serie { get; private set; }
        public string? codigo_rastreio { get; private set; }
        public string? sequencia_volume { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaCodigoRastreio() { }

        public B2CConsultaCodigoRastreio(
            string? id_pedido,
            string? documento,
            string? serie,
            string? codigo_rastreio,
            string? sequencia_volume,
            string? timestamp,
            string? portal
        )
        {
            this.id_pedido = id_pedido;
            this.documento = documento;
            this.serie = serie;
            this.codigo_rastreio = codigo_rastreio;
            this.sequencia_volume = sequencia_volume;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}