using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entites.LinxMicrovix.LinxCommerce
{
    [Table("B2CConsultaProdutosImagens", Schema = "untreated")]
    public class B2CConsultaProdutosImagens
    {

        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_imagem_produto { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_imagem { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? codigoproduto { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaProdutosImagens() { }

        public B2CConsultaProdutosImagens(
            List<ValidationResult> listValidations,
            string? id_imagem_produto,
            string? id_imagem,
            string? codigoproduto,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_imagem_produto =
                ConvertToInt32Validation.IsValid(id_imagem_produto, "id_imagem_produto", listValidations) ?
                Convert.ToInt32(id_imagem_produto) :
                0;

            this.codigoproduto =
                ConvertToInt64Validation.IsValid(codigoproduto, "codigoproduto", listValidations) ?
                Convert.ToInt64(codigoproduto) :
                0;

            this.id_imagem =
                ConvertToInt32Validation.IsValid(id_imagem, "id_imagem", listValidations) ?
                Convert.ToInt32(id_imagem) :
                0;

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
