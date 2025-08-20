

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoOrigemDevolucoes
    {
        public string? identificador { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? nota_origem { get; private set; }
        public string? ecf_origem { get; private set; }
        public string? data_origem { get; private set; }
        public string? serie_origem { get; private set; }
        public string? empresa { get; private set; }
        public string? portal { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoOrigemDevolucoes() { }

        public LinxMovimentoOrigemDevolucoes(
            string? identificador,
            string? cnpj_emp,
            string? nota_origem,
            string? ecf_origem,
            string? data_origem,
            string? serie_origem,
            string? empresa,
            string? portal,
            string? timestamp
        )
        {
            this.identificador = identificador;
            this.cnpj_emp = cnpj_emp;
            this.nota_origem = nota_origem;
            this.ecf_origem = ecf_origem;
            this.data_origem = data_origem;
            this.serie_origem = serie_origem;
            this.empresa = empresa;
            this.portal = portal;
            this.timestamp = timestamp;
        }
    }
}