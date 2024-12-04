using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxProdutosDetalhes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }
        
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int64? cod_produto { get; private set; }
        
        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "cod_barra")]
        public string? cod_barra { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? quantidade { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? preco_custo { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? preco_venda { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? custo_medio { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? id_config_tributaria { get; private set; }
        
        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "desc_config_tributaria")]
        public string? desc_config_tributaria { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? despesas1 { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? qtde_minima { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? qtde_maxima { get; private set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? ipi { get; private set; }
        
        [Column(TypeName = "int")]
        public Int64? timestamp { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        public LinxProdutosDetalhes() { }

        public LinxProdutosDetalhes(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? cod_produto,
            string? cod_barra,
            string? quantidade,
            string? preco_custo,
            string? preco_venda,
            string? custo_medio,
            string? id_config_tributaria,
            string? desc_config_tributaria,
            string? despesas1,
            string? qtde_minima,
            string? qtde_maxima,
            string? ipi,
            string? timestamp,
            string? empresa
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.id_config_tributaria =
                ConvertToInt32Validation.IsValid(id_config_tributaria, "id_config_tributaria", listValidations) ?
                Convert.ToInt32(id_config_tributaria) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.cod_produto =
                ConvertToInt64Validation.IsValid(cod_produto, "cod_produto", listValidations) ?
                Convert.ToInt64(cod_produto) :
                0;

            this.quantidade =
                ConvertToDecimalValidation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToDecimal(quantidade) :
                0;

            this.preco_custo =
                ConvertToDecimalValidation.IsValid(preco_custo, "preco_custo", listValidations) ?
                Convert.ToDecimal(preco_custo) :
                0;

            this.preco_venda =
                ConvertToDecimalValidation.IsValid(preco_venda, "preco_venda", listValidations) ?
                Convert.ToDecimal(preco_venda) :
                0;

            this.custo_medio =
                ConvertToDecimalValidation.IsValid(custo_medio, "custo_medio", listValidations) ?
                Convert.ToDecimal(custo_medio) :
                0;

            this.despesas1 =
                ConvertToDecimalValidation.IsValid(despesas1, "despesas1", listValidations) ?
                Convert.ToDecimal(despesas1) :
                0;

            this.qtde_minima =
                ConvertToDecimalValidation.IsValid(qtde_minima, "qtde_minima", listValidations) ?
                Convert.ToDecimal(qtde_minima) :
                0;

            this.qtde_maxima =
                ConvertToDecimalValidation.IsValid(qtde_maxima, "qtde_maxima", listValidations) ?
                Convert.ToDecimal(qtde_maxima) :
                0;

            this.ipi =
                ConvertToDecimalValidation.IsValid(ipi, "ipi", listValidations) ?
                Convert.ToDecimal(ipi) :
                0;

            this.cnpj_emp = cnpj_emp;
            this.cod_barra = cod_barra;
            this.desc_config_tributaria = desc_config_tributaria;
        }
    }
}
