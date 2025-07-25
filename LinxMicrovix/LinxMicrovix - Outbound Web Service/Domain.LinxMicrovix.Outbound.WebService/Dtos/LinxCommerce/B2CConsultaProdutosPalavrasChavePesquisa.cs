namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisa
    {
        public string? portal { get; private set; }
        public string? id_b2c_palavras_chave_pesquisa_produtos { get; private set; }
        public string? id_b2c_palavras_chave_pesquisa { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? timestamp { get; private set; }
        public string? descricao_b2c_palavras_chave_pesquisa { get; private set; }

        // Empty constructor
        public B2CConsultaProdutosPalavrasChavePesquisa() { }

        // Constructor with string parameters
        public B2CConsultaProdutosPalavrasChavePesquisa(string? portal, string? id_b2c_palavras_chave_pesquisa_produtos, string? id_b2c_palavras_chave_pesquisa, string? codigoproduto, string? timestamp, string? descricao_b2c_palavras_chave_pesquisa)
        {
            this.portal = portal;
            this.id_b2c_palavras_chave_pesquisa_produtos = id_b2c_palavras_chave_pesquisa_produtos;
            this.id_b2c_palavras_chave_pesquisa = id_b2c_palavras_chave_pesquisa;
            this.codigoproduto = codigoproduto;
            this.timestamp = timestamp;
            this.descricao_b2c_palavras_chave_pesquisa = descricao_b2c_palavras_chave_pesquisa;
        }
    }
}