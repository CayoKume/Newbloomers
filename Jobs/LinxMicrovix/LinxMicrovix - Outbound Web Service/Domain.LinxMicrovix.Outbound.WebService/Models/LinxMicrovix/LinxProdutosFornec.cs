
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosFornec
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_prod_forn { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? cod_fornecedor { get; private set; }
        public decimal? custo { get; private set; }
        public string? moeda { get; private set; }
        public string? unidade_compra { get; private set; }
        public decimal? fator_conversao_compra { get; private set; }
        public string? codauxiliar { get; private set; }
        public decimal? qtde_embalagem { get; private set; }
        public Int32? prazo_entrega_padrao { get; private set; }
        public Int32? empresa { get; private set; }
        public decimal? desconto1 { get; private set; }
        public decimal? desconto2 { get; private set; }
        public decimal? desconto3 { get; private set; }
        public decimal? desconto { get; private set; }
        public decimal? ipi1 { get; private set; }
        public decimal? diferencial_icms { get; private set; }
        public decimal? despesas1 { get; private set; }
        public decimal? acrescimo { get; private set; }
        public decimal? valor_custo_substituicao { get; private set; }
        public decimal? frete1 { get; private set; }
        public string? fornecedor_principal { get; private set; }
        public string? excluido { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosFornec() { }

        public LinxProdutosFornec(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosFornec record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_prod_forn = CustomConvertersExtensions.ConvertToInt32Validation(record.id_prod_forn);
            this.cod_fornecedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_fornecedor);
            this.prazo_entrega_padrao = CustomConvertersExtensions.ConvertToInt32Validation(record.prazo_entrega_padrao);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.custo = CustomConvertersExtensions.ConvertToDecimalValidation(record.custo);
            this.fator_conversao_compra = CustomConvertersExtensions.ConvertToDecimalValidation(record.fator_conversao_compra);
            this.qtde_embalagem = CustomConvertersExtensions.ConvertToDecimalValidation(record.qtde_embalagem);
            this.desconto1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto1);
            this.desconto2 = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto2);
            this.desconto3 = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto3);
            this.desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.desconto);
            this.ipi1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.ipi1);
            this.diferencial_icms = CustomConvertersExtensions.ConvertToDecimalValidation(record.diferencial_icms);
            this.despesas1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.despesas1);
            this.acrescimo = CustomConvertersExtensions.ConvertToDecimalValidation(record.acrescimo);
            this.valor_custo_substituicao = CustomConvertersExtensions.ConvertToDecimalValidation(record.valor_custo_substituicao);
            this.frete1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.frete1);
            this.moeda = record.moeda;
            this.unidade_compra = record.unidade_compra;
            this.codauxiliar = record.codauxiliar;
            this.fornecedor_principal = record.fornecedor_principal;
            this.excluido = record.excluido;
        }
    }
}
