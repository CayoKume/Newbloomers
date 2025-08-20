
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCustos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_produtos_custos { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? empresa { get; private set; }
        public decimal? custoicms1 { get; private set; }
        public decimal? ipi1 { get; private set; }
        public decimal? markup { get; private set; }
        public decimal? customedio { get; private set; }
        public decimal? frete1 { get; private set; }
        public Int32? precisao { get; private set; }
        public decimal? precominimo { get; private set; }
        public DateTime? dt_update { get; private set; }
        public decimal? custoliquido { get; private set; }
        public decimal? precovenda { get; private set; }
        public decimal? custototal { get; private set; }
        public decimal? precocompra { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCustos() { }

        public B2CConsultaProdutosCustos(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosCustos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.id_produtos_custos = CustomConvertersExtensions.ConvertToInt32Validation(record.id_produtos_custos);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.custoicms1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.custoicms1);
            this.ipi1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.ipi1);
            this.markup = CustomConvertersExtensions.ConvertToDecimalValidation(record.markup);
            this.customedio = CustomConvertersExtensions.ConvertToDecimalValidation(record.customedio);
            this.frete1 = CustomConvertersExtensions.ConvertToDecimalValidation(record.frete1);
            this.precisao = CustomConvertersExtensions.ConvertToInt32Validation(record.precisao);
            this.precominimo = CustomConvertersExtensions.ConvertToDecimalValidation(record.precominimo);
            this.dt_update = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.dt_update);
            this.custoliquido = CustomConvertersExtensions.ConvertToDecimalValidation(record.custoliquido);
            this.precovenda = CustomConvertersExtensions.ConvertToDecimalValidation(record.precovenda);
            this.custototal = CustomConvertersExtensions.ConvertToDecimalValidation(record.custototal);
            this.precocompra = CustomConvertersExtensions.ConvertToDecimalValidation(record.precocompra);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.recordXml = recordXml;
        }
    }
}
