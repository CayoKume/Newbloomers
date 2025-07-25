namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoIndicacoes
    {
        public string? id_movimento_indicacao { get; set; }
        public string? id_movimento { get; set; }
        public string? cod_cliente_indicador { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoIndicacoes()
        {
        }

        public LinxMovimentoIndicacoes(
            string? id_movimento_indicacao,
            string? id_movimento,
            string? cod_cliente_indicador,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_indicacao = id_movimento_indicacao;
            this.id_movimento = id_movimento;
            this.cod_cliente_indicador = cod_cliente_indicador;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}