namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxOrdensServicoProdutos
    {
        public string? id_ordservprod { get; private set; }
        public string? cod_produto_serv { get; private set; }
        public string? numero_os { get; private set; }
        public string? timestamp { get; private set; }

        public LinxOrdensServicoProdutos() { }

        public LinxOrdensServicoProdutos(
            string? id_ordservprod,
            string? cod_produto_serv,
            string? numero_os,
            string? timestamp

        )
        {
            this.id_ordservprod = id_ordservprod;
            this.cod_produto_serv = cod_produto_serv;
            this.numero_os = numero_os;
            this.timestamp = timestamp;
        }
    }
}