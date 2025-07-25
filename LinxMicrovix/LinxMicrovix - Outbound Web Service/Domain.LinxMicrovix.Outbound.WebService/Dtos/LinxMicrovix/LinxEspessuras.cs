namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxEspessuras
    {
        public string? codigo_espessura { get; set; }
        public string? nome_espessura { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxEspessuras() { }

        public LinxEspessuras(string? codigo_espessura, string? nome_espessura, string? timestamp, string? portal)
        {
            this.codigo_espessura = codigo_espessura;
            this.nome_espessura = nome_espessura;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}