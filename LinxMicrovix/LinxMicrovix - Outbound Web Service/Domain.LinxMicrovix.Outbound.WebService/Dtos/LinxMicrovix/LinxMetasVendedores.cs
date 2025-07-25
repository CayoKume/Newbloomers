namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMetasVendedores
    {
        public string? id_meta_vendedor { get; set; }
        public string? cod_vendedor { get; set; }
        public string? data_meta { get; set; }
        public string? valor_meta { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMetasVendedores() { }

        public LinxMetasVendedores(string? id_meta_vendedor, string? cod_vendedor, string? data_meta,
                                   string? valor_meta, string? timestamp, string? portal)
        {
            this.id_meta_vendedor = id_meta_vendedor;
            this.cod_vendedor = cod_vendedor;
            this.data_meta = data_meta;
            this.valor_meta = valor_meta;
            this.timestamp = timestamp;
            this.portal = portal;
        }

    }
}