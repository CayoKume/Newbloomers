namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosCodebar
    {
        public string? codigoproduto { get; private set; }
        public string? codebar { get; private set; }
        public string? id_produtos_codebar { get; private set; }
        public string? principal { get; private set; }
        public string? empresa { get; private set; }
        public string? timestamp { get; private set; }
        public string? tipo_codebar { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosCodebar() { }

        public B2CConsultaProdutosCodebar(
            string? codigoproduto,
            string? codebar,
            string? id_produtos_codebar,
            string? principal,
            string? empresa,
            string? timestamp,
            string? tipo_codebar,
            string? portal
        )
        {
            this.codigoproduto = codigoproduto;
            this.codebar = codebar;
            this.id_produtos_codebar = id_produtos_codebar;
            this.principal = principal;
            this.empresa = empresa;
            this.timestamp = timestamp;
            this.tipo_codebar = tipo_codebar;
            this.portal = portal;
        }
    }
}