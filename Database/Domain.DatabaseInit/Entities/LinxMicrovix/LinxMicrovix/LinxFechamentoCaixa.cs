using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxFechamentoCaixa", Schema = "untreated")]
    public class LinxFechamentoCaixa
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "bit")]
        public bool? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public bool? conferencia_efetuada { get; private set; }

        [Column(TypeName = "int")]
        public DateTime? data { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "text")]
        public string? obs { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_001 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_005 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_010 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_025 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_050 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_1 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_10 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_100 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_2 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_20 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_200 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_5 { get; private set; }

        [Column(TypeName = "int")]
        public Int32? qtd_50 { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? sangria { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? suprimentos { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_c_prazo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_c_vista { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_cartao { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_cartao_credito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_cartao_debito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_convenio { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_crediario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_geral { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_giftcard { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_link_pagamento { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_link_pagamento_credito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_link_pagamento_debito { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_pix { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_qr_linx { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? total_vale_compra { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "usuario")]
        public string? usuario { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? vale_compras_dev { get; private set; }

        public LinxFechamentoCaixa() { }

        public LinxFechamentoCaixa(
            List<ValidationResult> listValidations,
            string? ativo,
            string? conferencia_efetuada,
            string? data,
            string? empresa,
            string? obs,
            string? timestamp,
            string? qtd_001,
            string? qtd_005,
            string? qtd_010,
            string? qtd_025,
            string? qtd_050,
            string? qtd_1,
            string? qtd_10,
            string? qtd_100,
            string? qtd_2,
            string? qtd_20,
            string? qtd_200,
            string? qtd_5,
            string? qtd_50,
            string? sangria,
            string? suprimentos,
            string? total_c_prazo,
            string? total_c_vista,
            string? total_cartao,
            string? total_cartao_credito,
            string? total_cartao_debito,
            string? total_convenio,
            string? total_crediario,
            string? total_geral,
            string? total_giftcard,
            string? total_link_pagamento,
            string? total_link_pagamento_credito,
            string? total_link_pagamento_debito,
            string? total_pix,
            string? total_qr_linx,
            string? total_vale_compra,
            string? usuario,
            string? vale_compras_dev
        )
        {
            lastupdateon = DateTime.Now;

            this.ativo =
                ConvertToBooleanValidation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToBoolean(ativo) :
                false;

            this.conferencia_efetuada =
                ConvertToBooleanValidation.IsValid(conferencia_efetuada, "conferencia_efetuada", listValidations) ?
                Convert.ToBoolean(conferencia_efetuada) :
                false;

            this.data =
                ConvertToDateTimeValidation.IsValid(data, "data", listValidations) ?
                Convert.ToDateTime(data) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.qtd_001 =
                ConvertToInt32Validation.IsValid(qtd_001, "qtd_001", listValidations) ?
                Convert.ToInt32(qtd_001) :
                0;

            this.qtd_005 =
                ConvertToInt32Validation.IsValid(qtd_005, "qtd_005", listValidations) ?
                Convert.ToInt32(qtd_005) :
                0;

            this.qtd_010 =
                ConvertToInt32Validation.IsValid(qtd_010, "qtd_010", listValidations) ?
                Convert.ToInt32(qtd_010) :
                0;

            this.qtd_025 =
                ConvertToInt32Validation.IsValid(qtd_025, "qtd_025", listValidations) ?
                Convert.ToInt32(qtd_025) :
                0;

            this.qtd_050 =
                ConvertToInt32Validation.IsValid(qtd_050, "qtd_050", listValidations) ?
                Convert.ToInt32(qtd_050) :
                0;

            this.qtd_1 =
                ConvertToInt32Validation.IsValid(qtd_1, "qtd_1", listValidations) ?
                Convert.ToInt32(qtd_1) :
                0;

            this.qtd_10 =
                ConvertToInt32Validation.IsValid(qtd_10, "qtd_10", listValidations) ?
                Convert.ToInt32(qtd_10) :
                0;

            this.qtd_100 =
                ConvertToInt32Validation.IsValid(qtd_100, "qtd_100", listValidations) ?
                Convert.ToInt32(qtd_100) :
                0;

            this.qtd_2 =
                ConvertToInt32Validation.IsValid(qtd_2, "qtd_2", listValidations) ?
                Convert.ToInt32(qtd_2) :
                0;

            this.qtd_20 =
                ConvertToInt32Validation.IsValid(qtd_20, "qtd_20", listValidations) ?
                Convert.ToInt32(qtd_20) :
                0;

            this.qtd_200 =
                ConvertToInt32Validation.IsValid(qtd_200, "qtd_200", listValidations) ?
                Convert.ToInt32(qtd_200) :
                0;

            this.qtd_5 =
                ConvertToInt32Validation.IsValid(qtd_5, "qtd_5", listValidations) ?
                Convert.ToInt32(qtd_5) :
                0;

            this.qtd_50 =
                ConvertToInt32Validation.IsValid(qtd_50, "qtd_50", listValidations) ?
                Convert.ToInt32(qtd_50) :
                0;


            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.sangria =
                ConvertToDecimalValidation.IsValid(sangria, "sangria", listValidations) ?
                Convert.ToDecimal(sangria) :
                0;

            this.suprimentos =
                ConvertToDecimalValidation.IsValid(suprimentos, "suprimentos", listValidations) ?
                Convert.ToDecimal(suprimentos) :
                0;

            this.total_c_prazo =
                ConvertToDecimalValidation.IsValid(total_c_prazo, "total_c_prazo", listValidations) ?
                Convert.ToDecimal(total_c_prazo) :
                0;

            this.total_c_vista =
                ConvertToDecimalValidation.IsValid(total_c_vista, "total_c_vista", listValidations) ?
                Convert.ToDecimal(total_c_vista) :
                0;

            this.total_cartao =
                ConvertToDecimalValidation.IsValid(total_cartao, "total_cartao", listValidations) ?
                Convert.ToDecimal(total_cartao) :
                0;

            this.total_cartao_credito =
                ConvertToDecimalValidation.IsValid(total_cartao_credito, "total_cartao_credito", listValidations) ?
                Convert.ToDecimal(total_cartao_credito) :
                0;

            this.total_cartao_debito =
                ConvertToDecimalValidation.IsValid(total_cartao_debito, "total_cartao_debito", listValidations) ?
                Convert.ToDecimal(total_cartao_debito) :
                0;

            this.total_convenio =
                ConvertToDecimalValidation.IsValid(total_convenio, "total_convenio", listValidations) ?
                Convert.ToDecimal(total_convenio) :
                0;

            this.total_crediario =
                ConvertToDecimalValidation.IsValid(total_crediario, "total_crediario", listValidations) ?
                Convert.ToDecimal(total_crediario) :
                0;

            this.total_geral =
                ConvertToDecimalValidation.IsValid(total_geral, "total_geral", listValidations) ?
                Convert.ToDecimal(total_geral) :
                0;

            this.total_giftcard =
                ConvertToDecimalValidation.IsValid(total_giftcard, "total_giftcard", listValidations) ?
                Convert.ToDecimal(total_giftcard) :
                0;

            this.total_link_pagamento =
                ConvertToDecimalValidation.IsValid(total_link_pagamento, "total_link_pagamento", listValidations) ?
                Convert.ToDecimal(total_link_pagamento) :
                0;

            this.total_link_pagamento_credito =
                ConvertToDecimalValidation.IsValid(total_link_pagamento_credito, "total_link_pagamento_credito", listValidations) ?
                Convert.ToDecimal(total_link_pagamento_credito) :
                0;

            this.total_link_pagamento_debito =
                ConvertToDecimalValidation.IsValid(total_link_pagamento_debito, "total_link_pagamento_debito", listValidations) ?
                Convert.ToDecimal(total_link_pagamento_debito) :
                0;

            this.total_pix =
                ConvertToDecimalValidation.IsValid(total_pix, "total_pix", listValidations) ?
                Convert.ToDecimal(total_pix) :
                0;

            this.total_qr_linx =
                ConvertToDecimalValidation.IsValid(total_qr_linx, "total_qr_linx", listValidations) ?
                Convert.ToDecimal(total_qr_linx) :
                0;

            this.total_vale_compra =
                ConvertToDecimalValidation.IsValid(total_vale_compra, "total_vale_compra", listValidations) ?
                Convert.ToDecimal(total_vale_compra) :
                0;

            this.vale_compras_dev =
                ConvertToDecimalValidation.IsValid(vale_compras_dev, "vale_compras_dev", listValidations) ?
                Convert.ToDecimal(vale_compras_dev) :
                0;

            this.obs = obs;
            this.usuario = usuario;
        }
    }
}
