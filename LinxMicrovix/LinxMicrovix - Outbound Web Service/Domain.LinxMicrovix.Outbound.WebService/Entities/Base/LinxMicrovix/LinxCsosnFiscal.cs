namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxCsosnFiscal
    {
        public string? portal { get; set; }
        public string? id_csosn_fiscal { get; set; }
        public string? csosn_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? id_csosn_fiscal_substitutiva { get; set; }
        public string? timestamp { get; set; }
    }
}
