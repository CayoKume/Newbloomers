using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaTransportadores", Schema = "untreated")]
    public class B2CConsultaTransportadores
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_transportador { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_fantasia { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_pessoa { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_transportador { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? numero_rua { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro { get; private set; }

        [Column(TypeName = "char(9)")]
        public string? cep { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? uf { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? documento { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email { get; private set; }

        [Column(TypeName = "varchar(80)")]
        public string? pais { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? obs { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
