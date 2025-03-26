using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaImagens", Schema = "untreated")]
    public class B2CConsultaImagens
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_imagem { get; private set; }

        [Column(TypeName = "char(32)")]
        public string? md5 { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(4000)")]
        public string? url_imagem_blob { get; private set; }
    }
}
