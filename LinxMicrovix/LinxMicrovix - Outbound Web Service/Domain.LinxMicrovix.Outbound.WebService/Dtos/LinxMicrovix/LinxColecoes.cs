namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxColecoes
    {
        public string? id_colecao { get; set; }
        public string? desc_colecao { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }

        public LinxColecoes()
        {
        }

        public LinxColecoes(string? id_colecao, string? desc_colecao, string? timestamp, string? codigo_integracao_ws)
        {
            this.id_colecao = id_colecao;
            this.desc_colecao = desc_colecao;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
        }
    }
}
