namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxSubClasses
    {
        public string? id_subclasses { get; set; }
        public string? classe { get; set; }
        public string? timestamp { get; set; }
        public string? descricao { get; set; }

        public LinxSubClasses() { }

        public LinxSubClasses(
            string? id_subclasses,
            string? classe,
            string? timestamp,
            string? descricao
        )
        {
            this.id_subclasses = id_subclasses;
            this.classe = classe;
            this.timestamp = timestamp;
            this.descricao = descricao;
        }
    }
}