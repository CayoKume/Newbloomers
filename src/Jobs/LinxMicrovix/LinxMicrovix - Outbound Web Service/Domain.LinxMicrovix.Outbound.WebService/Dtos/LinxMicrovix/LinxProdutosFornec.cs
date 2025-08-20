

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxProdutosFornec
    {
        public string? id_prod_forn { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? cod_fornecedor { get; private set; }
        public string? custo { get; private set; }
        public string? moeda { get; private set; }
        public string? unidade_compra { get; private set; }
        public string? fator_conversao_compra { get; private set; }
        public string? codauxiliar { get; private set; }
        public string? qtde_embalagem { get; private set; }
        public string? prazo_entrega_padrao { get; private set; }
        public string? empresa { get; private set; }
        public string? desconto1 { get; private set; }
        public string? desconto2 { get; private set; }
        public string? desconto3 { get; private set; }
        public string? desconto { get; private set; }
        public string? ipi1 { get; private set; }
        public string? diferencial_icms { get; private set; }
        public string? despesas1 { get; private set; }
        public string? acrescimo { get; private set; }
        public string? valor_custo_substituicao { get; private set; }
        public string? frete1 { get; private set; }
        public string? fornecedor_principal { get; private set; }
        public string? excluido { get; private set; }
        public string? timestamp { get; private set; }

        public LinxProdutosFornec() { }

        public LinxProdutosFornec(
            string? id_prod_forn,
            string? codigoproduto,
            string? cod_fornecedor,
            string? custo,
            string? moeda,
            string? unidade_compra,
            string? fator_conversao_compra,
            string? codauxiliar,
            string? qtde_embalagem,
            string? prazo_entrega_padrao,
            string? empresa,
            string? desconto1,
            string? desconto2,
            string? desconto3,
            string? desconto,
            string? ipi1,
            string? diferencial_icms,
            string? despesas1,
            string? acrescimo,
            string? valor_custo_substituicao,
            string? frete1,
            string? fornecedor_principal,
            string? excluido,
            string? timestamp
        )
        {
            this.id_prod_forn = id_prod_forn;
            this.codigoproduto = codigoproduto;
            this.cod_fornecedor = cod_fornecedor;
            this.custo = custo;
            this.moeda = moeda;
            this.unidade_compra = unidade_compra;
            this.fator_conversao_compra = fator_conversao_compra;
            this.codauxiliar = codauxiliar;
            this.qtde_embalagem = qtde_embalagem;
            this.prazo_entrega_padrao = prazo_entrega_padrao;
            this.empresa = empresa;
            this.desconto1 = desconto1;
            this.desconto2 = desconto2;
            this.desconto3 = desconto3;
            this.desconto = desconto;
            this.ipi1 = ipi1;
            this.diferencial_icms = diferencial_icms;
            this.despesas1 = despesas1;
            this.acrescimo = acrescimo;
            this.valor_custo_substituicao = valor_custo_substituicao;
            this.frete1 = frete1;
            this.fornecedor_principal = fornecedor_principal;
            this.excluido = excluido;
            this.timestamp = timestamp;
        }
    }
}