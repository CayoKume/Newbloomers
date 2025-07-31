namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClasseFiscal
    {
        public string? portal { get; set; }
        public string? id_classe_fiscal { get; set; }
        public string? descricao { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }

        public LinxClasseFiscal()
        {
        }

        public LinxClasseFiscal(string? portal, string? id_classe_fiscal, string? descricao, string? excluido, string? timestamp)
        {
            this.portal = portal;
            this.id_classe_fiscal = id_classe_fiscal;
            this.descricao = descricao;
            this.excluido = excluido;
            this.timestamp = timestamp;
        }
    }
}
