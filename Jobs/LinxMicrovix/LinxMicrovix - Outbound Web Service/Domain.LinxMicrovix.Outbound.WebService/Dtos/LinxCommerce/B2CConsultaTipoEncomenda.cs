namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaTipoEncomenda
    {
        public string? id_tipo_encomenda { get; private set; }
        public string? nm_tipo_encomenda { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaTipoEncomenda() { }

        public B2CConsultaTipoEncomenda(string? id_tipo_encomenda, string? nm_tipo_encomenda, string? timestamp, string? portal)
        {
            this.id_tipo_encomenda = id_tipo_encomenda;
            this.nm_tipo_encomenda = nm_tipo_encomenda;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}