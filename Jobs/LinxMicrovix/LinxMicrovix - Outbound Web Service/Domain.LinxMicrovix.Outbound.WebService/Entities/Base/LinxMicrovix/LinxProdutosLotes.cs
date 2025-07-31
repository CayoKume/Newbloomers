namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosLotes
    {
        public string? portal { get; set; }
        public string? codigoproduto { get; set; }
        public string? empresa { get; set; }
        public string? lote { get; set; }
        public string? deposito { get; set; }
        public string? saldo_disponivel { get; set; }
        public string? timestamp { get; set; }
    }
}
