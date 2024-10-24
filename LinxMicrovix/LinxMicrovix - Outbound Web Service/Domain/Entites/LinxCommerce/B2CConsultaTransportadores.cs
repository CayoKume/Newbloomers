using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaTransportadores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_transportador { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_fantasia { get; set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_pessoa { get; set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_transportador { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? numero_rua { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro { get; set; }

        [Column(TypeName = "char(9)")]
        public string? cep { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade { get; set; }

        [Column(TypeName = "char(2)")]
        public string? uf { get; set; }

        [Column(TypeName = "varchar(14)")]
        public string? documento { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? email { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string? pais { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? obs { get; set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; set; }
    }
}
