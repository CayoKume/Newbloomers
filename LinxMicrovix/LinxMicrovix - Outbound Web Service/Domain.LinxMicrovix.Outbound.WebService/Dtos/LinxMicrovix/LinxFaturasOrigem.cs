namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFaturasOrigem
    {
        public string? id_fatura_origem { get; set; }
        public string? descricao_fatura_origem { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxFaturasOrigem() { }

        public LinxFaturasOrigem(string? id_fatura_origem, string? descricao_fatura_origem, string? timestamp, string? portal)
        {
            this.id_fatura_origem = id_fatura_origem;
            this.descricao_fatura_origem = descricao_fatura_origem;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}