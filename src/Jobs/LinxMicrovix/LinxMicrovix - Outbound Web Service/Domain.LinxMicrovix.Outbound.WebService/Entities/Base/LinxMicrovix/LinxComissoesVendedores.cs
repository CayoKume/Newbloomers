namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxComissoesVendedores
    {
        public string? vendedor { get; set; }
        public string? empresa { get; set; }
        public string? data_origem { get; set; }
        public string? valor_base { get; set; }
        public string? valor_comissao { get; set; }
        public string? cancelado { get; set; }
        public string? disponivel { get; set; }
        public string? timestamp { get; set; }
    }
}
