namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMotivoDevolucao
    {
        public string? cod_motivo { get; set; }
        public string? portal { get; set; }
        public string? descricao_motivo { get; set; }
        public string? cod_deposito { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }
    }
}
