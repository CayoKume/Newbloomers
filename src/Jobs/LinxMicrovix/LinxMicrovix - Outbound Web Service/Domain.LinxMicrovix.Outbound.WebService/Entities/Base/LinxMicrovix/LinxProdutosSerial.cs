namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosSerial
    {
        public string? codigoproduto { get; set; }
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? serial { get; set; }
        public string? id_deposito { get; set; }
        public string? saldo { get; set; }
        public string? timestamp { get; set; }
    }
}
