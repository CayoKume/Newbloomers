namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaLinhas
    {
        public string? codigo_linha { get; private set; }
        public string? nome_linha { get; private set; }
        public string? timestamp { get; private set; }
        public string? setores { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaLinhas() { }

        public B2CConsultaLinhas(
            string? codigo_linha,
            string? nome_linha,
            string? timestamp,
            string? setores,
            string? portal
        )
        {
            this.codigo_linha = codigo_linha;
            this.nome_linha = nome_linha;
            this.timestamp = timestamp;
            this.setores = setores;
            this.portal = portal;
        }
    }
}