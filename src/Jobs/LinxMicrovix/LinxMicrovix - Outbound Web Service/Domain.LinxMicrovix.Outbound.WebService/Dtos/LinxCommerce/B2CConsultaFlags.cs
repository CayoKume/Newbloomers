namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaFlags
    {
        public string? portal { get; private set; }
        public string? id_b2c_flags { get; private set; }
        public string? descricao { get; private set; }
        public string? timestamp { get; private set; }

        public B2CConsultaFlags() { }

        public B2CConsultaFlags(
            string? portal,
            string? id_b2c_flags,
            string? descricao,
            string? timestamp
        )
        {
            this.portal = portal;
            this.id_b2c_flags = id_b2c_flags;
            this.descricao = descricao;
            this.timestamp = timestamp;
        }
    }
}