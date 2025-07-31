namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxSangriaSuprimentos
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? usuario { get; set; }
        public string? data { get; set; }
        public string? valor { get; set; }
        public string? obs { get; set; }
        public string? cancelado { get; set; }
        public string? conferido { get; set; }
        public string? cod_historico { get; set; }
        public string? desc_historico { get; set; }
        public string? id_sangria_suprimentos { get; set; }
    }
}
