namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMarcas
    {
        public string? id_marca { get; set; }
        public string? desc_marca { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }

        public LinxMarcas()
        {
        }

        public LinxMarcas(string? id_marca, string? desc_marca, string? timestamp, string? codigo_integracao_ws)
        {
            this.id_marca = id_marca;
            this.desc_marca = desc_marca;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
