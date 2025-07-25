namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosTags
    {
        public string? portal { get; private set; }
        public string? id_b2c_tags_produtos { get; private set; }
        public string? id_b2c_tags { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? timestamp { get; private set; }
        public string? descricao_b2c_tags { get; private set; }

        public B2CConsultaProdutosTags() { }

        public B2CConsultaProdutosTags(string? portal, string? id_b2c_tags_produtos, string? id_b2c_tags, string? codigoproduto, string? timestamp, string? descricao_b2c_tags)
        {
            this.portal = portal;
            this.id_b2c_tags_produtos = id_b2c_tags_produtos;
            this.id_b2c_tags = id_b2c_tags;
            this.codigoproduto = codigoproduto;
            this.timestamp = timestamp;
            this.descricao_b2c_tags = descricao_b2c_tags;
        }
    }
}