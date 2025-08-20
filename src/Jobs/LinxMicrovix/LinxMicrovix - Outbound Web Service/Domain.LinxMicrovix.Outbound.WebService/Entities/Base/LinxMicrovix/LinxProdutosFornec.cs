namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosFornec
    {
        public string? id_prod_forn { get; set; }
        public string? codigoproduto { get; set; }
        public string? cod_fornecedor { get; set; }
        public string? custo { get; set; }
        public string? moeda { get; set; }
        public string? unidade_compra { get; set; }
        public string? fator_conversao_compra { get; set; }
        public string? codauxiliar { get; set; }
        public string? qtde_embalagem { get; set; }
        public string? prazo_entrega_padrao { get; set; }
        public string? empresa { get; set; }
        public string? desconto1 { get; set; }
        public string? desconto2 { get; set; }
        public string? desconto3 { get; set; }
        public string? desconto { get; set; }
        public string? ipi1 { get; set; }
        public string? diferencial_icms { get; set; }
        public string? despesas1 { get; set; }
        public string? acrescimo { get; set; }
        public string? valor_custo_substituicao { get; set; }
        public string? frete1 { get; set; }
        public string? fornecedor_principal { get; set; }
        public string? excluido { get; set; }
        public string? timestamp { get; set; }
    }
}
