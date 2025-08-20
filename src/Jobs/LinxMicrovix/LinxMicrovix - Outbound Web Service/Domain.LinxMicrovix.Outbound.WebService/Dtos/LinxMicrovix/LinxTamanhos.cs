

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxTamanhos
    {
        public string? id_tamanho { get; private set; }
        public string? desc_tamanho { get; private set; }
        public string? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }
        public string? ativo { get; private set; }

        public LinxTamanhos() { }

        public LinxTamanhos(
            string? id_tamanho,
            string? desc_tamanho,
            string? timestamp,
            string? codigo_integracao_ws,
            string? ativo
        )
        {
            this.id_tamanho = id_tamanho;
            this.desc_tamanho = desc_tamanho;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
            this.ativo = ativo;
        }
    }
}