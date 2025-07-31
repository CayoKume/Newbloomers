namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxUnidades
    {
        public string? idUnidade { get; set; }
        public string? unidade { get; set; }
        public string? timestamp { get; set; }
        public string? descricao { get; set; }

        public LinxUnidades() { }

        public LinxUnidades(
            string? idUnidade,
            string? unidade,
            string? timestamp,
            string? descricao
        )
        {
            this.idUnidade = idUnidade;
            this.unidade = unidade;
            this.timestamp = timestamp;
            this.descricao = descricao;
        }
    }
}