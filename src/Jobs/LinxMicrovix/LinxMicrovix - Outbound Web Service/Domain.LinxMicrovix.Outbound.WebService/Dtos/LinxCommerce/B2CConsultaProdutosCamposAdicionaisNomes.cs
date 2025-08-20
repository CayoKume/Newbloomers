namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomes
    {
        public string? id_campo { get; private set; }
        public string? ordem { get; private set; }
        public string? legenda { get; private set; }
        public string? tipo { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisNomes() { }

        public B2CConsultaProdutosCamposAdicionaisNomes(
            string? id_campo,
            string? ordem,
            string? legenda,
            string? tipo,
            string? timestamp,
            string? portal
        )
        {
            this.id_campo = id_campo;
            this.ordem = ordem;
            this.legenda = legenda;
            this.tipo = tipo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}