namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxListaDaVez
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

        public LinxListaDaVez()
        {
        }

        public LinxListaDaVez(string? portal, string? cnpj_emp, string? cod_vendedor, string? data, string? motivo_nao_venda, string? qtde_ocorrencias, string? data_hora_ini_atend, string? data_hora_fim_atend, string? obs, string? desc_produto_neg, string? valor_produto_neg)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.cod_vendedor = cod_vendedor;
            this.data = data;
            this.motivo_nao_venda = motivo_nao_venda;
            this.qtde_ocorrencias = qtde_ocorrencias;
            this.data_hora_ini_atend = data_hora_ini_atend;
            this.data_hora_fim_atend = data_hora_fim_atend;
            this.obs = obs;
            this.desc_produto_neg = desc_produto_neg;
            this.valor_produto_neg = valor_produto_neg;
        }
    }
}
