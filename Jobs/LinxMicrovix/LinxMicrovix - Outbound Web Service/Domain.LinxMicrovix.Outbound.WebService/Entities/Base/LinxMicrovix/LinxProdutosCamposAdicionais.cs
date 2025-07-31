namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosCamposAdicionais
    {
        public string? portal { get; set; }
        public string? cod_produto { get; set; }
        public string? campo { get; set; }
        public string? valor { get; set; }
        public string? timestamp { get; set; }
    }
}
