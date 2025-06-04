using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxClientesEnderecosEntrega", Schema = "linx_microvix_erp")]
    public class LinxClientesEnderecosEntrega
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_endereco_entrega { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? numero_rua_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? complemento_end_cli { get; private set; }

        [Column(TypeName = "char(9)")]
        public string? cep_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro_cliente { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade_cliente { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? uf_cliente { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? descricao { get; private set; }

        [Column(TypeName = "bit")]
        public string? principal { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_celular { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
