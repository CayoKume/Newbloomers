namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMetasVendedoresDia
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_meta { get; set; }
        public string? descricao_meta { get; set; }
        public string? data_inicial_meta { get; set; }
        public string? data_final_meta { get; set; }
        public string? dia { get; set; }
        public string? valor_meta_diaria { get; set; }
        public string? cod_vendedor { get; set; }
    }
}
