namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosCustos
    {
        public string? id_produtos_custos { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? empresa { get; private set; }
        public string? custoicms1 { get; private set; }
        public string? ipi1 { get; private set; }
        public string? markup { get; private set; }
        public string? customedio { get; private set; }
        public string? frete1 { get; private set; }
        public string? precisao { get; private set; }
        public string? precominimo { get; private set; }
        public string? dt_update { get; private set; }
        public string? custoliquido { get; private set; }
        public string? precovenda { get; private set; }
        public string? custototal { get; private set; }
        public string? precocompra { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosCustos() { }

        public B2CConsultaProdutosCustos(
            string? id_produtos_custos,
            string? codigoproduto,
            string? empresa,
            string? custoicms1,
            string? ipi1,
            string? markup,
            string? customedio,
            string? frete1,
            string? precisao,
            string? precominimo,
            string? dt_update,
            string? custoliquido,
            string? precovenda,
            string? custototal,
            string? precocompra,
            string? timestamp,
            string? portal
        )
        {
            this.id_produtos_custos = id_produtos_custos;
            this.codigoproduto = codigoproduto;
            this.empresa = empresa;
            this.custoicms1 = custoicms1;
            this.ipi1 = ipi1;
            this.markup = markup;
            this.customedio = customedio;
            this.frete1 = frete1;
            this.precisao = precisao;
            this.precominimo = precominimo;
            this.dt_update = dt_update;
            this.custoliquido = custoliquido;
            this.precovenda = precovenda;
            this.custototal = custototal;
            this.precocompra = precocompra;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}