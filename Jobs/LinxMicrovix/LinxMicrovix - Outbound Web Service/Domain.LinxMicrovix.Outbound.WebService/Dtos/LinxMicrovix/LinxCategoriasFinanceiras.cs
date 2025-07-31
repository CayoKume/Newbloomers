namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCategoriasFinanceiras
    {
        public string? id_categorias_financeiras { get; set; }
        public string? descricao { get; set; }
        public string? ativo { get; set; }
        public string? historico { get; set; }
        public string? timestamp { get; set; }

        public LinxCategoriasFinanceiras()
        {
        }

        public LinxCategoriasFinanceiras(string? id_categorias_financeiras, string? descricao, string? ativo, string? historico, string? timestamp)
        {
            this.id_categorias_financeiras = id_categorias_financeiras;
            this.descricao = descricao;
            this.ativo = ativo;
            this.historico = historico;
            this.timestamp = timestamp;
        }
    }
}
