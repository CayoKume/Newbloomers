namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCsosnFiscal
    {
        public string? portal { get; set; }
        public string? id_csosn_fiscal { get; set; }
        public string? csosn_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? id_csosn_fiscal_substitutiva { get; set; }
        public string? timestamp { get; set; }

        public LinxCsosnFiscal()
        {
        }

        public LinxCsosnFiscal(string? portal, string? id_csosn_fiscal, string? csosn_fiscal, string? descricao, string? id_csosn_fiscal_substitutiva, string? timestamp)
        {
            this.portal = portal;
            this.id_csosn_fiscal = id_csosn_fiscal;
            this.csosn_fiscal = csosn_fiscal;
            this.descricao = descricao;
            this.id_csosn_fiscal_substitutiva = id_csosn_fiscal_substitutiva;
            this.timestamp = timestamp;
        }
    }
}
