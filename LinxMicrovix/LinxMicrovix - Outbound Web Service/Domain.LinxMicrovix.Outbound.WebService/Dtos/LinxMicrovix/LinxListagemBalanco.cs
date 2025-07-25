namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxListagemBalanco
    {
        public string? id_listagem_balanco { get; set; }
        public string? empresa { get; set; }
        public string? data_balanco { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxListagemBalanco() { }

        public LinxListagemBalanco(string? id_listagem_balanco, string? empresa, string? data_balanco,
                                   string? codigoproduto, string? quantidade, string? timestamp, string? portal)
        {
            this.id_listagem_balanco = id_listagem_balanco;
            this.empresa = empresa;
            this.data_balanco = data_balanco;
            this.codigoproduto = codigoproduto;
            this.quantidade = quantidade;
            this.timestamp = timestamp;
            this.portal = portal;
        }

    }
}