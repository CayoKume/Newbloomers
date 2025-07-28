namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxECFFormasPagamento
    {
        public string? id_empresa_ecf_formas_pgto { get; set; }
        public string? id_ecf { get; set; }
        public string? cod_forma_pgto { get; set; }
        public string? indice_forma { get; set; }
        public string? timestamp { get; set; }
    }
}
