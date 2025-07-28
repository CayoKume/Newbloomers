namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosInventario
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? cod_produto { get; set; }
        public string? cod_barra { get; set; }
        public string? quantidade { get; set; }
        public string? cod_deposito { get; set; }
        public string? empresa { get; set; }
    }
}
