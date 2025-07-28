namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxEspessuras
    {
        public string? id_espessura { get; set; }
        public string? desc_espessura { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }
        public string? ativo { get; set; }

        public LinxEspessuras()
        {
        }

        public LinxEspessuras(string? id_espessura, string? desc_espessura, string? timestamp, string? codigo_integracao_ws, string? ativo)
        {
            this.id_espessura = id_espessura;
            this.desc_espessura = desc_espessura;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
            this.ativo = ativo;
        }
    }
}
