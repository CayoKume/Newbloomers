using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxVendedores", Schema = "linx_microvix_erp")]
    public class LinxVendedores
    {
        [Column(TypeName = "datetime")]
        public string lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_vendedor { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_vendedor { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? end_vend_rua { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? end_vend_numero { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? end_vend_complemento { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? end_vend_bairro { get; private set; }

        [Column(TypeName = "varchar(9)")]
        public string? end_vend_cep { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? end_vend_cidade { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? end_vend_uf { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_vendedor { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? mail_vendedor { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_upd { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cpf_vendedor { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativo { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? data_admissao { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? data_saida { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? matricula { get; private set; }

        [Column(TypeName = "int")]
        public string? id_tipo_venda { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao_tipo_venda { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cargo { get; private set; }
    }
}
