namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosDetalhesDepositos
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? cod_produto { get; set; }
        public string? empresa { get; set; }
        public string? cod_deposito { get; set; }
        public string? saldo { get; set; }
        public string? timestamp { get; set; }
    }
}
