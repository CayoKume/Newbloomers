

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosDetalhesDepositos
    {
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? cod_produto { get; private set; }
        public string? empresa { get; private set; }
        public string? cod_deposito { get; private set; }
        public string? saldo { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosDetalhesDepositos() { }

        public LinxProdutosDetalhesDepositos(
            string? portal,
            string? cnpj_emp,
            string? cod_produto,
            string? empresa,
            string? cod_deposito,
            string? saldo,
            string? timestamp
        )
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.cod_produto = cod_produto;
            this.empresa = empresa;
            this.cod_deposito = cod_deposito;
            this.saldo = saldo;
            this.timestamp = timestamp;
        }
    }
}