namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxCentroCusto
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? CNPJ { get; set; }
        public string? id_centrocusto { get; set; }
        public string? nome_centrocusto { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }
    }
}
