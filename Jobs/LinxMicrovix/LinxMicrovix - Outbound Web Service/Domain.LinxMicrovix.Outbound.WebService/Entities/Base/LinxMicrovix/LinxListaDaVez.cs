namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxListaDaVez
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? cod_vendedor { get; set; }
        public string? data { get; set; }
        public string? motivo_nao_venda { get; set; }
        public string? qtde_ocorrencias { get; set; }
        public string? data_hora_ini_atend { get; set; }
        public string? data_hora_fim_atend { get; set; }
        public string? obs { get; set; }
        public string? desc_produto_neg { get; set; }
        public string? valor_produto_neg { get; set; }
    }
}
