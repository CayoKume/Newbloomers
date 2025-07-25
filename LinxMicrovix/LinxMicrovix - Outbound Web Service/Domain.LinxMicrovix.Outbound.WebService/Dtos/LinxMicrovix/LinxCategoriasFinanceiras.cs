namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCategoriasFinanceiras
    {
        public string? codigo_categoria { get; set; }
        public string? nome_categoria { get; set; }
        public string? tipo_categoria { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCategoriasFinanceiras() { }

        public LinxCategoriasFinanceiras(string? codigo_categoria, string? nome_categoria, string? tipo_categoria, string? timestamp, string? portal)
        {
            this.codigo_categoria = codigo_categoria;
            this.nome_categoria = nome_categoria;
            this.tipo_categoria = tipo_categoria;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}