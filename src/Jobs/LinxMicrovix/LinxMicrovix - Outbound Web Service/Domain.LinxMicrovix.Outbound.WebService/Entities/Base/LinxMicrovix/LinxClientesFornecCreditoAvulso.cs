namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxClientesFornecCreditoAvulso
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? cod_cliente { get; set; }
        public string? controle { get; set; }
        public string? data { get; set; }
        public string? cd { get; set; }
        public string? valor { get; set; }
        public string? motivo { get; set; }
        public string? timestamp { get; set; }
        public string? identificador { get; set; }
        public string? cnpj_emp { get; set; }
    }
}
