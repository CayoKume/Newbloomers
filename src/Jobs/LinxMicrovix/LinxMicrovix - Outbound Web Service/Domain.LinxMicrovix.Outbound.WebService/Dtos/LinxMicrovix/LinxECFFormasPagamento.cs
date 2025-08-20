namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxECFFormasPagamento
    {
        public string? id_empresa_ecf_formas_pgto { get; set; }
        public string? id_ecf { get; set; }
        public string? cod_forma_pgto { get; set; }
        public string? indice_forma { get; set; }
        public string? timestamp { get; set; }

        public LinxECFFormasPagamento()
        {
        }

        public LinxECFFormasPagamento(string? id_empresa_ecf_formas_pgto, string? id_ecf, string? cod_forma_pgto, string? indice_forma, string? timestamp)
        {
            this.id_empresa_ecf_formas_pgto = id_empresa_ecf_formas_pgto;
            this.id_ecf = id_ecf;
            this.cod_forma_pgto = cod_forma_pgto;
            this.indice_forma = indice_forma;
            this.timestamp = timestamp;
        }
    }
}
