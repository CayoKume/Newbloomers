namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaSetores
    {
        public string? codigo_setor { get; private set; }
        public string? nome_setor { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaSetores() { }

        public B2CConsultaSetores(string? codigo_setor, string? nome_setor, string? timestamp, string? portal)
        {
            this.codigo_setor = codigo_setor;
            this.nome_setor = nome_setor;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}