using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxProdutosFornec", Schema = "linx_microvix_erp")]
    public class LinxProdutosFornec
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_prod_forn { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_fornecedor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? custo { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "moeda")]
        public string? moeda { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "unidade_compra")]
        public string? unidade_compra { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? fator_conversao_compra { get; private set; }

        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "codauxiliar")]
        public string? codauxiliar { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? qtde_embalagem { get; private set; }

        [Column(TypeName = "int")]
        public Int32? prazo_entrega_padrao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto2 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto3 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? desconto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ipi1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? diferencial_icms { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? despesas1 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? acrescimo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor_custo_substituicao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? frete1 { get; private set; }

        [Column(TypeName = "varchar(1)")]
        [LengthValidation(length: 1, propertyName: "fornecedor_principal")]
        public string? fornecedor_principal { get; private set; }

        [Column(TypeName = "varchar(1)")]
        [LengthValidation(length: 1, propertyName: "excluido")]
        public string? excluido { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxProdutosFornec() { }

        public LinxProdutosFornec(
            List<ValidationResult> listValidations,
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
            lastupdateon = DateTime.Now;

            this.id_prod_forn =
                ConvertToInt32Validation.IsValid(id_prod_forn, "id_prod_forn", listValidations) ?
                Convert.ToInt32(id_prod_forn) :
                0;

            this.cod_fornecedor =
                ConvertToInt32Validation.IsValid(cod_fornecedor, "cod_fornecedor", listValidations) ?
                Convert.ToInt32(cod_fornecedor) :
                0;

            this.prazo_entrega_padrao =
                ConvertToInt32Validation.IsValid(prazo_entrega_padrao, "prazo_entrega_padrao", listValidations) ?
                Convert.ToInt32(prazo_entrega_padrao) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.custo =
                ConvertToDecimalValidation.IsValid(custo, "custo", listValidations) ?
                Convert.ToDecimal(custo, new CultureInfo("en-US")) :
                0;

            this.fator_conversao_compra =
                ConvertToDecimalValidation.IsValid(fator_conversao_compra, "fator_conversao_compra", listValidations) ?
                Convert.ToDecimal(fator_conversao_compra, new CultureInfo("en-US")) :
                0;

            this.qtde_embalagem =
                ConvertToDecimalValidation.IsValid(qtde_embalagem, "qtde_embalagem", listValidations) ?
                Convert.ToDecimal(qtde_embalagem, new CultureInfo("en-US")) :
                0;

            this.desconto1 =
                ConvertToDecimalValidation.IsValid(desconto1, "desconto1", listValidations) ?
                Convert.ToDecimal(desconto1, new CultureInfo("en-US")) :
                0;

            this.desconto2 =
                ConvertToDecimalValidation.IsValid(desconto2, "desconto2", listValidations) ?
                Convert.ToDecimal(desconto2, new CultureInfo("en-US")) :
                0;

            this.desconto3 =
                ConvertToDecimalValidation.IsValid(desconto3, "desconto3", listValidations) ?
                Convert.ToDecimal(desconto3, new CultureInfo("en-US")) :
                0;

            this.desconto =
                ConvertToDecimalValidation.IsValid(desconto, "desconto", listValidations) ?
                Convert.ToDecimal(desconto, new CultureInfo("en-US")) :
                0;

            this.ipi1 =
                ConvertToDecimalValidation.IsValid(ipi1, "ipi1", listValidations) ?
                Convert.ToDecimal(ipi1, new CultureInfo("en-US")) :
                0;

            this.diferencial_icms =
                ConvertToDecimalValidation.IsValid(diferencial_icms, "diferencial_icms", listValidations) ?
                Convert.ToDecimal(diferencial_icms, new CultureInfo("en-US")) :
                0;

            this.despesas1 =
                ConvertToDecimalValidation.IsValid(despesas1, "despesas1", listValidations) ?
                Convert.ToDecimal(despesas1, new CultureInfo("en-US")) :
                0;

            this.acrescimo =
                ConvertToDecimalValidation.IsValid(acrescimo, "acrescimo", listValidations) ?
                Convert.ToDecimal(acrescimo, new CultureInfo("en-US")) :
                0;

            this.valor_custo_substituicao =
                ConvertToDecimalValidation.IsValid(valor_custo_substituicao, "valor_custo_substituicao", listValidations) ?
                Convert.ToDecimal(valor_custo_substituicao, new CultureInfo("en-US")) :
                0;

            this.frete1 =
                ConvertToDecimalValidation.IsValid(frete1, "frete1", listValidations) ?
                Convert.ToDecimal(frete1, new CultureInfo("en-US")) :
                0;

            this.moeda = moeda;
            this.unidade_compra = unidade_compra;
            this.codauxiliar = codauxiliar;
            this.fornecedor_principal = fornecedor_principal;
            this.excluido = excluido;
        }
    }
}
