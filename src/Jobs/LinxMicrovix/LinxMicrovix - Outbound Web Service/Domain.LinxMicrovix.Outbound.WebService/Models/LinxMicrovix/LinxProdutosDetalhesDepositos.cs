
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxProdutosDetalhesDepositos
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public string? cnpj_emp { get; private set; }
        public Int64? cod_produto { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? cod_deposito { get; private set; }
        public decimal? saldo { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxProdutosDetalhesDepositos() { }

        public LinxProdutosDetalhesDepositos(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxProdutosDetalhesDepositos record, string recordXml) {
                        lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.cod_deposito = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_deposito);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cod_produto = CustomConvertersExtensions.ConvertToInt64Validation(record.cod_produto);
            this.saldo = CustomConvertersExtensions.ConvertToDecimalValidation(record.saldo);
            this.cnpj_emp = record.cnpj_emp;
        }
    }
}
