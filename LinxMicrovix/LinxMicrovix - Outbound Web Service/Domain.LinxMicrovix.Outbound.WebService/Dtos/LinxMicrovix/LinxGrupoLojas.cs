namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxGrupoLojas
    {
        public string? id_grupo_lojas { get; set; }
        public string? nome_grupo_lojas { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxGrupoLojas() { }

        public LinxGrupoLojas(string? id_grupo_lojas, string? nome_grupo_lojas, string? timestamp, string? portal)
        {
            this.id_grupo_lojas = id_grupo_lojas;
            this.nome_grupo_lojas = nome_grupo_lojas;
            this.timestamp = timestamp;
            this.portal = portal;
        }

    }
}