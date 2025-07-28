namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAcoesPromocionais
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_acoes_promocionais { get; set; }
        public string? descricao { get; set; }
        public string? vigencia_inicio { get; set; }
        public string? vigencia_fim { get; set; }
        public string? observacao { get; set; }
        public string? ativa { get; set; }
        public string? excluida { get; set; }
        public string? integrada { get; set; }
        public string? qtde_integrada { get; set; }
        public string? valor_pago_franqueadora { get; set; }

        public LinxAcoesPromocionais()
        {
        }

        public LinxAcoesPromocionais(string? portal, string? cnpj_emp, string? id_acoes_promocionais, string? descricao, string? vigencia_inicio, string? vigencia_fim, string? observacao, string? ativa, string? excluida, string? integrada, string? qtde_integrada, string? valor_pago_franqueadora)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_acoes_promocionais = id_acoes_promocionais;
            this.descricao = descricao;
            this.vigencia_inicio = vigencia_inicio;
            this.vigencia_fim = vigencia_fim;
            this.observacao = observacao;
            this.ativa = ativa;
            this.excluida = excluida;
            this.integrada = integrada;
            this.qtde_integrada = qtde_integrada;
            this.valor_pago_franqueadora = valor_pago_franqueadora;
        }
    }
}
