using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.IntegrationsCore.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_campo_detalhe { get; private set; }

        [Column(TypeName = "int")]
        public Int32? ordem { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "descricao")]
        public string? descricao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_campo { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosCamposAdicionaisDetalhes() { }

        public B2CConsultaProdutosCamposAdicionaisDetalhes(
            List<ValidationResult> listValidations,
            string? id_campo_detalhe, 
            string? ordem, 
            string? descricao, 
            string? id_campo, 
            string? ativo, 
            string? timestamp, 
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_campo_detalhe =
                String.IsNullOrEmpty(id_campo_detalhe) ? 0
                : Convert.ToInt32(id_campo_detalhe);

            this.ordem =
                String.IsNullOrEmpty(ordem) ? 0
                : Convert.ToInt32(ordem);

            this.descricao = descricao;

            this.id_campo =
                String.IsNullOrEmpty(id_campo) ? 0
                : Convert.ToInt32(id_campo);

            this.ativo =
                String.IsNullOrEmpty(ativo) ? 0
                : Convert.ToInt32(ativo);

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;
        }
    }
}
