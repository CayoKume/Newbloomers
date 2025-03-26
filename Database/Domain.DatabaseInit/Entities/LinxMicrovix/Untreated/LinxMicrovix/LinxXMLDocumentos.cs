using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxXMLDocumentos", Schema = "untreated")]
    public class LinxXMLDocumentos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? documento { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_emissao { get; private set; }

        [Key]
        [Column(TypeName = "varchar(44)")]
        public string? chave_nfe { get; private set; }

        [Column(TypeName = "int")]
        public string? situacao { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? xml { get; private set; }

        [Column(TypeName = "bit")]
        public string? excluido { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador_microvix { get; private set; }

        [Column(TypeName = "datetime")]
        public string? dt_insert { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? nProtCanc { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? nProtInut { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? xmlDistribuicao { get; private set; }

        [Column(TypeName = "varchar(15)")]
        public string? nProtDeneg { get; private set; }

        [Column(TypeName = "varchar(5)")]
        public string? cStat { get; private set; }

        [Column(TypeName = "int")]
        public string? id_nfe { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }
    }
}
