namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDadosOpticosDav
    {
        public string? id_dados_opticos_dav { get; set; }
        public string? id_dav { get; set; }
        public string? id_receita { get; set; }
        public string? id_posicao_os_ramo_optico { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxDadosOpticosDav() { }

        public LinxDadosOpticosDav(string? id_dados_opticos_dav, string? id_dav, string? id_receita, string? id_posicao_os_ramo_optico, string? timestamp, string? portal)
        {
            this.id_dados_opticos_dav = id_dados_opticos_dav;
            this.id_dav = id_dav;
            this.id_receita = id_receita;
            this.id_posicao_os_ramo_optico = id_posicao_os_ramo_optico;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}