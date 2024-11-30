using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaClientes
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public int? cod_cliente_b2c { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public int? cod_cliente_erp { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "doc_cliente")]
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nm_cliente")]
        public string? nm_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nm_mae")]
        public string? nm_mae { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nm_pai")]
        public string? nm_pai { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "nm_conjuge")]
        public string? nm_conjuge { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_cadastro { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_nasc_cliente { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "end_cliente")]
        public string? end_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "complemento_end_cliente")]
        public string? complemento_end_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "nr_rua_cliente")]
        public string? nr_rua_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "bairro_cliente")]
        public string? bairro_cliente { get; private set; }

        [Column(TypeName = "varchar(9)")]
        [LengthValidation(length: 9, propertyName: "cep_cliente")]
        public string? cep_cliente { get; private set; }

        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "cidade_cliente")]
        public string? cidade_cliente { get; private set; }

        [Column(TypeName = "char(2)")]
        [LengthValidation(length: 2, propertyName: "uf_cliente")]
        public string? uf_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "fone_cliente")]
        public string? fone_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "fone_comercial")]
        public string? fone_comercial { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "cel_cliente")]
        public string? cel_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "email_cliente")]
        public string? email_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "rg_cliente")]
        public string? rg_cliente { get; private set; }

        [Column(TypeName = "varchar(7)")]
        [LengthValidation(length: 7, propertyName: "rg_orgao_emissor")]
        public string? rg_orgao_emissor { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? estado_civil_cliente { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "empresa_cliente")]
        public string? empresa_cliente { get; private set; }

        [Column(TypeName = "varchar(30)")]
        [LengthValidation(length: 30, propertyName: "cargo_cliente")]
        public string? cargo_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "sexo_cliente")]
        public string? sexo_cliente { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_update { get; private set; }

        [Column(TypeName = "bit")]
        public Int32? ativo { get; private set; }

        [Column(TypeName = "bit")]
        public bool? receber_email { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_expedicao_rg { get; private set; }

        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "naturalidade")]
        public string? naturalidade { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? tempo_residencia { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? renda { get; private set; }

        [Column(TypeName = "varchar(10)")]
        [LengthValidation(length: 10, propertyName: "numero_compl_rua_cliente")]
        public string? numero_compl_rua_cliente { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_pessoa { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "bit")]
        public bool? aceita_programa_fidelidade { get; private set; }

        public B2CConsultaClientes() { }

        public B2CConsultaClientes(
            List<ValidationResult> listValidations,
            string? cod_cliente_b2c,
            string? cod_cliente_erp,
            string? doc_cliente,
            string? nm_cliente,
            string? nm_mae,
            string? nm_pai,
            string? nm_conjuge,
            string? dt_cadastro,
            string? dt_nasc_cliente,
            string? end_cliente,
            string? complemento_end_cliente,
            string? nr_rua_cliente,
            string? bairro_cliente,
            string? cep_cliente,
            string? cidade_cliente,
            string? uf_cliente,
            string? fone_cliente,
            string? fone_comercial,
            string? cel_cliente,
            string? email_cliente,
            string? rg_cliente,
            string? rg_orgao_emissor,
            string? estado_civil_cliente,
            string? empresa_cliente,
            string? cargo_cliente,
            string? sexo_cliente,
            string? dt_update,
            string? ativo,
            string? receber_email,
            string? dt_expedicao_rg,
            string? naturalidade,
            string? tempo_residencia,
            string? renda,
            string? numero_compl_rua_cliente,
            string? timestamp,
            string? tipo_pessoa,
            string? portal,
            string? aceita_programa_fidelidade
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_cliente_b2c =
                ConvertToInt32Validation.IsValid(cod_cliente_b2c, "cod_cliente_b2c", listValidations) ?
                Convert.ToInt32(cod_cliente_b2c) :
                0;

            this.cod_cliente_erp =
                ConvertToInt32Validation.IsValid(cod_cliente_erp, "cod_cliente_erp", listValidations) ?
                Convert.ToInt32(cod_cliente_erp) :
                0;
            
            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.estado_civil_cliente =
                ConvertToInt32Validation.IsValid(estado_civil_cliente, "estado_civil_cliente", listValidations) ?
                Convert.ToInt32(estado_civil_cliente) :
                0;

            this.ativo =
                ConvertToInt32Validation.IsValid(ativo, "ativo", listValidations) ?
                Convert.ToInt32(ativo) :
                0;

            this.tempo_residencia =
                ConvertToInt32Validation.IsValid(tempo_residencia, "tempo_residencia", listValidations) ?
                Convert.ToInt32(tempo_residencia) :
                0;

            this.renda =
                ConvertToDecimalValidation.IsValid(renda, "renda", listValidations) ?
                Convert.ToDecimal(renda) :
                0;

            this.receber_email =
                ConvertToBooleanValidation.IsValid(receber_email, "receber_email", listValidations) ?
                Convert.ToBoolean(receber_email) :
                false;

            this.aceita_programa_fidelidade =
                ConvertToBooleanValidation.IsValid(aceita_programa_fidelidade, "aceita_programa_fidelidade", listValidations) ?
                Convert.ToBoolean(aceita_programa_fidelidade) :
                false;

            this.dt_cadastro =
                ConvertToDateTimeValidation.IsValid(dt_cadastro, "dt_cadastro", listValidations) ?
                Convert.ToDateTime(dt_cadastro) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.dt_expedicao_rg =
                ConvertToDateTimeValidation.IsValid(dt_expedicao_rg, "dt_expedicao_rg", listValidations) ?
                Convert.ToDateTime(dt_expedicao_rg) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.dt_update =
                ConvertToDateTimeValidation.IsValid(dt_update, "dt_update", listValidations) ?
                Convert.ToDateTime(dt_update) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.dt_nasc_cliente =
                ConvertToDateTimeValidation.IsValid(dt_nasc_cliente, "dt_nasc_cliente", listValidations) ?
                Convert.ToDateTime(dt_nasc_cliente) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.doc_cliente = doc_cliente;
            this.nm_cliente = nm_cliente;
            this.nm_mae = nm_mae;
            this.nm_pai = nm_pai;
            this.nm_conjuge = nm_conjuge;
            this.end_cliente = end_cliente;
            this.complemento_end_cliente = complemento_end_cliente;
            this.nr_rua_cliente = nr_rua_cliente;
            this.bairro_cliente = bairro_cliente;
            this.cep_cliente = cep_cliente;
            this.cidade_cliente = cidade_cliente;
            this.uf_cliente = uf_cliente;
            this.fone_cliente = fone_cliente;
            this.fone_comercial = fone_comercial;
            this.cel_cliente = cel_cliente;
            this.email_cliente = email_cliente;
            this.rg_cliente = rg_cliente;
            this.rg_orgao_emissor = rg_orgao_emissor;
            this.empresa_cliente = empresa_cliente;
            this.cargo_cliente = cargo_cliente;
            this.sexo_cliente = sexo_cliente;
            this.naturalidade = naturalidade;
            this.numero_compl_rua_cliente = numero_compl_rua_cliente;
            this.tipo_pessoa = tipo_pessoa;
        }
    }
}
