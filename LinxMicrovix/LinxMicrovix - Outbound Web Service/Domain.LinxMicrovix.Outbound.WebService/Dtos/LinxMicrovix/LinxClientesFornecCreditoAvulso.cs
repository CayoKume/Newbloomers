namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecCreditoAvulso
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? cod_cliente { get; set; }
        public string? controle { get; set; }
        public string? data { get; set; }
        public string? cd { get; set; }
        public string? valor { get; set; }
        public string? motivo { get; set; }
        public string? timestamp { get; set; }
        public string? identificador { get; set; }
        public string? cnpj_emp { get; set; }

        public LinxClientesFornecCreditoAvulso()
        {
        }

        public LinxClientesFornecCreditoAvulso(string? portal, string? empresa, string? cod_cliente, string? controle, string? data, string? cd, string? valor, string? motivo, string? timestamp, string? identificador, string? cnpj_emp)
        {
            this.portal = portal;
            this.empresa = empresa;
            this.cod_cliente = cod_cliente;
            this.controle = controle;
            this.data = data;
            this.cd = cd;
            this.valor = valor;
            this.motivo = motivo;
            this.timestamp = timestamp;
            this.identificador = identificador;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
