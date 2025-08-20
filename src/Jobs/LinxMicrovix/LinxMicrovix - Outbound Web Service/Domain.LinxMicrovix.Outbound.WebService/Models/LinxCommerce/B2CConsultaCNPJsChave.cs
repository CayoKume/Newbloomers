
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaCNPJsChave
    {
        public DateTime? lastupdateon { get; private set; }
        public string? cnpj { get; private set; }
        public string? nome_empresa { get; private set; }
        public Int32? id_empresas_rede { get; private set; }
        public string? rede { get; private set; }
        public Int32? portal { get; private set; }
        public string? nome_portal { get; private set; }
        public Int32? empresa { get; private set; }
        public string? classificacao_portal { get; private set; }
        public bool? b2c { get; private set; }
        public bool? oms { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public B2CConsultaCNPJsChave() { }

        public B2CConsultaCNPJsChave(
            Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaCNPJsChave record,
            string? recordXml
        )
        {
            lastupdateon = CustomConvertersExtensions.ConvertToDateTimeValidation<DateTime>(DateTime.Now);
            this.id_empresas_rede = CustomConvertersExtensions.ConvertToInt32Validation(record.id_empresas_rede);
            this.empresa = CustomConvertersExtensions.ConvertToInt32Validation(record.empresa);
            this.b2c = CustomConvertersExtensions.ConvertToBooleanValidation(record.b2c);
            this.oms = CustomConvertersExtensions.ConvertToBooleanValidation(record.oms);
            this.portal = CustomConvertersExtensions.ConvertToInt32Validation(record.portal);

            this.cnpj = record.cnpj;
            this.nome_empresa = record.nome_empresa;
            this.classificacao_portal = record.classificacao_portal;
            this.rede = record.rede;
            this.nome_portal = record.nome_portal;
            this.recordXml = recordXml;
        }
    }
}
