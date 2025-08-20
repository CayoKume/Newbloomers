namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaClassificacao
    {
        public string? codigo_classificacao { get; private set; }
        public string? nome_classificacao { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaClassificacao() { }

        public B2CConsultaClassificacao(
            string? codigo_classificacao,
            string? nome_classificacao,
            string? timestamp,
            string? portal
        )
        {
            this.codigo_classificacao = codigo_classificacao;
            this.nome_classificacao = nome_classificacao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}