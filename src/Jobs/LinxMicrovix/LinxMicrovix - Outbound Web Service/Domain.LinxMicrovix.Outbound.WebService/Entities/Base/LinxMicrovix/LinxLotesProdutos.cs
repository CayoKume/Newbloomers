namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxLotesProdutos
    {
        public string? id_lote { get; set; }
        public string? codigo_produto { get; set; }
        public string? lote { get; set; }
        public string? identificador { get; set; }
        public string? transacao { get; set; }
        public string? data_fabricacao { get; set; }
        public string? data_vencimento { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }
    }
}
