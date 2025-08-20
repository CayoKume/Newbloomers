namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFidelidade
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_fidelidade_parceiro_log { get; set; }
        public string? data_transacao { get; set; }
        public string? operacao { get; set; }
        public string? aprovado_barramento { get; set; }
        public string? valor_monetario { get; set; }
        public string? numero_cartao { get; set; }
        public string? identificador_movimento { get; set; }
        public string? timestamp { get; set; }

        public LinxFidelidade()
        {
        }

        public LinxFidelidade(string? portal, string? cnpj_emp, string? id_fidelidade_parceiro_log, string? data_transacao, string? operacao, string? aprovado_barramento, string? valor_monetario, string? numero_cartao, string? identificador_movimento, string? timestamp)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_fidelidade_parceiro_log = id_fidelidade_parceiro_log;
            this.data_transacao = data_transacao;
            this.operacao = operacao;
            this.aprovado_barramento = aprovado_barramento;
            this.valor_monetario = valor_monetario;
            this.numero_cartao = numero_cartao;
            this.identificador_movimento = identificador_movimento;
            this.timestamp = timestamp;
        }
    }
}
