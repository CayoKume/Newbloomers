using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaClientesEnderecosEntrega", Schema = "linx_microvix_commerce")]
    public class B2CConsultaClientesEnderecosEntrega
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? id_endereco_entrega { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente_b2c { get; private set; }

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

        [Key]
        [Column(TypeName = "int")]
        public string? id_cidade { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
