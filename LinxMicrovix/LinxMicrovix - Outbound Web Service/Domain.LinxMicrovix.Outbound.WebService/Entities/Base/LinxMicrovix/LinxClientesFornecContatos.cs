namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxClientesFornecContatos
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
    }
}
