namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosImagens
    {
        public string? id_imagem_produto { get; private set; }
        public string? id_imagem { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosImagens() { }

        public B2CConsultaProdutosImagens(
            string? id_imagem_produto,
            string? id_imagem,
            string? codigoproduto,
            string? timestamp,
            string? portal
        )
        {
            this.id_imagem_produto = id_imagem_produto;
            this.id_imagem = id_imagem;
            this.codigoproduto = codigoproduto;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}