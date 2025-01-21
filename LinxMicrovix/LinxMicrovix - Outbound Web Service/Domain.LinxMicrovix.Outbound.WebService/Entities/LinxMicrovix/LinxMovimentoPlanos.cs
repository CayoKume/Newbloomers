using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxMovimentoPlanos", Schema = "linx_microvix_erp")]
    public class LinxMovimentoPlanos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "cnpj_emp")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid? identificador { get; private set; }

        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "varchar(35)")]
        [LengthValidation(length: 35, propertyName: "desc_plano")]
        public string? desc_plano { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_parcelas { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? indice_plano { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_forma_pgto { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "forma_pgto")]
        public string? forma_pgto { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_transacao")]
        public string? tipo_transacao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? taxa_financeira { get; private set; }

        [Column(TypeName = "int")]
        public Int32? ordem_cartao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        public LinxMovimentoPlanos() { }

        public LinxMovimentoPlanos(
            List<ValidationResult> listValidations,
            string? portal,
            string? cnpj_emp,
            string? identificador,
            string? plano,
            string? desc_plano,
            string? total,
            string? qtde_parcelas,
            string? indice_plano,
            string? cod_forma_pgto,
            string? forma_pgto,
            string? tipo_transacao,
            string? taxa_financeira,
            string? ordem_cartao,
            string? timestamp,
            string? empresa
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.qtde_parcelas =
                ConvertToInt32Validation.IsValid(qtde_parcelas, "qtde_parcelas", listValidations) ?
                Convert.ToInt32(qtde_parcelas) :
                0;

            this.cod_forma_pgto =
                ConvertToInt32Validation.IsValid(cod_forma_pgto, "cod_forma_pgto", listValidations) ?
                Convert.ToInt32(cod_forma_pgto) :
                0;

            this.ordem_cartao =
                ConvertToInt32Validation.IsValid(ordem_cartao, "ordem_cartao", listValidations) ?
                Convert.ToInt32(ordem_cartao) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.total =
                ConvertToDecimalValidation.IsValid(total, "total", listValidations) ?
                Convert.ToDecimal(total) :
                0;

            this.indice_plano =
                ConvertToDecimalValidation.IsValid(indice_plano, "indice_plano", listValidations) ?
                Convert.ToDecimal(indice_plano) :
                0;

            this.taxa_financeira =
                ConvertToDecimalValidation.IsValid(taxa_financeira, "taxa_financeira", listValidations) ?
                Convert.ToDecimal(taxa_financeira) :
                0;

            this.identificador =
                String.IsNullOrEmpty(identificador) ? null
                : Guid.Parse(identificador);

            this.tipo_transacao = tipo_transacao;
            this.desc_plano = desc_plano;
            this.cnpj_emp = cnpj_emp;
        }
    }
}
