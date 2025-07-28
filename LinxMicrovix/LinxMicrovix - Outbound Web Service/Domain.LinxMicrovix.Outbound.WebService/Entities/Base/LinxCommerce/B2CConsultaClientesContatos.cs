namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaClientesContatos
    {
        public string? id_clientes_contatos { get; set; }
        public string? id_contato_b2c { get; set; }
        public string? nome_contato { get; set; }
        public string? data_nasc_contato { get; set; }
        public string? sexo_contato { get; set; }
        public string? id_parentesco { get; set; }
        public string? fone_contato { get; set; }
        public string? celular_contato { get; set; }
        public string? email_contato { get; set; }
        public string? cod_cliente_erp { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
