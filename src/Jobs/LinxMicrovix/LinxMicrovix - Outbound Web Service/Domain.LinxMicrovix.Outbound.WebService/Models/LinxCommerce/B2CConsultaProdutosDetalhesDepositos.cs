
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int64? codigoproduto { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? id_deposito { get; private set; }
        public decimal? saldo { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? deposito { get; private set; }
        public Int32? tempo_preparacao_estoque { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosDetalhesDepositos() { }

        public B2CConsultaProdutosDetalhesDepositos(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosDetalhesDepositos record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigoproduto = CustomConvertersExtensions.ConvertToInt64Validation(record.codigoproduto);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.id_deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.id_deposito);
            this.saldo = CustomConvertersExtensions.ConvertToDecimalValidation(record.saldo);
            this.deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.deposito);
            this.tempo_preparacao_estoque = CustomConvertersExtensions.ConvertToInt32Validation(record.tempo_preparacao_estoque);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            
            this.recordXml = recordXml;
        }
    }
}
