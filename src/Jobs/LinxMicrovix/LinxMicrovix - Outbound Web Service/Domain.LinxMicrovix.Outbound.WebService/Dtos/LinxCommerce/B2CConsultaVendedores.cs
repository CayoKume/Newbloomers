namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaVendedores
    {
        public string? cod_vendedor { get; private set; }
        public string? nome_vendedor { get; private set; }
        public string? comissao_produtos { get; private set; }
        public string? comissao_servicos { get; private set; }
        public string? tipo { get; private set; }
        public string? ativo { get; private set; }
        public string? comissionado { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaVendedores() { }

        public B2CConsultaVendedores(string? cod_vendedor, string? nome_vendedor, string? comissao_produtos, string? comissao_servicos, string? tipo, string? ativo, string? comissionado, string? timestamp, string? portal)
        {
            this.cod_vendedor = cod_vendedor;
            this.nome_vendedor = nome_vendedor;
            this.comissao_produtos = comissao_produtos;
            this.comissao_servicos = comissao_servicos;
            this.tipo = tipo;
            this.ativo = ativo;
            this.comissionado = comissionado;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}