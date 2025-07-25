namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCentroCusto
    {
        public string? codigo_centro_custo { get; set; }
        public string? nome_centro_custo { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCentroCusto() { }

        public LinxCentroCusto(string? codigo_centro_custo, string? nome_centro_custo, string? timestamp, string? portal)
        {
            this.codigo_centro_custo = codigo_centro_custo;
            this.nome_centro_custo = nome_centro_custo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}