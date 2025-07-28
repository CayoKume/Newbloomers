namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCores
    {
        public string? id_cor { get; set; }
        public string? desc_cor { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }
        public string? ativo { get; set; }

        public LinxCores()
        {
        }

        public LinxCores(string? id_cor, string? desc_cor, string? timestamp, string? codigo_integracao_ws, string? ativo)
        {
            this.id_cor = id_cor;
            this.desc_cor = desc_cor;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
            this.ativo = ativo;
        }
    }
}
