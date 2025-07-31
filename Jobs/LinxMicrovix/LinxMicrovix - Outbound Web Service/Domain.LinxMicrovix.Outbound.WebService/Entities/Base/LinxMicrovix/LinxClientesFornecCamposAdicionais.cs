namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxClientesFornecCamposAdicionais
    {
        public string? portal { get; set; }
        public string? cod_cliente { get; set; }
        public string? campo { get; set; }
        public string? valor { get; set; }
    }
}
