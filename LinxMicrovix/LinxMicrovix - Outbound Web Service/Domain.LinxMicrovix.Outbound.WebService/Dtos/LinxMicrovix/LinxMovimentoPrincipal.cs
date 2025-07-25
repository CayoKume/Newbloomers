namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoPrincipal
    {
        public string? id_movimento_principal { get; set; }
        public string? id_movimento { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? valor_unitario { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoPrincipal()
        {
        }

        public LinxMovimentoPrincipal(
            string? id_movimento_principal,
            string? id_movimento,
            string? codigoproduto,
            string? quantidade,
            string? valor_unitario,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_principal = id_movimento_principal;
            this.id_movimento = id_movimento;
            this.codigoproduto = codigoproduto;
            this.quantidade = quantidade;
            this.valor_unitario = valor_unitario;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}