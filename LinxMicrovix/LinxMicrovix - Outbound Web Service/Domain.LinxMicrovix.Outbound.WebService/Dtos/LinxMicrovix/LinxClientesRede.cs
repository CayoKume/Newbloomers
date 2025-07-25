namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesRede
    {
        public string? id_clientes_rede { get; set; }
        public string? cod_cliente_fornec { get; set; }
        public string? id_rede { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxClientesRede() { }

        public LinxClientesRede(string? id_clientes_rede, string? cod_cliente_fornec, string? id_rede, string? timestamp, string? portal)
        {
            this.id_clientes_rede = id_clientes_rede;
            this.cod_cliente_fornec = cod_cliente_fornec;
            this.id_rede = id_rede;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}