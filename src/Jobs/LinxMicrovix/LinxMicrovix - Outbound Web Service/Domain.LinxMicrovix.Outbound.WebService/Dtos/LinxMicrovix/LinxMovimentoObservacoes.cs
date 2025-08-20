using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoObservacoes
    {
        public string? id_obs { get; private set; }
        public string? portal { get; private set; }
        public string? titulo_obs { get; private set; }
        public string? descricao_obs { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoObservacoes() { }

        public LinxMovimentoObservacoes(
            string? id_obs,
            string? portal,
            string? titulo_obs,
            string? descricao_obs,
            string? timestamp
        )
        {
            this.id_obs = id_obs;
            this.portal = portal;
            this.titulo_obs = titulo_obs;
            this.descricao_obs = descricao_obs;
            this.timestamp = timestamp;
        }
    }
}