namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxOrcamentoComponenteFormula
    {
        public string? id_orcamento_componente_formula { get; set; }
        public string? documento { get; set; }
        public string? codigo_produto { get; set; }
        public string? codigo_componente { get; set; }
        public string? descricao_componente { get; set; }
        public string? unidade { get; set; }
        public string? quantidade { get; set; }
        public string? valor_componente { get; set; }
        public string? lote_componente { get; set; }
        public string? data_validade_lote { get; set; }
        public string? codigo_ws { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }
    }
}
