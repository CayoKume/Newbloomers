namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValores
    {
        public string? id_campo_valor { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? id_campo_detalhe { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisValores() { }

        public B2CConsultaProdutosCamposAdicionaisValores(
            string? id_campo_valor,
            string? codigoproduto,
            string? id_campo_detalhe,
            string? timestamp,
            string? portal
        )
        {
            this.id_campo_valor = id_campo_valor;
            this.codigoproduto = codigoproduto;
            this.id_campo_detalhe = id_campo_detalhe;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}