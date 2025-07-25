namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecCamposAdicionais
    {
        public string? id_campo_valor { get; set; }
        public string? cod_cliente_fornec { get; set; }
        public string? id_campo_detalhe { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxClientesFornecCamposAdicionais() { }

        public LinxClientesFornecCamposAdicionais(string? id_campo_valor, string? cod_cliente_fornec, string? id_campo_detalhe, string? timestamp, string? portal)
        {
            this.id_campo_valor = id_campo_valor;
            this.cod_cliente_fornec = cod_cliente_fornec;
            this.id_campo_detalhe = id_campo_detalhe;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}