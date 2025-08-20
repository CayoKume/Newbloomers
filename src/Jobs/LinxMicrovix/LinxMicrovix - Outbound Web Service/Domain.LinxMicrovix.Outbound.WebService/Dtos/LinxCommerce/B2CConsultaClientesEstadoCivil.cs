namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaClientesEstadoCivil
    {
        public string? id_estado_civil { get; private set; }
        public string? estado_civil { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaClientesEstadoCivil() { }

        public B2CConsultaClientesEstadoCivil(
            string? id_estado_civil,
            string? estado_civil,
            string? timestamp,
            string? portal
        )
        {
            this.id_estado_civil = id_estado_civil;
            this.estado_civil = estado_civil;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}