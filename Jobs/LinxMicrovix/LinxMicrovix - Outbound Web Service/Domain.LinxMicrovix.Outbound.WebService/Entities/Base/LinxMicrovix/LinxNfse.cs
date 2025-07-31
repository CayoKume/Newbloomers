namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxNfse
    {
        public string? id_nfse { get; set; }
        public string? portal { get; set; }
        public string? documento { get; set; }
        public string? codigo_verificacao { get; set; }
        public string? id_nfse_situacao { get; set; }
        public string? identificador { get; set; }
        public string? dt_insert { get; set; }
        public string? timestamp { get; set; }
    }
}
