using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxDevolucaoRemanejoFabrica", Schema = "linx_microvix_erp")]
    public class LinxDevolucaoRemanejoFabrica
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_devolucao_remanejo_fabrica { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_devolucao_remanejo_fabrica_tipo { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_motivo_devolucao_fabrica { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_deposito { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_devolucao_remanejo_fabrica_status { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? fornecedor { get; private set; }

        [Column(TypeName = "char(10)")]
        [LengthValidation(length: 10, propertyName: "cfop")]
        public string? cfop { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "serie")]
        public string? serie { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "codigo_solicitacao")]
        public string? codigo_solicitacao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_solicitacao { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxDevolucaoRemanejoFabrica() { }

        public LinxDevolucaoRemanejoFabrica(
            List<ValidationResult> listValidations,
            string? id_devolucao_remanejo_fabrica,
            string? id_devolucao_remanejo_fabrica_tipo,
            string? id_motivo_devolucao_fabrica,
            string? id_deposito,
            string? id_devolucao_remanejo_fabrica_status,
            string? empresa,
            string? fornecedor,
            string? cfop,
            string? serie,
            string? codigo_solicitacao,
            string? portal,
            string? data_solicitacao,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_devolucao_remanejo_fabrica =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica, "id_devolucao_remanejo_fabrica", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica) :
                0;

            this.id_devolucao_remanejo_fabrica_tipo =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica_tipo, "id_devolucao_remanejo_fabrica_tipo", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica_tipo) :
                0;

            this.id_motivo_devolucao_fabrica =
                ConvertToInt32Validation.IsValid(id_motivo_devolucao_fabrica, "id_motivo_devolucao_fabrica", listValidations) ?
                Convert.ToInt32(id_motivo_devolucao_fabrica) :
                0;

            this.id_deposito =
                ConvertToInt32Validation.IsValid(id_deposito, "id_deposito", listValidations) ?
                Convert.ToInt32(id_deposito) :
                0;

            this.id_devolucao_remanejo_fabrica_status =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica_status, "id_devolucao_remanejo_fabrica_status", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica_status) :
                0;

            this.empresa =
                ConvertToInt32Validation.IsValid(empresa, "empresa", listValidations) ?
                Convert.ToInt32(empresa) :
                0;

            this.fornecedor =
                ConvertToInt32Validation.IsValid(fornecedor, "fornecedor", listValidations) ?
                Convert.ToInt32(fornecedor) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.data_solicitacao =
                ConvertToDateTimeValidation.IsValid(data_solicitacao, "data_solicitacao", listValidations) ?
                Convert.ToDateTime(data_solicitacao) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.cfop = cfop;
            this.serie = serie;
            this.codigo_solicitacao = codigo_solicitacao;
        }
    }
}
