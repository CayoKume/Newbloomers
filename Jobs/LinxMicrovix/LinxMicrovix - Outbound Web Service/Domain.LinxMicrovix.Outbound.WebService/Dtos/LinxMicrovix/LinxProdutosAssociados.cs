namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosAssociados
    {
        public string? codigoproduto_associado { get; private set; }
        public string? portal { get; private set; }
        public string? codigoproduto_origem { get; private set; }
        public string? coeficiente_desconto { get; private set; }
        public string? timestamp { get; private set; }
        public string? qtde_item { get; private set; }
        public string? item_obrigatorio { get; private set; }

        public LinxProdutosAssociados() { }

        public LinxProdutosAssociados(
            string? codigoproduto_associado,
            string? portal,
            string? codigoproduto_origem,
            string? coeficiente_desconto,
            string? timestamp,
            string? qtde_item,
            string? item_obrigatorio
        )
        {
            this.codigoproduto_origem = codigoproduto_origem;
            this.codigoproduto_associado = codigoproduto_associado;
            this.coeficiente_desconto = coeficiente_desconto;
            this.timestamp = timestamp;
            this.portal = portal;
            this.qtde_item = qtde_item;
            this.item_obrigatorio = item_obrigatorio;
        }
    }
}