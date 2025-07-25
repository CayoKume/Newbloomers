namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMotivoDesconto
    {
        public string? id_motivo_desconto { get; set; }
        public string? descricao_motivo_desconto { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMotivoDesconto() { }

        public LinxMotivoDesconto(string? id_motivo_desconto, string? descricao_motivo_desconto, string? timestamp, string? portal)
        {
            this.id_motivo_desconto = id_motivo_desconto;
            this.descricao_motivo_desconto = descricao_motivo_desconto;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}