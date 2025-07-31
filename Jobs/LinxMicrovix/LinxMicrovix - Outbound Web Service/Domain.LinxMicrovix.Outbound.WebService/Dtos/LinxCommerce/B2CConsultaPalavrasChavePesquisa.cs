namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisa
    {
        public string? portal { get; private set; }
        public string? id_b2c_palavras_chave_pesquisa { get; private set; }
        public string? nome_colecao { get; private set; }
        public string? timestamp { get; private set; }

        public B2CConsultaPalavrasChavePesquisa() { }

        public B2CConsultaPalavrasChavePesquisa(
            string? portal,
            string? id_b2c_palavras_chave_pesquisa,
            string? nome_colecao,
            string? timestamp
        )
        {
            this.portal = portal;
            this.id_b2c_palavras_chave_pesquisa = id_b2c_palavras_chave_pesquisa;
            this.nome_colecao = nome_colecao;
            this.timestamp = timestamp;
        }
    }
}