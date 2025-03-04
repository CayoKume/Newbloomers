using Domain.IntegrationsCore.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxOrdemServicoExternaDav", Schema = "linx_microvix_erp")]
    public class LinxOrdemServicoExternaDav
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_vendas_pos_tmp_ordem_servico_externa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_vendas_pos { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "codigo_ordem_servico_externa")]
        public string? codigo_ordem_servico_externa { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordKey { get; private set; }

        [NotMapped]
        [SkipProperty]
        public string? recordXml { get; private set; }

        public LinxOrdemServicoExternaDav() { }

        public LinxOrdemServicoExternaDav(
            List<ValidationResult> listValidations,
            string? id_vendas_pos_tmp_ordem_servico_externa,
            string? id_vendas_pos,
            string? codigo_ordem_servico_externa,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_vendas_pos_tmp_ordem_servico_externa =
                ConvertToInt32Validation.IsValid(id_vendas_pos_tmp_ordem_servico_externa, "id_vendas_pos_tmp_ordem_servico_externa", listValidations) ?
                Convert.ToInt32(id_vendas_pos_tmp_ordem_servico_externa) :
                0;

            this.id_vendas_pos =
                ConvertToInt32Validation.IsValid(id_vendas_pos, "id_vendas_pos", listValidations) ?
                Convert.ToInt32(id_vendas_pos) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.codigo_ordem_servico_externa = codigo_ordem_servico_externa;
        }
    }
}
