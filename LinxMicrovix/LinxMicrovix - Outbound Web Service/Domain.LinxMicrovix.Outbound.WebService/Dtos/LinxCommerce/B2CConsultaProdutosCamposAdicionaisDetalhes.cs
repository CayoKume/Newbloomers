namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhes
    {
        public string? id_campo_detalhe { get; private set; }
        public string? ordem { get; private set; }
        public string? descricao { get; private set; }
        public string? id_campo { get; private set; }
        public string? ativo { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisDetalhes() { }

        public B2CConsultaProdutosCamposAdicionaisDetalhes(
            string? id_campo_detalhe,
            string? ordem,
            string? descricao,
            string? id_campo,
            string? ativo,
            string? timestamp,
            string? portal
        )
        {
            this.id_campo_detalhe = id_campo_detalhe;
            this.ordem = ordem;
            this.descricao = descricao;
            this.id_campo = id_campo;
            this.ativo = ativo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}