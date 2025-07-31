namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaClientesSaldo
    {
        public string? saldo { get; set; }
        public string? cod_cliente_erp { get; set; }
        public string? empresa { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
