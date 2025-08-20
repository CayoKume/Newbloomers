namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxLancContabil
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
    }
}
