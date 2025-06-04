using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce
{
    [Table("B2CConsultaClientes", Schema = "untreated")]
    public class B2CConsultaClientes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente_b2c { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nm_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nm_mae { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nm_pai { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nm_conjuge { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_cadastro { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_nasc_cliente { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? end_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? complemento_end_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? nr_rua_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro_cliente { get; private set; }

        [Column(TypeName = "varchar(9)")]
        public string? cep_cliente { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade_cliente { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? uf_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_comercial { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cel_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? rg_cliente { get; private set; }

        [Column(TypeName = "varchar(7)")]
        public string? rg_orgao_emissor { get; private set; }

        [Column(TypeName = "tinyint")]
        public string? estado_civil_cliente { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? empresa_cliente { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? cargo_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sexo_cliente { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_update { get; private set; }

        [Column(TypeName = "bit")]
        public string? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public string? receber_email { get; private set; }

        [Column(TypeName = "smallstring")]
        public string? dt_expedicao_rg { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? naturalidade { get; private set; }

        [Column(TypeName = "tinyint")]
        public string? tempo_residencia { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? renda { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? numero_compl_rua_cliente { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_pessoa { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "bit")]
        public string? aceita_programa_fidelidade { get; private set; }
    }
}
