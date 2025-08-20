namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaPedidosTipos
    {
        public string? id_tipo_b2c { get; private set; }
        public string? descricao { get; private set; }
        public string? pos_timestamp_old { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaPedidosTipos() { }

        public B2CConsultaPedidosTipos(
            string? id_tipo_b2c,
            string? descricao,
            string? pos_timestamp_old,
            string? portal
        )
        {
            this.id_tipo_b2c = id_tipo_b2c;
            this.descricao = descricao;
            this.pos_timestamp_old = pos_timestamp_old;
            this.portal = portal;
        }
    }
}