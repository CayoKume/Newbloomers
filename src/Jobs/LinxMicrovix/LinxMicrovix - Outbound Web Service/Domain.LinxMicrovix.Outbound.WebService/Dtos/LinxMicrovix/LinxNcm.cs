using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxNcm
    {
        public string? portal { get; private set; }
        public string? codigo { get; private set; }
        public string? descricao { get; private set; }
        public string? codigo_genero { get; private set; }
        public string? ativo { get; private set; }
        public string? id_ncm { get; private set; }
        public string? timestamp { get; private set; }

        public LinxNcm() { }

        public LinxNcm(
            string? portal,
            string? codigo,
            string? descricao,
            string? codigo_genero,
            string? ativo,
            string? id_ncm,
            string? timestamp
        )
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.codigo_genero = codigo_genero;
            this.ativo = ativo;
            this.id_ncm = id_ncm;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}