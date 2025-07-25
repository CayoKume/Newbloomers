namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosDimensoes
    {
        public string? codigoproduto { get; private set; }
        public string? altura { get; private set; }
        public string? comprimento { get; private set; }
        public string? timestamp { get; private set; }
        public string? largura { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosDimensoes() { }

        public B2CConsultaProdutosDimensoes(
            string? codigoproduto,
            string? altura,
            string? comprimento,
            string? timestamp,
            string? largura,
            string? portal
        )
        {
            this.codigoproduto = codigoproduto;
            this.altura = altura;
            this.comprimento = comprimento;
            this.timestamp = timestamp;
            this.largura = largura;
            this.portal = portal;
        }
    }
}