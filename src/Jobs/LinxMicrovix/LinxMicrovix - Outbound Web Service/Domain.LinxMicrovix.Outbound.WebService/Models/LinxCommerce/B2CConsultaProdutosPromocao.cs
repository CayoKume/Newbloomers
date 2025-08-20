
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosPromocao
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigo_promocao { get; private set; }
        public Int32? empresa { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public decimal? preco { get; private set; }
        public DateTime? data_inicio { get; private set; }
        public DateTime? data_termino { get; private set; }
        public DateTime? data_cadastro { get; private set; }
        public string? ativa { get; private set; }
        public Int32? codigo_campanha { get; private set; }
        public Int32? promocao_opcional { get; private set; }
        public Int64? timestamp { get; private set; }
        public string? referencia { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosPromocao() { }

        public B2CConsultaProdutosPromocao(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosPromocao record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigo_promocao = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_promocao);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.preco = CustomConvertersExtensions.ConvertToDecimalValidation(record.preco);
            this.data_inicio = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_inicio);
            this.data_termino = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_termino);
            this.data_cadastro = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_cadastro);
            this.codigo_campanha = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_campanha);
            this.promocao_opcional = CustomConvertersExtensions.ConvertToInt32Validation(record.promocao_opcional);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.ativa = record.ativa;
            this.referencia = record.referencia;
            this.recordXml = recordXml;
        }
    }
}
