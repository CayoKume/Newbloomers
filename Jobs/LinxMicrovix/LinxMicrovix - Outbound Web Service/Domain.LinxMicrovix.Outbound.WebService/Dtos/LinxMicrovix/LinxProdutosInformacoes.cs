namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosInformacoes
    {
        public string? codigoproduto { get; set; }
        public string? informacoes_produto { get; set; }

        public LinxProdutosInformacoes() { }

        public LinxProdutosInformacoes(
            string? codigoproduto,
            string? informacoes_produto
        )
        {
            this.codigoproduto = codigoproduto;
            this.informacoes_produto = informacoes_produto;
        }
    }
}