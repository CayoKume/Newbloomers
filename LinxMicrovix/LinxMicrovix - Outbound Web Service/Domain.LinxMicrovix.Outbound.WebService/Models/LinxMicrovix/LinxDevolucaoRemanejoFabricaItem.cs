using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaItem
    {
        [NotMapped]
        public Int32 id { get; set; }

        public DateTime? lastupdateon { get; private set; }

        public Int32? id_devolucao_remanejo_fabrica_item { get; private set; }

        public Int32? id_devolucao_remanejo_fabrica { get; private set; }

        public Int64? codigoproduto { get; private set; }

        [LengthValidation(length: 50, propertyName: "codigo_produto_franqueadora")]
        public string? codigo_produto_franqueadora { get; private set; }

        public Int32? quantidade { get; private set; }

        [LengthValidation(length: 20, propertyName: "codebar")]
        public string? codebar { get; private set; }

        [LengthValidation(length: 50, propertyName: "serial")]
        public string? serial { get; private set; }

        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxDevolucaoRemanejoFabricaItem() { }

        public LinxDevolucaoRemanejoFabricaItem(
            List<ValidationResult> listValidations,
            string? id_devolucao_remanejo_fabrica_item,
            string? id_devolucao_remanejo_fabrica,
            string? codigoproduto,
            string? codigo_produto_franqueadora,
            string? quantidade,
            string? codebar,
            string? serial,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_devolucao_remanejo_fabrica_item =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica_item, "id_devolucao_remanejo_fabrica_item", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica_item) :
                0;

            this.id_devolucao_remanejo_fabrica =
                ConvertToInt32Validation.IsValid(id_devolucao_remanejo_fabrica, "id_devolucao_remanejo_fabrica", listValidations) ?
                Convert.ToInt32(id_devolucao_remanejo_fabrica) :
                0;

            this.quantidade =
                ConvertToInt32Validation.IsValid(quantidade, "quantidade", listValidations) ?
                Convert.ToInt32(quantidade) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.codigo_produto_franqueadora = codigo_produto_franqueadora;
            this.codebar = codebar;
            this.serial = serial;
        }
    }
}
