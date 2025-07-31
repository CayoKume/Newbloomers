namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosPromocao
    {
        public string? codigo_promocao { get; private set; }
        public string? empresa { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? preco { get; private set; }
        public string? data_inicio { get; private set; }
        public string? data_termino { get; private set; }
        public string? data_cadastro { get; private set; }
        public string? ativa { get; private set; }
        public string? codigo_campanha { get; private set; }
        public string? promocao_opcional { get; private set; }
        public string? timestamp { get; private set; }
        public string? referencia { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosPromocao() { }

        public B2CConsultaProdutosPromocao(string? codigo_promocao, string? empresa, string? codigoproduto, string? preco, string? data_inicio, string? data_termino, string? data_cadastro, string? ativa, string? codigo_campanha, string? promocao_opcional, string? timestamp, string? referencia, string? portal)
        {
            this.codigo_promocao = codigo_promocao;
            this.empresa = empresa;
            this.codigoproduto = codigoproduto;
            this.preco = preco;
            this.data_inicio = data_inicio;
            this.data_termino = data_termino;
            this.data_cadastro = data_cadastro;
            this.ativa = ativa;
            this.codigo_campanha = codigo_campanha;
            this.promocao_opcional = promocao_opcional;
            this.timestamp = timestamp;
            this.referencia = referencia;
            this.portal = portal;
        }
    }
}