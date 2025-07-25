namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosAssociados
    {
        public string? id { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? codigoproduto_associado { get; private set; }
        public string? coeficiente_desconto { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }
        public string? qtde_item { get; private set; }
        public string? item_obrigatorio { get; private set; }

        public B2CConsultaProdutosAssociados() { }

        public B2CConsultaProdutosAssociados(
            string? id,
            string? codigoproduto,
            string? codigoproduto_associado,
            string? coeficiente_desconto,
            string? timestamp,
            string? portal,
            string? qtde_item,
            string? item_obrigatorio
        )
        {
            this.id = id;
            this.codigoproduto = codigoproduto;
            this.codigoproduto_associado = codigoproduto_associado;
            this.coeficiente_desconto = coeficiente_desconto;
            this.timestamp = timestamp;
            this.portal = portal;
            this.qtde_item = qtde_item;
            this.item_obrigatorio = item_obrigatorio;
        }
    }
}