
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCampanhas
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? codigo_campanha { get; private set; }
        public string? nome_campanha { get; private set; }
        public DateTime? vigencia_inicio { get; private set; }
        public DateTime? vigencia_fim { get; private set; }
        public string? observacao { get; private set; }
        public Int32? ativo { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCampanhas() { }

        public B2CConsultaProdutosCampanhas(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosCampanhas record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.codigo_campanha = CustomConvertersExtensions.ConvertToInt32Validation(record.codigo_campanha);
            this.vigencia_inicio = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.vigencia_inicio);
            this.vigencia_fim = CustomConvertersExtensions.ConvertToDateTimeValidation<string>(record.vigencia_fim);
            this.ativo = CustomConvertersExtensions.ConvertToInt32Validation(record.ativo);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp = CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);
               
            this.nome_campanha = record.nome_campanha;
            this.observacao = record.observacao;
            this.recordXml = recordXml;
        }
    }
}
