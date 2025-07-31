namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFaturasOrigem
    {
        public string? codigo_fatura { get; set; }
        public string? codigo_fatura_origem { get; set; }
        public string? timestamp { get; set; }

        public LinxFaturasOrigem()
        {
        }

        public LinxFaturasOrigem(string? codigo_fatura, string? codigo_fatura_origem, string? timestamp)
        {
            this.codigo_fatura = codigo_fatura;
            this.codigo_fatura_origem = codigo_fatura_origem;
            this.timestamp = timestamp;
        }
    }
}
