using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxGrupoLojas", Schema = "untreated")]
    public class LinxGrupoLojas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_empresa { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_empresas_rede { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? rede { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? classificacao_portal { get; private set; }
    }
}