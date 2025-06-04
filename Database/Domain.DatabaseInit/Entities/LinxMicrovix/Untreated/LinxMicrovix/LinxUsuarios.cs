using Domain.IntegrationsCore.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxUsuarios", Schema = "untreated")]
    public class LinxUsuarios
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? usuario_id { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? usuario_login { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? usuario_nome { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? usuario_email { get; private set; }

        [Column(TypeName = "int")]
        public string? usuario_grupo_id { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? grupo_usuarios { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? usuario_supervisor { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? usuario_doc { get; private set; }

        [Column(TypeName = "int")]
        public string? vendedor { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_criacao { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? desativado { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? empresas { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
