namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMotivoDesconto
    {
        public string? id_motivo_desconto { get; set; }
        public string? desc_motivo_desconto { get; set; }
        public string? ativo { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }

        public LinxMotivoDesconto()
        {
        }

        public LinxMotivoDesconto(string? id_motivo_desconto, string? desc_motivo_desconto, string? ativo, string? excluido, string? timestamp)
        {
            this.id_motivo_desconto = id_motivo_desconto;
            this.desc_motivo_desconto = desc_motivo_desconto;
            this.ativo = ativo;
            this.excluido = excluido;
            this.timestamp = timestamp;
        }
    }
}
