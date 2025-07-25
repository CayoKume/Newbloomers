using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxNFeEvento
    {
        public string? id_espessura { get; private set; }
        public string? desc_espessura { get; private set; }
        public string? timestamp { get; private set; }
        public string? codigo_integracao_ws { get; private set; }
        public string? ativo { get; private set; }

        public LinxNFeEvento() { }

        public LinxNFeEvento(
            string? id_espessura,
            string? desc_espessura,
            string? timestamp,
            string? codigo_integracao_ws,
            string? ativo
        )
        {
            this.id_espessura = id_espessura;
            this.desc_espessura = desc_espessura;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
            this.ativo = ativo;
        }
    }
}