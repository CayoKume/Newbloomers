

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoRemessas
    {
        public string? id_remessas { get; private set; }
        public string? portal { get; private set; }
        public string? empresa { get; private set; }
        public string? id_tipo { get; private set; }
        public string? identificador_remessa { get; private set; }
        public string? status { get; private set; }
        public string? status_descricao { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoRemessas() { }

        public LinxMovimentoRemessas(
            string? id_remessas,
            string? portal,
            string? empresa,
            string? id_tipo,
            string? identificador_remessa,
            string? status,
            string? status_descricao,
            string? timestamp
        )
        {
            this.id_remessas = id_remessas;
            this.portal = portal;
            this.empresa = empresa;
            this.id_tipo = id_tipo;
            this.identificador_remessa = identificador_remessa;
            this.status = status;
            this.status_descricao = status_descricao;
            this.timestamp = timestamp;
        }
    }
}