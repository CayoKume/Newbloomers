using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxValesComprasEnviadosAPI", Schema = "untreated")]
    public class LinxValesComprasEnviadosAPI
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? numero_controle { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_vale { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "int")]
        public string? status_vale { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_portal_resgate { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_empresa_resgate { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_usuario_resgate { get; private set; }

        [Column(TypeName = "int")]
        public string? codigo_vale_empresa_resgate { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_criacao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_empresa_resgate { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_resgate { get; private set; }
    }
}
