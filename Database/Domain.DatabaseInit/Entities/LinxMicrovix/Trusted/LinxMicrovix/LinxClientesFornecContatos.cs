
using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxClientesFornecContatos", Schema = "linx_microvix_erp")]
    public class LinxClientesFornecContatos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string cod_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_contato { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sexo_contato { get; private set; }

        [Column(TypeName = "int")]
        public string contatos_clientes_parentesco { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone1_contato { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone2_contato { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? celular_contato { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email_contato { get; private set; }

        [Column(TypeName = "datetime")]
        public string data_nasc_contato { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? tipo_contato { get; private set; }
    }
}
