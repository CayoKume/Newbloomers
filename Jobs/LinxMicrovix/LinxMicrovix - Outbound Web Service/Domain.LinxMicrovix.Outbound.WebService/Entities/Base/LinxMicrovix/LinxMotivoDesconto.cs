namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMotivoDesconto
    {
        public string? id_motivo_desconto { get; set; }
        public string? desc_motivo_desconto { get; set; }
        public string? ativo { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }
    }
}
