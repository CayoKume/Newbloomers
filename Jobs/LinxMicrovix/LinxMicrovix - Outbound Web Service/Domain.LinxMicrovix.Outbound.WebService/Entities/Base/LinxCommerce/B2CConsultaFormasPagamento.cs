namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaFormasPagamento
    {
        public string? cod_forma_pgto { get; set; }
        public string? forma_pgto { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
