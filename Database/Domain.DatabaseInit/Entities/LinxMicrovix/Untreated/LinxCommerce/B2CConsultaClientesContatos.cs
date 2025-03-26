using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaClientesContatos", Schema = "untreated")]
    public class B2CConsultaClientesContatos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_clientes_contatos { get; private set; }

        [Key]
        [ForeignKey("id_contato_b2c")]
        [Column(TypeName = "int")]
        public string? id_contato_b2c { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_contato { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_nasc_contato { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sexo_contato { get; private set; }

        [Key]
        [ForeignKey("id_parentesco")]
        [Column(TypeName = "int")]
        public string? id_parentesco { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_contato { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? celular_contato { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email_contato { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente_erp { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
