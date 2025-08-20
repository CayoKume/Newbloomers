namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaClientesSaldoLinx
    {
        public string? cod_cliente_erp { get; set; }
        public string? cod_cliente_b2c { get; set; }
        public string? empresa { get; set; }
        public string? valor { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
