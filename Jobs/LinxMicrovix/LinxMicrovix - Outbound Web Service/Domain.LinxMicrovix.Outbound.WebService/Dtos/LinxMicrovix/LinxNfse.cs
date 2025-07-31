using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxNfse
    {
        public string? id_nfse { get; private set; }
        public string? portal { get; private set; }
        public string? documento { get; private set; }
        public string? codigo_verificacao { get; private set; }
        public string? id_nfse_situacao { get; private set; }
        public string? identificador { get; private set; }
        public string? dt_insert { get; private set; }
        public string? timestamp { get; private set; }

        public LinxNfse() { }

        public LinxNfse(
            string? id_nfse,
            string? portal,
            string? documento,
            string? codigo_verificacao,
            string? id_nfse_situacao,
            string? identificador,
            string? dt_insert,
            string? timestamp
        )
        {
            this.id_nfse = id_nfse;
            this.documento = documento;
            this.codigo_verificacao = codigo_verificacao;
            this.id_nfse_situacao = id_nfse_situacao;
            this.identificador = identificador;
            this.dt_insert = dt_insert;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}