namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMarcas
    {
        public string? codigo_marca { get; set; }
        public string? nome_marca { get; set; }
        public string? timestamp { get; set; }
        public string? linhas { get; set; }
        public string? portal { get; set; }

        public LinxMarcas() { }

        public LinxMarcas(string? codigo_marca, string? nome_marca, string? timestamp, string? linhas, string? portal)
        {
            this.codigo_marca = codigo_marca;
            this.nome_marca = nome_marca;
            this.timestamp = timestamp;
            this.linhas = linhas;
            this.portal = portal;
        }

    }
}