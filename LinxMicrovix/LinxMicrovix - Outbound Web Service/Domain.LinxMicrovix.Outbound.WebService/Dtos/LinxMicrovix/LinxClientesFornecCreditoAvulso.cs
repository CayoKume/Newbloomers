namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecCreditoAvulso
    {
        public string? id_credito_avulso { get; set; }
        public string? cod_cliente_fornec { get; set; }
        public string? valor { get; set; }
        public string? data_lancamento { get; set; }
        public string? data_validade { get; set; }
        public string? observacao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxClientesFornecCreditoAvulso() { }

        public LinxClientesFornecCreditoAvulso(string? id_credito_avulso, string? cod_cliente_fornec, string? valor, string? data_lancamento, string? data_validade, string? observacao, string? timestamp, string? portal)
        {
            this.id_credito_avulso = id_credito_avulso;
            this.cod_cliente_fornec = cod_cliente_fornec;
            this.valor = valor;
            this.data_lancamento = data_lancamento;
            this.data_validade = data_validade;
            this.observacao = observacao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}