using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxFechamentoCaixa
    {
        [SkipProperty]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public bool? ativo { get; private set; }

        public bool? conferencia_efetuada { get; private set; }

        public DateTime? data { get; private set; }

        public Int32? empresa { get; private set; }

        public string? obs { get; private set; }

        public Int64? timestamp { get; private set; }

        public Int32? qtd_001 { get; private set; }

        public Int32? qtd_005 { get; private set; }

        public Int32? qtd_010 { get; private set; }

        public Int32? qtd_025 { get; private set; }

        public Int32? qtd_050 { get; private set; }

        public Int32? qtd_1 { get; private set; }

        public Int32? qtd_10 { get; private set; }

        public Int32? qtd_100 { get; private set; }

        public Int32? qtd_2 { get; private set; }

        public Int32? qtd_20 { get; private set; }

        public Int32? qtd_200 { get; private set; }

        public Int32? qtd_5 { get; private set; }

        public Int32? qtd_50 { get; private set; }

        public decimal? sangria { get; private set; }

        public decimal? suprimentos { get; private set; }

        public decimal? total_c_prazo { get; private set; }

        public decimal? total_c_vista { get; private set; }

        public decimal? total_cartao { get; private set; }

        public decimal? total_cartao_credito { get; private set; }

        public decimal? total_cartao_debito { get; private set; }

        public decimal? total_convenio { get; private set; }

        public decimal? total_crediario { get; private set; }

        public decimal? total_geral { get; private set; }

        public decimal? total_giftcard { get; private set; }

        public decimal? total_link_pagamento { get; private set; }

        public decimal? total_link_pagamento_credito { get; private set; }

        public decimal? total_link_pagamento_debito { get; private set; }

        public decimal? total_pix { get; private set; }

        public decimal? total_qr_linx { get; private set; }

        public decimal? total_vale_compra { get; private set; }

        [LengthValidation(length: 10, propertyName: "usuario")]
        public string? usuario { get; private set; }

        public decimal? vale_compras_dev { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

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
                Convert.ToDecimal(sangria, new CultureInfo("en-US")) :
                0;

            this.suprimentos =
                ConvertToDecimalValidation.IsValid(suprimentos, "suprimentos", listValidations) ?
                Convert.ToDecimal(suprimentos, new CultureInfo("en-US")) :
                0;

            this.total_c_prazo =
                ConvertToDecimalValidation.IsValid(total_c_prazo, "total_c_prazo", listValidations) ?
                Convert.ToDecimal(total_c_prazo, new CultureInfo("en-US")) :
                0;

            this.total_c_vista =
                ConvertToDecimalValidation.IsValid(total_c_vista, "total_c_vista", listValidations) ?
                Convert.ToDecimal(total_c_vista, new CultureInfo("en-US")) :
                0;

            this.total_cartao =
                ConvertToDecimalValidation.IsValid(total_cartao, "total_cartao", listValidations) ?
                Convert.ToDecimal(total_cartao, new CultureInfo("en-US")) :
                0;

            this.total_cartao_credito =
                ConvertToDecimalValidation.IsValid(total_cartao_credito, "total_cartao_credito", listValidations) ?
                Convert.ToDecimal(total_cartao_credito, new CultureInfo("en-US")) :
                0;

            this.total_cartao_debito =
                ConvertToDecimalValidation.IsValid(total_cartao_debito, "total_cartao_debito", listValidations) ?
                Convert.ToDecimal(total_cartao_debito, new CultureInfo("en-US")) :
                0;

            this.total_convenio =
                ConvertToDecimalValidation.IsValid(total_convenio, "total_convenio", listValidations) ?
                Convert.ToDecimal(total_convenio, new CultureInfo("en-US")) :
                0;

            this.total_crediario =
                ConvertToDecimalValidation.IsValid(total_crediario, "total_crediario", listValidations) ?
                Convert.ToDecimal(total_crediario, new CultureInfo("en-US")) :
                0;

            this.total_geral =
                ConvertToDecimalValidation.IsValid(total_geral, "total_geral", listValidations) ?
                Convert.ToDecimal(total_geral, new CultureInfo("en-US")) :
                0;

            this.total_giftcard =
                ConvertToDecimalValidation.IsValid(total_giftcard, "total_giftcard", listValidations) ?
                Convert.ToDecimal(total_giftcard, new CultureInfo("en-US")) :
                0;

            this.total_link_pagamento =
                ConvertToDecimalValidation.IsValid(total_link_pagamento, "total_link_pagamento", listValidations) ?
                Convert.ToDecimal(total_link_pagamento, new CultureInfo("en-US")) :
                0;

            this.total_link_pagamento_credito =
                ConvertToDecimalValidation.IsValid(total_link_pagamento_credito, "total_link_pagamento_credito", listValidations) ?
                Convert.ToDecimal(total_link_pagamento_credito, new CultureInfo("en-US")) :
                0;

            this.total_link_pagamento_debito =
                ConvertToDecimalValidation.IsValid(total_link_pagamento_debito, "total_link_pagamento_debito", listValidations) ?
                Convert.ToDecimal(total_link_pagamento_debito, new CultureInfo("en-US")) :
                0;

            this.total_pix =
                ConvertToDecimalValidation.IsValid(total_pix, "total_pix", listValidations) ?
                Convert.ToDecimal(total_pix, new CultureInfo("en-US")) :
                0;

            this.total_qr_linx =
                ConvertToDecimalValidation.IsValid(total_qr_linx, "total_qr_linx", listValidations) ?
                Convert.ToDecimal(total_qr_linx, new CultureInfo("en-US")) :
                0;

            this.total_vale_compra =
                ConvertToDecimalValidation.IsValid(total_vale_compra, "total_vale_compra", listValidations) ?
                Convert.ToDecimal(total_vale_compra, new CultureInfo("en-US")) :
                0;

            this.vale_compras_dev =
                ConvertToDecimalValidation.IsValid(vale_compras_dev, "vale_compras_dev", listValidations) ?
                Convert.ToDecimal(vale_compras_dev, new CultureInfo("en-US")) :
                0;

            this.obs = obs;
            this.usuario = usuario;
        }
    }
}
