using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxMicrovix
{
    [Table("LinxOticoPrismaDescricao", Schema = "untreated")]
    public class LinxOticoPrismaDescricao
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_otico_prisma_descricao { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        public LinxOticoPrismaDescricao() { }

        public LinxOticoPrismaDescricao(
            List<ValidationResult> listValidations,
            string? id_otico_prisma_descricao,
            string? descricao,
            string? portal,
            string? timestamp
        )
        {
            lastupdateon = DateTime.Now;

            this.id_otico_prisma_descricao =
                ConvertToInt32Validation.IsValid(id_otico_prisma_descricao, "id_otico_prisma_descricao", listValidations) ?
                Convert.ToInt32(id_otico_prisma_descricao) :
                0;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.descricao = descricao;
        }
    }
}
