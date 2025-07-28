namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaClientesEnderecosEntrega
    {
        public string? id_endereco_entrega { get; set; }
        public string? cod_cliente_erp { get; set; }
        public string? cod_cliente_b2c { get; set; }
        public string? endereco_cliente { get; set; }
        public string? numero_rua_cliente { get; set; }
        public string? complemento_end_cli { get; set; }
        public string? cep_cliente { get; set; }
        public string? bairro_cliente { get; set; }
        public string? cidade_cliente { get; set; }
        public string? uf_cliente { get; set; }
        public string? descricao { get; set; }
        public string? principal { get; set; }
        public string? id_cidade { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
