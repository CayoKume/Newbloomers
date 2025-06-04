using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxClientesFornec", Schema = "linx_microvix_erp")]
    public class LinxClientesFornec
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? razao_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_cliente { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_cliente { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? numero_rua_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? complement_end_cli { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro_cliente { get; private set; }

        [Column(TypeName = "char(9)")]
        public string? cep_cliente { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? uf_cliente { get; private set; }

        [Column(TypeName = "varchar(80)")]
        public string? pais { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sexo { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_cadastro { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_nascimento { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cel_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativo { get; private set; }

        [Column(TypeName = "datetime")]
        public string? dt_update { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? inscricao_estadual { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? incricao_municipal { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? identidade_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cartao_fidelidade { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_ibge_municipio { get; private set; }

        [Column(TypeName = "varchar(83)")]
        public string? classe_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? matricula_conveniado { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_cadastro { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa_cadastro { get; private set; }

        [Column(TypeName = "int")]
        public string? id_estado_civil { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? fax_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? site_cliente { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "bit")]
        public string? cliente_anonimo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? limite_compras { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? codigo_ws { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? limite_credito_compra { get; private set; }

        [Column(TypeName = "int")]
        public string? id_classe_fiscal { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? mae { get; private set; }
    }
}
