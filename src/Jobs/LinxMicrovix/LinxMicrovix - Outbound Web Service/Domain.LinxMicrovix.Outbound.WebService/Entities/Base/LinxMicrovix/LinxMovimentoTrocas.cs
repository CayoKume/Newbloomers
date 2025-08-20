namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoTrocas
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? identificador { get; set; }
        public string? num_vale { get; set; }
        public string? valor_vale { get; set; }
        public string? motivo { get; set; }
        public string? doc_origem { get; set; }
        public string? serie_origem { get; set; }
        public string? doc_venda { get; set; }
        public string? serie_venda { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }
        public string? desfazimento { get; set; }
        public string? empresa { get; set; }
        public string? vale_cod_cliente { get; set; }
        public string? vale_codigoproduto { get; set; }
        public string? id_vale_ordem_servico_externa { get; set; }
        public string? doc_venda_origem { get; set; }
        public string? serie_venda_origem { get; set; }
        public string? cod_cliente { get; set; }
    }
}
