namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosCodBar
    {
        public string? portal { get; set; }
        public string? cod_produto { get; set; }
        public string? cod_barra { get; set; }
        public string? timestamp { get; set; }
    }
}
