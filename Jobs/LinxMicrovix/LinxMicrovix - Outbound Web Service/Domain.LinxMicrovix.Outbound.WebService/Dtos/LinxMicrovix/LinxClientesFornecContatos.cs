namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxClientesFornecContatos
    {
        public string? portal { get; set; }
        public string? cod_cliente { get; set; }
        public string? nome_contato { get; set; }
        public string? sexo_contato { get; set; }
        public string? contatos_clientes_parentesco { get; set; }
        public string? fone1_contato { get; set; }
        public string? fone2_contato { get; set; }
        public string? celular_contato { get; set; }
        public string? email_contato { get; set; }
        public string? data_nasc_contato { get; set; }
        public string? tipo_contato { get; set; }

        public LinxClientesFornecContatos()
        {
        }

        public LinxClientesFornecContatos(string? portal, string? cod_cliente, string? nome_contato, string? sexo_contato, string? contatos_clientes_parentesco, string? fone1_contato, string? fone2_contato, string? celular_contato, string? email_contato, string? data_nasc_contato, string? tipo_contato)
        {
            this.portal = portal;
            this.cod_cliente = cod_cliente;
            this.nome_contato = nome_contato;
            this.sexo_contato = sexo_contato;
            this.contatos_clientes_parentesco = contatos_clientes_parentesco;
            this.fone1_contato = fone1_contato;
            this.fone2_contato = fone2_contato;
            this.celular_contato = celular_contato;
            this.email_contato = email_contato;
            this.data_nasc_contato = data_nasc_contato;
            this.tipo_contato = tipo_contato;
        }
    }
}
