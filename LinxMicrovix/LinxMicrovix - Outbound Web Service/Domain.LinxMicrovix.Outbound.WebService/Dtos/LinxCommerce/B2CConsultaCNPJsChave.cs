namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaCNPJsChave
    {
        public string? cnpj { get; private set; }
        public string? nome_empresa { get; private set; }
        public string? id_empresas_rede { get; private set; }
        public string? rede { get; private set; }
        public string? portal { get; private set; }
        public string? nome_portal { get; private set; }
        public string? empresa { get; private set; }
        public string? classificacao_portal { get; private set; }
        public string? b2c { get; private set; }
        public string? oms { get; private set; }

        public B2CConsultaCNPJsChave() { }

        public B2CConsultaCNPJsChave(
            string? cnpj,
            string? nome_empresa,
            string? id_empresas_rede,
            string? rede,
            string? portal,
            string? nome_portal,
            string? empresa,
            string? classificacao_portal,
            string? b2c,
            string? oms
        )
        {
            this.cnpj = cnpj;
            this.nome_empresa = nome_empresa;
            this.id_empresas_rede = id_empresas_rede;
            this.rede = rede;
            this.portal = portal;
            this.nome_portal = nome_portal;
            this.empresa = empresa;
            this.classificacao_portal = classificacao_portal;
            this.b2c = b2c;
            this.oms = oms;
        }
    }
}