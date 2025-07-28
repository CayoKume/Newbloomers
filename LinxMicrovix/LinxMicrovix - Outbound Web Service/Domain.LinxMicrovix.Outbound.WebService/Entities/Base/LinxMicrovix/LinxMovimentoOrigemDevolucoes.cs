namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoOrigemDevolucoes
    {
        public string? identificador { get; set; }
        public string? cnpj_emp { get; set; }
        public string? nota_origem { get; set; }
        public string? ecf_origem { get; set; }
        public string? data_origem { get; set; }
        public string? serie_origem { get; set; }
        public string? empresa { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }
    }
}
