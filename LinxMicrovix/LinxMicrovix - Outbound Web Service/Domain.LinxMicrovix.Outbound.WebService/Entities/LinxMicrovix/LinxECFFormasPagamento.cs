using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix
{
    public class LinxECFFormasPagamento
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_empresa_ecf_formas_pgto { get; private set; }

        public Int32? id_ecf { get; private set; }

        public Int32? cod_forma_pgto { get; private set; }

        [LengthValidation(length: 53, propertyName: "indice_forma")]
        public string? indice_forma { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxECFFormasPagamento() { }

        public LinxECFFormasPagamento(
            List<ValidationResult> listValidations,
            string? id_empresa_ecf_formas_pgto,
            string? id_ecf,
            string? cod_forma_pgto,
            string? indice_forma,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_empresa_ecf_formas_pgto =
                ConvertToInt32Validation.IsValid(id_empresa_ecf_formas_pgto, "id_empresa_ecf_formas_pgto", listValidations) ?
                Convert.ToInt32(id_empresa_ecf_formas_pgto) :
                0;

            this.id_ecf =
                ConvertToInt32Validation.IsValid(id_ecf, "id_ecf", listValidations) ?
                Convert.ToInt32(id_ecf) :
                0;

            this.cod_forma_pgto =
                ConvertToInt32Validation.IsValid(cod_forma_pgto, "cod_forma_pgto", listValidations) ?
                Convert.ToInt32(cod_forma_pgto) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.indice_forma = indice_forma;
        }
    }
}
