namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClassificacoes
    {
        public string? id_classificacao { get; set; }
        public string? desc_classificacao { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }
        public string? ativo { get; set; }

        public LinxClassificacoes()
        {
        }

        public LinxClassificacoes(string? id_classificacao, string? desc_classificacao, string? timestamp, string? codigo_integracao_ws, string? ativo)
        {
            this.id_classificacao = id_classificacao;
            this.desc_classificacao = desc_classificacao;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
            this.ativo = ativo;
        }
    }
}
