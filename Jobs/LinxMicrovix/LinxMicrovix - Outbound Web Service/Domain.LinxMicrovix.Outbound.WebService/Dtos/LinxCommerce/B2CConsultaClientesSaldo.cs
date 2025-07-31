namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaClientesSaldo
    {
        public string? saldo { get; private set; }
        public string? cod_cliente_erp { get; private set; }
        public string? empresa { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaClientesSaldo() { }

        public B2CConsultaClientesSaldo(
            string? saldo,
            string? cod_cliente_erp,
            string? empresa,
            string? timestamp,
            string? portal
        )
        {
            this.saldo = saldo;
            this.cod_cliente_erp = cod_cliente_erp;
            this.empresa = empresa;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}