
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxFechamentoCaixa
    {
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
        public string? usuario { get; private set; }
        public decimal? vale_compras_dev { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxFechamentoCaixa() { }

        public LinxFechamentoCaixa(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxFechamentoCaixa record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.ativo = CustomConvertersExtensions.ConvertToBooleanValidation(record.ativo);
            this.conferencia_efetuada = CustomConvertersExtensions.ConvertToBooleanValidation(record.conferencia_efetuada);
            this.data =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.qtd_001 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_001);
            this.qtd_005 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_005);
            this.qtd_010 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_010);
            this.qtd_025 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_025);
            this.qtd_050 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_050);
            this.qtd_1 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_1);
            this.qtd_10 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_10);
            this.qtd_100 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_100);
            this.qtd_2 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_2);
            this.qtd_20 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_20);
            this.qtd_200 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_200);
            this.qtd_5 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_5);
            this.qtd_50 = CustomConvertersExtensions.ConvertToInt32Validation(record.qtd_50);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.sangria = CustomConvertersExtensions.ConvertToDecimalValidation(record.sangria);
            this.suprimentos = CustomConvertersExtensions.ConvertToDecimalValidation(record.suprimentos);
            this.total_c_prazo = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_c_prazo);
            this.total_c_vista = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_c_vista);
            this.total_cartao = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_cartao);
            this.total_cartao_credito = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_cartao_credito);
            this.total_cartao_debito = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_cartao_debito);
            this.total_convenio = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_convenio);
            this.total_crediario = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_crediario);
            this.total_geral = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_geral);
            this.total_giftcard = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_giftcard);
            this.total_link_pagamento = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_link_pagamento);
            this.total_link_pagamento_credito = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_link_pagamento_credito);
            this.total_link_pagamento_debito = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_link_pagamento_debito);
            this.total_pix = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_pix);
            this.total_qr_linx = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_qr_linx);
            this.total_vale_compra = CustomConvertersExtensions.ConvertToDecimalValidation(record.total_vale_compra);
            this.vale_compras_dev = CustomConvertersExtensions.ConvertToDecimalValidation(record.vale_compras_dev);
            this.obs = record.obs;
            this.usuario = record.usuario;
        }
    }
}
