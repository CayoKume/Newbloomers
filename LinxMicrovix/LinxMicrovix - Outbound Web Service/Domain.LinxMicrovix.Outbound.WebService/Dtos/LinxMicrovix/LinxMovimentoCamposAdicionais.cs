namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoCamposAdicionais
    {
        public string? id_movimento_campo_adicional { get; set; }
        public string? id_movimento { get; set; }
        public string? id_campo_detalhe { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoCamposAdicionais() { }

        public LinxMovimentoCamposAdicionais(string? id_movimento_campo_adicional, string? id_movimento, string? id_campo_detalhe, string? timestamp, string? portal)
        {
            this.id_movimento_campo_adicional = id_movimento_campo_adicional;
            this.id_movimento = id_movimento;
            this.id_campo_detalhe = id_campo_detalhe;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}