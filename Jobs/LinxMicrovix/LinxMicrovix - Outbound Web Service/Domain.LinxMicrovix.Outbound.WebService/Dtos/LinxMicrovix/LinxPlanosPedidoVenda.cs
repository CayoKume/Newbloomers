using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxPlanosPedidoVenda
    {
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? cod_pedido { get; private set; }
        public string? plano { get; private set; }
        public string? desc_plano { get; private set; }
        public string? total { get; private set; }
        public string? qtde_parcelas { get; private set; }
        public string? indice_plano { get; private set; }
        public string? valor_desc_acresc_plano { get; private set; }
        public string? cod_forma_pgto { get; private set; }
        public string? forma_pgto { get; private set; }

        public LinxPlanosPedidoVenda() { }

        public LinxPlanosPedidoVenda(
            string? portal,
            string? cnpj_emp,
            string? cod_pedido,
            string? plano,
            string? desc_plano,
            string? total,
            string? qtde_parcelas,
            string? indice_plano,
            string? valor_desc_acresc_plano,
            string? cod_forma_pgto,
            string? forma_pgto
        )
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.cod_pedido = cod_pedido;
            this.plano = plano;
            this.desc_plano = desc_plano;
            this.total = total;
            this.qtde_parcelas = qtde_parcelas;
            this.indice_plano = indice_plano;
            this.valor_desc_acresc_plano = valor_desc_acresc_plano;
            this.cod_forma_pgto = cod_forma_pgto;
            this.forma_pgto = forma_pgto;
        }
    }
}