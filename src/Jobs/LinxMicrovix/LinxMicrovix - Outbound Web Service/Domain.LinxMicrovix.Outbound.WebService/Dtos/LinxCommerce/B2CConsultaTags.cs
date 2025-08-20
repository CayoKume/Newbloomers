namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaTags
    {
        public string? portal { get; private set; }
        public string? id_pedido_item { get; private set; }
        public string? descricao { get; private set; }
        public string? timestamp { get; private set; }

        public B2CConsultaTags() { }

        public B2CConsultaTags(string? portal, string? id_pedido_item, string? descricao, string? timestamp)
        {
            this.portal = portal;
            this.id_pedido_item = id_pedido_item;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}