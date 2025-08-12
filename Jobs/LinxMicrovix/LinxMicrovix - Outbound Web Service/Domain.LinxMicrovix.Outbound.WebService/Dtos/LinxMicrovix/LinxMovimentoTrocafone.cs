

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoTrocafone
    {
        public string? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public string? identificador { get; private set; }
        public string? num_vale { get; private set; }
        public string? voucher { get; private set; }
        public string? valor_vale { get; private set; }
        public string? nome_produto { get; private set; }
        public string? condicao { get; private set; }
        public string? id_tradein_parceiro { get; private set; }

        public LinxMovimentoTrocafone() { }

        public LinxMovimentoTrocafone(
            string? portal,
            string? cnpj_emp,
            string? identificador,
            string? num_vale,
            string? voucher,
            string? valor_vale,
            string? nome_produto,
            string? condicao,
            string? id_tradein_parceiro
        )
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.identificador = identificador;
            this.num_vale = num_vale;
            this.voucher = voucher;
            this.valor_vale = valor_vale;
            this.nome_produto = nome_produto;
            this.condicao = condicao;
            this.id_tradein_parceiro = id_tradein_parceiro;
        }
    }
}