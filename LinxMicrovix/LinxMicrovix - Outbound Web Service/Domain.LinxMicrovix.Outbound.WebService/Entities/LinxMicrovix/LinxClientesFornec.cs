using Domain.IntegrationsCore.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    [Table("LinxClientesFornec", Schema = "linx_microvix_erp")]
    public class LinxClientesFornec
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "razao_cliente")]
        public string? razao_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "nome_cliente")]
        public string? nome_cliente { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        [LengthValidation(length: 14, propertyName: "doc_cliente")]
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_cliente")]
        public string? tipo_cliente { get; private set; }

        [Column(TypeName = "varchar(250)")]
        [LengthValidation(length: 250, propertyName: "endereco_cliente")]
        public string? endereco_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "numero_rua_cliente")]
        public string? numero_rua_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "complement_end_cli")]
        public string? complement_end_cli { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "bairro_cliente")]
        public string? bairro_cliente { get; private set; }

        [Column(TypeName = "char(9)")]
        [LengthValidation(length: 9, propertyName: "cep_cliente")]
        public string? cep_cliente { get; private set; }

        [Column(TypeName = "varchar(40)")]
        [LengthValidation(length: 40, propertyName: "cidade_cliente")]
        public string? cidade_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "uf_cliente")]
        public string? uf_cliente { get; private set; }

        [Column(TypeName = "varchar(80)")]
        [LengthValidation(length: 80, propertyName: "pais")]
        public string? pais { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "fone_cliente")]
        public string? fone_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "email_cliente")]
        public string? email_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "sexo")]
        public string? sexo { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_cadastro { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_nascimento { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "cel_cliente")]
        public string? cel_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "ativo")]
        public string? ativo { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? dt_update { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "inscricao_estadual")]
        public string? inscricao_estadual { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "incricao_municipal")]
        public string? incricao_municipal { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "identidade_cliente")]
        public string? identidade_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "cartao_fidelidade")]
        public string? cartao_fidelidade { get; private set; }

        [Column(TypeName = "int")]
        public Int32? cod_ibge_municipio { get; private set; }

        [Column(TypeName = "varchar(83)")]
        [LengthValidation(length: 83, propertyName: "classe_cliente")]
        public string? classe_cliente { get; private set; }

        [Column(TypeName = "varchar(20)")]
        [LengthValidation(length: 20, propertyName: "matricula_conveniado")]
        public string? matricula_conveniado { get; private set; }

        [Column(TypeName = "char(1)")]
        [LengthValidation(length: 1, propertyName: "tipo_cadastro")]
        public string? tipo_cadastro { get; private set; }

        [Column(TypeName = "int")]
        public Int32? empresa_cadastro { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_estado_civil { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "fax_cliente")]
        public string? fax_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        [LengthValidation(length: 50, propertyName: "site_cliente")]
        public string? site_cliente { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "bit")]
        public bool? cliente_anonimo { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? limite_compras { get; private set; }

        [Column(TypeName = "varchar(100)")]
        [LengthValidation(length: 100, propertyName: "codigo_ws")]
        public string? codigo_ws { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? limite_credito_compra { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_classe_fiscal { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? obs { get; private set; }

        [Column(TypeName = "varchar(60)")]
        [LengthValidation(length: 60, propertyName: "mae")]
        public string? mae { get; private set; }

        public LinxClientesFornec() { }

        public LinxClientesFornec(
            List<ValidationResult> listValidations,
            string? portal,
            string? cod_cliente,
            string? razao_cliente,
            string? nome_cliente,
            string? doc_cliente,
            string? tipo_cliente,
            string? endereco_cliente,
            string? numero_rua_cliente,
            string? complement_end_cli,
            string? bairro_cliente,
            string? cep_cliente,
            string? cidade_cliente,
            string? uf_cliente,
            string? pais,
            string? fone_cliente,
            string? email_cliente,
            string? sexo,
            string? data_cadastro,
            string? data_nascimento,
            string? cel_cliente,
            string? ativo,
            string? dt_update,
            string? inscricao_estadual,
            string? incricao_municipal,
            string? identidade_cliente,
            string? cartao_fidelidade,
            string? cod_ibge_municipio,
            string? classe_cliente,
            string? matricula_conveniado,
            string? tipo_cadastro,
            string? empresa_cadastro,
            string? id_estado_civil,
            string? fax_cliente,
            string? site_cliente,
            string? timestamp,
            string? cliente_anonimo,
            string? limite_compras,
            string? codigo_ws,
            string? limite_credito_compra,
            string? id_classe_fiscal,
            string? obs,
            string? mae
        )
        {
            lastupdateon = DateTime.Now;

            this.portal =
                ConvertToInt32Validation.IsValid(portal, "portal", listValidations) ?
                Convert.ToInt32(portal) :
                0;

            this.cod_cliente =
                ConvertToInt32Validation.IsValid(cod_cliente, "cod_cliente", listValidations) ?
                Convert.ToInt32(cod_cliente) :
                0;

            this.cod_ibge_municipio =
                ConvertToInt32Validation.IsValid(cod_ibge_municipio, "cod_ibge_municipio", listValidations) ?
                Convert.ToInt32(cod_ibge_municipio) :
                0;

            this.empresa_cadastro =
                ConvertToInt32Validation.IsValid(empresa_cadastro, "empresa_cadastro", listValidations) ?
                Convert.ToInt32(empresa_cadastro) :
                0;

            this.id_estado_civil =
                ConvertToInt32Validation.IsValid(id_estado_civil, "id_estado_civil", listValidations) ?
                Convert.ToInt32(id_estado_civil) :
                0;

            this.id_classe_fiscal =
                ConvertToInt32Validation.IsValid(id_classe_fiscal, "id_classe_fiscal", listValidations) ?
                Convert.ToInt32(id_classe_fiscal) :
                0;

            this.timestamp =
                ConvertToInt64Validation.IsValid(timestamp, "timestamp", listValidations) ?
                Convert.ToInt64(timestamp) :
                0;

            this.dt_update =
                ConvertToDateTimeValidation.IsValid(dt_update, "dt_update", listValidations) ?
                Convert.ToDateTime(dt_update) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_nascimento =
                ConvertToDateTimeValidation.IsValid(data_nascimento, "data_nascimento", listValidations) ?
                Convert.ToDateTime(data_nascimento) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.data_cadastro =
                ConvertToDateTimeValidation.IsValid(data_cadastro, "data_cadastro", listValidations) ?
                Convert.ToDateTime(data_cadastro) :
                new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            this.cliente_anonimo =
                ConvertToBooleanValidation.IsValid(cliente_anonimo, "cliente_anonimo", listValidations) ?
                Convert.ToBoolean(cliente_anonimo) :
                false;

            this.limite_compras =
                ConvertToDecimalValidation.IsValid(limite_compras, "limite_compras", listValidations) ?
                Convert.ToDecimal(limite_compras, new CultureInfo("en-US")) :
                0;

            this.limite_credito_compra =
                ConvertToDecimalValidation.IsValid(limite_credito_compra, "limite_credito_compra", listValidations) ?
                Convert.ToDecimal(limite_credito_compra, new CultureInfo("en-US")) :
                0;

            this.razao_cliente = razao_cliente;
            this.nome_cliente = nome_cliente;
            this.doc_cliente = doc_cliente;
            this.tipo_cliente = tipo_cliente;
            this.endereco_cliente = endereco_cliente;
            this.numero_rua_cliente = numero_rua_cliente;
            this.complement_end_cli = complement_end_cli;
            this.bairro_cliente = bairro_cliente;
            this.cep_cliente = cep_cliente;
            this.cidade_cliente = cidade_cliente;
            this.uf_cliente = uf_cliente;
            this.pais = pais;
            this.fone_cliente = fone_cliente;
            this.email_cliente = email_cliente;
            this.sexo = sexo;
            this.cel_cliente = cel_cliente;
            this.ativo = ativo;
            this.incricao_municipal = incricao_municipal;
            this.inscricao_estadual = inscricao_estadual;
            this.identidade_cliente = identidade_cliente;
            this.cartao_fidelidade = cartao_fidelidade;
            this.classe_cliente = classe_cliente;
            this.matricula_conveniado = matricula_conveniado;
            this.tipo_cadastro = tipo_cadastro;
            this.fax_cliente = fax_cliente;
            this.site_cliente = site_cliente;
            this.codigo_ws = codigo_ws;
            this.obs = obs;
            this.mae = mae;
        }
    }
}
