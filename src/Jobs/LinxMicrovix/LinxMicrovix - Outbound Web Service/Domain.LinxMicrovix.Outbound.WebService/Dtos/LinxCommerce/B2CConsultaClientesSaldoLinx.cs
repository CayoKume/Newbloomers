namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaClientesSaldoLinx
    {
        public string? cod_cliente_erp { get; private set; }
        public string? cod_cliente_b2c { get; private set; }
        public string? empresa { get; private set; }
        public string? valor { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaClientesSaldoLinx() { }

        public B2CConsultaClientesSaldoLinx(
            string? cod_cliente_erp,
            string? cod_cliente_b2c,
            string? empresa,
            string? valor,
            string? timestamp,
            string? portal
        )
        {
            this.cod_cliente_erp = cod_cliente_erp;
            this.cod_cliente_b2c = cod_cliente_b2c;
            this.empresa = empresa;
            this.valor = valor;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}