using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaProdutosTabelas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_tabela { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_tabela { get; set; }

        [Column(TypeName = "char(1)")]
        public string? ativa { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
