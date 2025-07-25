namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxCupomDesconto
    {
        public string? id_cupom_desconto { get; set; }
        public string? codigo_cupom { get; set; }
        public string? tipo_cupom { get; set; }
        public string? valor_desconto { get; set; }
        public string? percentual_desconto { get; set; }
        public string? data_validade { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxCupomDesconto() { }

        public LinxCupomDesconto(string? id_cupom_desconto, string? codigo_cupom, string? tipo_cupom, string? valor_desconto, string? percentual_desconto, string? data_validade, string? ativo, string? timestamp, string? portal)
        {
            this.id_cupom_desconto = id_cupom_desconto;
            this.codigo_cupom = codigo_cupom;
            this.tipo_cupom = tipo_cupom;
            this.valor_desconto = valor_desconto;
            this.percentual_desconto = percentual_desconto;
            this.data_validade = data_validade;
            this.ativo = ativo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}