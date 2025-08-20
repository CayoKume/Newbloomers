
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhes
    {
        public DateTime? lastupdateon { get; private set; }
        public Int32? id_campo_detalhe { get; private set; }
        public Int32? ordem { get; private set; }
        public string? descricao { get; private set; }
        public Int32? id_campo { get; private set; }
        public Int32? ativo { get; private set; }
        public Int64? timestamp { get; private set; }
        public Int32? portal { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisDetalhes() { }

        public B2CConsultaProdutosCamposAdicionaisDetalhes(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosCamposAdicionaisDetalhes record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_campo_detalhe = CustomConvertersExtensions.ConvertToInt32Validation(record.id_campo_detalhe);
            this.ordem =CustomConvertersExtensions.ConvertToInt32Validation(record.ordem);
            this.id_campo =CustomConvertersExtensions.ConvertToInt32Validation(record.id_campo);
            this.ativo =CustomConvertersExtensions.ConvertToInt32Validation(record.ativo);
            this.portal =CustomConvertersExtensions.ConvertToInt32Validation(record.portal);
            this.timestamp =CustomConvertersExtensions.ConvertToInt64Validation(record.timestamp);

            this.descricao = record.descricao;
            this.recordXml = recordXml;
        }
    }
}
