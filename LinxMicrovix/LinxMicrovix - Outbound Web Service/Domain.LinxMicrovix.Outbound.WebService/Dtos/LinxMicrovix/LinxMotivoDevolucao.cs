namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMotivoDevolucao
    {
        public string? id_motivo_devolucao { get; set; }
        public string? descricao_motivo_devolucao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMotivoDevolucao() { }

        public LinxMotivoDevolucao(string? id_motivo_devolucao, string? descricao_motivo_devolucao, string? timestamp, string? portal)
        {
            this.id_motivo_devolucao = id_motivo_devolucao;
            this.descricao_motivo_devolucao = descricao_motivo_devolucao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}