namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLancContabil
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? cod_lanc { get; set; }
        public string? centro_custo { get; set; }
        public string? ind_conta { get; set; }
        public string? cod_conta { get; set; }
        public string? nome_conta { get; set; }
        public string? valor_conta { get; set; }
        public string? cred_deb { get; set; }
        public string? data_lanc { get; set; }
        public string? compl_conta { get; set; }
        public string? identificador { get; set; }
        public string? cod_historico { get; set; }
        public string? desc_historico { get; set; }
        public string? data_compensacao { get; set; }
        public string? fatura_origem { get; set; }
        public string? efetivado { get; set; }
        public string? timestamp { get; set; }
        public string? empresa { get; set; }
        public string? id_lanc { get; set; }
        public string? cancelado { get; set; }

        public LinxLancContabil()
        {
        }

        public LinxLancContabil(string? portal, string? cnpj_emp, string? cod_lanc, string? centro_custo, string? ind_conta, string? cod_conta, string? nome_conta, string? valor_conta, string? cred_deb, string? data_lanc, string? compl_conta, string? identificador, string? cod_historico, string? desc_historico, string? data_compensacao, string? fatura_origem, string? efetivado, string? timestamp, string? empresa, string? id_lanc, string? cancelado)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.cod_lanc = cod_lanc;
            this.centro_custo = centro_custo;
            this.ind_conta = ind_conta;
            this.cod_conta = cod_conta;
            this.nome_conta = nome_conta;
            this.valor_conta = valor_conta;
            this.cred_deb = cred_deb;
            this.data_lanc = data_lanc;
            this.compl_conta = compl_conta;
            this.identificador = identificador;
            this.cod_historico = cod_historico;
            this.desc_historico = desc_historico;
            this.data_compensacao = data_compensacao;
            this.fatura_origem = fatura_origem;
            this.efetivado = efetivado;
            this.timestamp = timestamp;
            this.empresa = empresa;
            this.id_lanc = id_lanc;
            this.cancelado = cancelado;
        }
    }
}
