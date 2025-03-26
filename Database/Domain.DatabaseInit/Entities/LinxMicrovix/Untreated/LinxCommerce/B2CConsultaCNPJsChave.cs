using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaCNPJsChave", Schema = "untreated")]
    public class B2CConsultaCNPJsChave
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nome_empresa { get; private set; }

        [Key]
        [Column(TypeName = "smallint")]
        public string? id_empresas_rede { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? rede { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? classificacao_portal { get; private set; }

        [Column(TypeName = "bit")]
        public string? b2c { get; private set; }

        [Column(TypeName = "bit")]
        public string? oms { get; private set; }
    }
}
