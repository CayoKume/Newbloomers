namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCupomDesconto
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? id_cupom_desconto { get; set; }
        public string? cupom { get; set; }
        public string? descricao { get; set; }
        public string? percentual_desconto { get; set; }
        public string? data_inicial_vigencia { get; set; }
        public string? data_final_vigencia { get; set; }
        public string? qtde_original { get; set; }
        public string? qtde_disponivel { get; set; }
        public string? cod_vendedor { get; set; }
        public string? disponivel { get; set; }
        public string? timestamp { get; set; }

        public LinxCupomDesconto()
        {
        }

        public LinxCupomDesconto(string? portal, string? empresa, string? id_cupom_desconto, string? cupom, string? descricao, string? percentual_desconto, string? data_inicial_vigencia, string? data_final_vigencia, string? qtde_original, string? qtde_disponivel, string? cod_vendedor, string? disponivel, string? timestamp)
        {
            this.portal = portal;
            this.empresa = empresa;
            this.id_cupom_desconto = id_cupom_desconto;
            this.cupom = cupom;
            this.descricao = descricao;
            this.percentual_desconto = percentual_desconto;
            this.data_inicial_vigencia = data_inicial_vigencia;
            this.data_final_vigencia = data_final_vigencia;
            this.qtde_original = qtde_original;
            this.qtde_disponivel = qtde_disponivel;
            this.cod_vendedor = cod_vendedor;
            this.disponivel = disponivel;
            this.timestamp = timestamp;
        }
    }
}
