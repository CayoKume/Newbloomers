namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoReshopItens
    {
        public string? id_movimento_campanha_reshop_item { get; set; }
        public string? id_campanha { get; set; }
        public string? identificador { get; set; }
        public string? valor_unitario { get; set; }
        public string? valor_desconto_item { get; set; }
        public string? quantidade { get; set; }
        public string? valor_original { get; set; }
        public string? timestamp { get; set; }
        public string? ordem { get; set; }
    }
}
