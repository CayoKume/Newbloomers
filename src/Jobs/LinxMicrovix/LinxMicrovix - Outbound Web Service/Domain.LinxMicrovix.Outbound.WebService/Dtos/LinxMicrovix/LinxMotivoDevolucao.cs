namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMotivoDevolucao
    {
        public string? cod_motivo { get; set; }
        public string? portal { get; set; }
        public string? descricao_motivo { get; set; }
        public string? cod_deposito { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }

        public LinxMotivoDevolucao()
        {
        }

        public LinxMotivoDevolucao(string? cod_motivo, string? portal, string? descricao_motivo, string? cod_deposito, string? ativo, string? timestamp)
        {
            this.cod_motivo = cod_motivo;
            this.portal = portal;
            this.descricao_motivo = descricao_motivo;
            this.cod_deposito = cod_deposito;
            this.ativo = ativo;
            this.timestamp = timestamp;
        }
    }
}
