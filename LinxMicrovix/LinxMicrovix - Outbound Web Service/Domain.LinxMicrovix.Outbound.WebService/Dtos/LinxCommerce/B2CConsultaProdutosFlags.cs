namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosFlags
    {
        public string? portal { get; private set; }
        public string? id_b2c_flags_produtos { get; private set; }
        public string? id_b2c_flags { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? timestamp { get; private set; }
        public string? descricao_b2c_flags { get; private set; }

        public B2CConsultaProdutosFlags() { }

        public B2CConsultaProdutosFlags(
            string? portal,
            string? id_b2c_flags_produtos,
            string? id_b2c_flags,
            string? codigoproduto,
            string? timestamp,
            string? descricao_b2c_flags
        )
        {
            this.portal = portal;
            this.id_b2c_flags_produtos = id_b2c_flags_produtos;
            this.id_b2c_flags = id_b2c_flags;
            this.codigoproduto = codigoproduto;
            this.timestamp = timestamp;
            this.descricao_b2c_flags = descricao_b2c_flags;
        }
    }
}