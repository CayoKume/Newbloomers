using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    [Table("B2CConsultaProdutosCampanhas", Schema = "linx_microvix_commerce")]
    public class B2CConsultaProdutosCampanhas
    {
        public DateTime? lastupdateon { get; private set; }

        public Int32? codigo_campanha { get; private set; }

        [LengthValidation(length: 60, propertyName: "nome_campanha")]
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
            List<ValidationResult> listValidations,
            string? codigo_campanha,
            string? nome_campanha,
            string? vigencia_inicio,
            string? vigencia_fim,
            string? observacao,
            string? ativo,
            string? timestamp,
            string? portal,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.codigo_campanha =
                ConvertToInt32Validation.IsValid(codigo_campanha, "codigo_campanha", listValidations) ?
                Convert.ToInt32(codigo_campanha) :
                0;

            this.vigencia_inicio =
                ConvertToDateTimeValidation.IsValid(vigencia_inicio, "vigencia_inicio", listValidations) ?
                Convert.ToDateTime(vigencia_inicio) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.vigencia_fim =
                ConvertToDateTimeValidation.IsValid(vigencia_fim, "vigencia_fim", listValidations) ?
                Convert.ToDateTime(vigencia_fim) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.ativo =
                ConvertToInt32Validation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToInt32(ativo) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.nome_campanha = nome_campanha;
            this.observacao = observacao;
            this.recordXml = recordXml;
        }
    }
}
