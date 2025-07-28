namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecCamposAdicionais
    {
        public string? portal { get; set; }
        public string? cod_cliente { get; set; }
        public string? campo { get; set; }
        public string? valor { get; set; }

        public LinxClientesFornecCamposAdicionais()
        {
        }

        public LinxClientesFornecCamposAdicionais(string? portal, string? cod_cliente, string? campo, string? valor)
        {
            this.portal = portal;
            this.cod_cliente = cod_cliente;
            this.campo = campo;
            this.valor = valor;
        }
    }
}
