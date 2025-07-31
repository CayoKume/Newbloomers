namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxCupomDesconto
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
    }
}
