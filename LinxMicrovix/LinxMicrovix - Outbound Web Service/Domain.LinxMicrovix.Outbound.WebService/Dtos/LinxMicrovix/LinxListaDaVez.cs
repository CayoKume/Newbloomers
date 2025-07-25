namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxListaDaVez
    {
        public string? id_lista_da_vez { get; set; }
        public string? cod_cliente_fornec { get; set; }
        public string? data_entrada { get; set; }
        public string? data_saida { get; set; }
        public string? status { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxListaDaVez() { }

        public LinxListaDaVez(string? id_lista_da_vez, string? cod_cliente_fornec, string? data_entrada,
                              string? data_saida, string? status, string? timestamp, string? portal)
        {
            this.id_lista_da_vez = id_lista_da_vez;
            this.cod_cliente_fornec = cod_cliente_fornec;
            this.data_entrada = data_entrada;
            this.data_saida = data_saida;
            this.status = status;
            this.timestamp = timestamp;
            this.portal = portal;
        }

    }
}