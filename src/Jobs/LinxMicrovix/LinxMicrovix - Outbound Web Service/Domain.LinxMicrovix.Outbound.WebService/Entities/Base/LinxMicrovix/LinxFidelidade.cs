namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxFidelidade
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
    }
}
