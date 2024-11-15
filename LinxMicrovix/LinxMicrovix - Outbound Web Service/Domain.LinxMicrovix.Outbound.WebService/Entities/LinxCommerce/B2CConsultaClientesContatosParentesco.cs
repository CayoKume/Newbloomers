using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaClientesContatosParentesco
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_parentesco { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? descricao_parentesco { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaClientesContatosParentesco() { }

        public B2CConsultaClientesContatosParentesco(
            string? id_parentesco,
            string? descricao_parentesco,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_parentesco =
                String.IsNullOrEmpty(id_parentesco) ? 0
                : Convert.ToInt32(id_parentesco);

            this.descricao_parentesco =
                String.IsNullOrEmpty(descricao_parentesco) ? ""
                : descricao_parentesco.Substring(
                    0,
                    descricao_parentesco.Length > 50 ? 50
                    : descricao_parentesco.Length
                );

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
