

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxNFeEvento
    {
        public string? lastupdateon { get; private set; }
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? id_nfe_evento { get; private set; }
        public string? id_nfe { get; private set; }
        public string? codigo_tipo { get; private set; }
        public string? xml { get; private set; }
        public string? timestamp { get; private set; }
        public string? data_emissao { get; private set; }
        public string? hora_emissao { get; private set; }

        public LinxNFeEvento() { }

        public LinxNFeEvento(
            string? lastupdateon,
            string? portal,
            string? cnpj_emp,
            string? id_nfe_evento,
            string? id_nfe,
            string? codigo_tipo,
            string? xml,
            string? timestamp,
            string? data_emissao,
            string? hora_emissao
        )
        {
            this.lastupdateon = lastupdateon;
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_nfe_evento = id_nfe_evento;
            this.id_nfe = id_nfe;
            this.codigo_tipo = codigo_tipo;
            this.xml = xml;
            this.timestamp = timestamp;
            this.data_emissao = data_emissao;
            this.hora_emissao = hora_emissao;
        }
    }
}