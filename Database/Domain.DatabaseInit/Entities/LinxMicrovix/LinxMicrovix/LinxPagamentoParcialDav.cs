using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxPagamentoParcialDav", Schema = "untreated")]
    public class LinxPagamentoParcialDav
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_pagamento_parcial_tmp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_vendas_pos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? valor { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ajuste_valor_desc_acresc_plano { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? plano { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "forma_pgto")]
        public string? forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_bandeira { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtde_parcelas { get; private set; }

        [Column(TypeName = "varchar(1)")]
        [LengthValidation(length: 1, propertyName: "credito_debito")]
        public string? credito_debito { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public LinxPagamentoParcialDav() { }

        public LinxPagamentoParcialDav(
            List<ValidationResult> listValidations,
            string? id_pagamento_parcial_tmp,
            string? id_vendas_pos,
            string? valor,
            string? ajuste_valor_desc_acresc_plano,
            string? timestamp,
            string? plano,
            string? forma_pgto,
            string? id_bandeira,
            string? qtde_parcelas,
            string? credito_debito,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_vendas_pos =
                ConvertToInt32Validation.IsValid(id_vendas_pos, "id_vendas_pos", listValidations) ?
                Convert.ToInt32(id_vendas_pos) :
                0;

            this.id_pagamento_parcial_tmp =
                ConvertToInt32Validation.IsValid(id_pagamento_parcial_tmp, "id_pagamento_parcial_tmp", listValidations) ?
                Convert.ToInt32(id_pagamento_parcial_tmp) :
                0;

            this.plano =
                ConvertToInt32Validation.IsValid(plano, "plano", listValidations) ?
                Convert.ToInt32(plano) :
                0;

            this.id_bandeira =
                ConvertToInt32Validation.IsValid(id_bandeira, "id_bandeira", listValidations) ?
                Convert.ToInt32(id_bandeira) :
                0;

            this.qtde_parcelas =
                ConvertToInt32Validation.IsValid(qtde_parcelas, "qtde_parcelas", listValidations) ?
                Convert.ToInt32(qtde_parcelas) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.valor =
                ConvertToDecimalValidation.IsValid(valor, "valor", listValidations) ?
                Convert.ToDecimal(valor) :
                0;

            this.ajuste_valor_desc_acresc_plano =
                ConvertToDecimalValidation.IsValid(ajuste_valor_desc_acresc_plano, "ajuste_valor_desc_acresc_plano", listValidations) ?
                Convert.ToDecimal(ajuste_valor_desc_acresc_plano) :
                0;

            this.forma_pgto = forma_pgto;
            this.credito_debito = credito_debito;
        }
    }
}
