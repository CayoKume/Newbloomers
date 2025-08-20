namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosDepositos
    {
        public string? portal { get; set; }
        public string? cod_deposito { get; set; }
        public string? nome_deposito { get; set; }
        public string? disponivel { get; set; }
        public string? disponivel_transferencia { get; set; }
        public string? timestamp { get; set; }
    }
}
