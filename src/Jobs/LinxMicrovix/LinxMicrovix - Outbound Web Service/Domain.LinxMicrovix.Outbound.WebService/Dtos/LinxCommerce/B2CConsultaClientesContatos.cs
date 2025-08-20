namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce
{
    public class B2CConsultaClientesContatos
    {
        public string? id_clientes_contatos { get; private set; }
        public string? id_contato_b2c { get; private set; }
        public string? nome_contato { get; private set; }
        public string? data_nasc_contato { get; private set; }
        public string? sexo_contato { get; private set; }
        public string? id_parentesco { get; private set; }
        public string? fone_contato { get; private set; }
        public string? celular_contato { get; private set; }
        public string? email_contato { get; private set; }
        public string? cod_cliente_erp { get; private set; }
        public string? timestamp { get; private set; }
        public string? portal { get; private set; }

        public B2CConsultaClientesContatos() { }

        public B2CConsultaClientesContatos(
            string? id_clientes_contatos,
            string? id_contato_b2c,
            string? nome_contato,
            string? data_nasc_contato,
            string? sexo_contato,
            string? id_parentesco,
            string? fone_contato,
            string? celular_contato,
            string? email_contato,
            string? cod_cliente_erp,
            string? timestamp,
            string? portal
        )
        {
            this.id_clientes_contatos = id_clientes_contatos;
            this.id_contato_b2c = id_contato_b2c;
            this.nome_contato = nome_contato;
            this.data_nasc_contato = data_nasc_contato;
            this.sexo_contato = sexo_contato;
            this.id_parentesco = id_parentesco;
            this.fone_contato = fone_contato;
            this.celular_contato = celular_contato;
            this.email_contato = email_contato;
            this.cod_cliente_erp = cod_cliente_erp;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}