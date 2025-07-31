namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLinhas
    {
        public string? id_linha { get; set; }
        public string? desc_linha { get; set; }
        public string? timestamp { get; set; }
        public string? codigo_integracao_ws { get; set; }
        public string? portal { get; set; }
        public string? coeficiente_comissao { get; set; }

        public LinxLinhas()
        {
        }

        public LinxLinhas(string? id_linha, string? desc_linha, string? timestamp, string? codigo_integracao_ws, string? portal, string? coeficiente_comissao)
        {
            this.id_linha = id_linha;
            this.desc_linha = desc_linha;
            this.timestamp = timestamp;
            this.codigo_integracao_ws = codigo_integracao_ws;
            this.portal = portal;
            this.coeficiente_comissao = coeficiente_comissao;
        }
    }
}
