namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosDetalhes
    {
        public string? id_prod_det { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? empresa { get; private set; }
        public string? saldo { get; private set; }
        public string? controla_lote { get; private set; }
        public string? nomeproduto_alternativo { get; private set; }
        public string? timestamp { get; private set; }
        public string? referencia { get; private set; }
        public string? localizacao { get; private set; }
        public string? portal { get; private set; }
        public string? tempo_preparacao_estoque { get; private set; }

        public B2CConsultaProdutosDetalhes() { }

        public B2CConsultaProdutosDetalhes(
            string? id_prod_det,
            string? codigoproduto,
            string? empresa,
            string? saldo,
            string? controla_lote,
            string? nomeproduto_alternativo,
            string? timestamp,
            string? referencia,
            string? localizacao,
            string? portal,
            string? tempo_preparacao_estoque
        )
        {
            this.id_prod_det = id_prod_det;
            this.codigoproduto = codigoproduto;
            this.empresa = empresa;
            this.saldo = saldo;
            this.controla_lote = controla_lote;
            this.nomeproduto_alternativo = nomeproduto_alternativo;
            this.timestamp = timestamp;
            this.referencia = referencia;
            this.localizacao = localizacao;
            this.portal = portal;
            this.tempo_preparacao_estoque = tempo_preparacao_estoque;
        }
    }
}