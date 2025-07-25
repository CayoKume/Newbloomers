namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClasseFiscal
    {
        public string? codigo_classe_fiscal { get; set; }
        public string? descricao_classe_fiscal { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxClasseFiscal() { }

        public LinxClasseFiscal(string? codigo_classe_fiscal, string? descricao_classe_fiscal, string? timestamp, string? portal)
        {
            this.codigo_classe_fiscal = codigo_classe_fiscal;
            this.descricao_classe_fiscal = descricao_classe_fiscal;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}