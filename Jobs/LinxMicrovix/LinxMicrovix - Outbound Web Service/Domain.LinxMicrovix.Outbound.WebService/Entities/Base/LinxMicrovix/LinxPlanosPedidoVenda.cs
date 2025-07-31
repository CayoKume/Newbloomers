namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxPlanosPedidoVenda
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? cod_pedido { get; set; }
        public string? plano { get; set; }
        public string? desc_plano { get; set; }
        public string? total { get; set; }
        public string? qtde_parcelas { get; set; }
        public string? indice_plano { get; set; }
        public string? valor_desc_acresc_plano { get; set; }
        public string? cod_forma_pgto { get; set; }
        public string? forma_pgto { get; set; }
    }
}
