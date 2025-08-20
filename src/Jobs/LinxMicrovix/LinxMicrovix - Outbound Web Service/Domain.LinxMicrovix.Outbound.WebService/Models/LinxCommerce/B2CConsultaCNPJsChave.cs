using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce
{
    public class B2CConsultaCNPJsChave
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        [LengthValidation(length: 14, propertyName: "cnpj")]
        public string? cnpj { get; private set; }

        [LengthValidation(length: 250, propertyName: "nome_empresa")]
        public string? nome_empresa { get; private set; }

        public Int32? id_empresas_rede { get; private set; }

        [LengthValidation(length: 100, propertyName: "rede")]
        public string? rede { get; private set; }

        public Int32? portal { get; private set; }

        [LengthValidation(length: 50, propertyName: "nome_portal")]
        public string? nome_portal { get; private set; }

        public Int32? empresa { get; private set; }

        [LengthValidation(length: 50, propertyName: "classificacao_portal")]
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
            List<ValidationResult> listValidations,
            string? cnpj,
            string? nome_empresa,
            string? id_empresas_rede,
            string? rede,
            string? portal,
            string? nome_portal,
            string? empresa,
            string? classificacao_portal,
            string? b2c,
            string? oms,
            string? recordXml
        )
        {
            lastupdateon = DateTime.Now;

            this.id_empresas_rede =
                ConvertToInt32Validation.IsValid(id_empresas_rede, "id_empresas_rede", listValidations) ?
                Convert.ToInt32(id_empresas_rede) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.b2c =
                ConvertToBooleanValidation.IsValid(b2c, "b2c", listValidations) ?
                Convert.ToBoolean(b2c) :
                false;

            this.oms =
                ConvertToBooleanValidation.IsValid(oms, "oms", listValidations) ?
                Convert.ToBoolean(oms) :
                false;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cnpj = cnpj;
            this.nome_empresa = nome_empresa;
            this.classificacao_portal = classificacao_portal;
            this.rede = rede;
            this.nome_portal = nome_portal;
            this.recordXml = recordXml;
        }
    }
}
