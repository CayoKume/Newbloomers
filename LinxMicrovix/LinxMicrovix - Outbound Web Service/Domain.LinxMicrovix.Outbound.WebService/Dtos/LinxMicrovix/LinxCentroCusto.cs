namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCentroCusto
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? CNPJ { get; set; }
        public string? id_centrocusto { get; set; }
        public string? nome_centrocusto { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }

        public LinxCentroCusto()
        {
        }

        public LinxCentroCusto(string? portal, string? empresa, string? CNPJ, string? id_centrocusto, string? nome_centrocusto, string? ativo, string? timestamp)
        {
            this.portal = portal;
            this.empresa = empresa;
            this.CNPJ = CNPJ;
            this.id_centrocusto = id_centrocusto;
            this.nome_centrocusto = nome_centrocusto;
            this.ativo = ativo;
            this.timestamp = timestamp;
        }
    }
}
