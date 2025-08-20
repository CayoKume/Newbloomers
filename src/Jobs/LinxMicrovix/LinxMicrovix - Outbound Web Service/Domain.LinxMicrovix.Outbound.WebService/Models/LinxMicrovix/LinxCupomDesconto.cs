
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxCupomDesconto
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? portal { get; private set; }
        public Int32? empresa { get; private set; }
        public Int32? id_cupom_desconto { get; private set; }
        public string? cupom { get; private set; }
        public string? descricao { get; private set; }
        public decimal? percentual_desconto { get; private set; }
        public DateTime? data_inicial_vigencia { get; private set; }
        public DateTime? data_final_vigencia { get; private set; }
        public Int32? qtde_original { get; private set; }
        public Int32? qtde_disponivel { get; private set; }
        public Int32? cod_vendedor { get; private set; }
        public bool? disponivel { get; private set; }
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxCupomDesconto() { }

        public LinxCupomDesconto(Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxCupomDesconto record, string recordXml) {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_cupom_desconto = CustomConvertersExtensions.ConvertToInt32Validation(record.id_cupom_desconto);
            this.qtde_original = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_original);
            this.qtde_disponivel = CustomConvertersExtensions.ConvertToInt32Validation(record.qtde_disponivel);
            this.cod_vendedor = CustomConvertersExtensions.ConvertToInt32Validation(record.cod_vendedor);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.percentual_desconto = CustomConvertersExtensions.ConvertToDecimalValidation(record.percentual_desconto);
            this.data_inicial_vigencia =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_inicial_vigencia);
            this.data_final_vigencia =  CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.data_final_vigencia);
            this.disponivel = CustomConvertersExtensions.ConvertToBooleanValidation(record.disponivel);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
            this.cupom = record.cupom;
            this.descricao = record.descricao;
        }
    }
}
