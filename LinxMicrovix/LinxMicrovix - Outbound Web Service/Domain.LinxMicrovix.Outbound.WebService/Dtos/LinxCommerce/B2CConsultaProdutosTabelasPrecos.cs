namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecos
    {
        public string? id_prod_tab_preco { get; private set; }
        public string? id_tabela { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? precovenda { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosTabelasPrecos() { }

        public B2CConsultaProdutosTabelasPrecos(string? id_prod_tab_preco, string? id_tabela, string? codigoproduto, string? precovenda, string? timestamp, string? portal)
        {
            this.id_prod_tab_preco = id_prod_tab_preco;
            this.id_tabela = id_tabela;
            this.codigoproduto = codigoproduto;
            this.precovenda = precovenda;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}