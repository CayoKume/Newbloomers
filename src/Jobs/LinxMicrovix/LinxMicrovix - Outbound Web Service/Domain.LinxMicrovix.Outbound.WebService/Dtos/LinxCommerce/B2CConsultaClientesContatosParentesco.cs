namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaClientesContatosParentesco
    {
        public string? id_parentesco { get; private set; }
        public string? descricao_parentesco { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaClientesContatosParentesco() { }

        public B2CConsultaClientesContatosParentesco(
            string? id_parentesco,
            string? descricao_parentesco,
            string? timestamp,
            string? portal
        )
        {
            this.id_parentesco = id_parentesco;
            this.descricao_parentesco = descricao_parentesco;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}