namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxSpedTipoItem
    {
        public string? id_sped_tipo_item { get; set; }
        public string? descricao { get; set; }
        public string? timestamp { get; set; }
        public string? codigo { get; set; }
        public string? portal { get; set; }

        public LinxSpedTipoItem() { }

        public LinxSpedTipoItem(
            string? id_sped_tipo_item,
            string? descricao,
            string? timestamp,
            string? codigo,
            string? portal
        )
        {
            this.id_sped_tipo_item = id_sped_tipo_item;
            this.descricao = descricao;
            this.timestamp = timestamp;
            this.codigo = codigo;
            this.portal = portal;
        }
    }
}