using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxECFFormasPagamento
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_empresa_ecf_formas_pgto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_ecf { get; private set; }
        
        [Column(TypeName = "int")]
        public Int32? cod_forma_pgto { get; private set; }
        
        [Column(TypeName = "varchar(53)")]
        [LengthValidation(length: 53, propertyName: "indice_forma")]
        public string? indice_forma { get; private set; }
        
        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

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
