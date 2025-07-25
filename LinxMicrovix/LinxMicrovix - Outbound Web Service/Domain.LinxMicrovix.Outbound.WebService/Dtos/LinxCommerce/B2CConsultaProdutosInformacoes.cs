namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosInformacoes
    {
        public string? id_produtos_informacoes { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? informacoes_produto { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosInformacoes() { }

        public B2CConsultaProdutosInformacoes(string? id_produtos_informacoes, string? codigoproduto, string? informacoes_produto, string? timestamp, string? portal)
        {
            this.id_produtos_informacoes = id_produtos_informacoes;
            this.codigoproduto = codigoproduto;
            this.informacoes_produto = informacoes_produto;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}