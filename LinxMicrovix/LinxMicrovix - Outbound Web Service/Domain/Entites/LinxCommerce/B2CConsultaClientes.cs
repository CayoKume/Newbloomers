using Bloomers.Core.Auditoria.Infrastructure.Logger;
using IntegrationsCore.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaClientes
    {
        protected readonly ILoggerAuditoriaService _logger;

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
        public string? doc_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nm_cliente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nm_mae { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nm_pai { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nm_conjuge { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_cadastro { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_nasc_cliente { get; private set; }

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
        public Int32? estado_civil_cliente { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? empresa_cliente { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? cargo_cliente { get; private set; }

        [Column(TypeName = "char(1)")]
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
        public string? naturalidade { get; private set; }

        [Column(TypeName = "tinyint")]
        public Int32? tempo_residencia { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? renda { get; private set; }

        [Column(TypeName = "varchar(10)")]
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
            ILoggerAuditoriaService logger,
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
            _logger = logger;

            lastupdateon = DateTime.Now;

            this.cod_cliente_b2c =
                String.IsNullOrEmpty(cod_cliente_b2c) ? 0
                : Convert.ToInt32(cod_cliente_b2c);

            this.cod_cliente_erp =
                String.IsNullOrEmpty(cod_cliente_erp) ? 0
                : Convert.ToInt32(cod_cliente_erp);

            if (String.IsNullOrEmpty(doc_cliente))
                this.doc_cliente = String.Empty;
            else if (doc_cliente.Length <= 14)
                this.doc_cliente = doc_cliente;
            else
                this.doc_cliente = LengthValidation(_logger, "doc_cliente", doc_cliente, 14);

            if (String.IsNullOrEmpty(nm_cliente))
                this.nm_cliente = String.Empty;
            else if (nm_cliente.Length <= 50)
                this.nm_cliente = nm_cliente;
            else
            {
                _logger.AddLog(
                    level: EnumIdLogLevel.Validations,
                    idError: EnumIdError.LegthValidation,
                    message_log_detalhes_da_ocorrencia: "prop nm_cliente: " + nm_cliente
                );
                this.nm_cliente = nm_cliente.Substring(0, 50);
            }

            this.nm_mae =
                String.IsNullOrEmpty(nm_mae) ? ""
                : nm_mae.Substring(
                    0,
                    nm_mae.Length > 50 ? 50
                    : nm_mae.Length
                );

            this.nm_pai =
                String.IsNullOrEmpty(nm_pai) ? ""
                : nm_pai.Substring(
                    0,
                    nm_pai.Length > 50 ? 50 //add logger //campo 
                    : nm_pai.Length
                );

            this.nm_conjuge =
                String.IsNullOrEmpty(nm_conjuge) ? ""
                : nm_conjuge.Substring(
                    0,
                    nm_conjuge.Length > 50 ? 50
                    : nm_conjuge.Length
                );

            this.dt_cadastro =
                String.IsNullOrEmpty(dt_cadastro) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime( dt_cadastro );

            this.dt_nasc_cliente =
                String.IsNullOrEmpty(dt_nasc_cliente) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_nasc_cliente);

            this.end_cliente =
                String.IsNullOrEmpty(end_cliente) ? ""
                : end_cliente.Substring(
                    0,
                    end_cliente.Length > 250 ? 250
                    : end_cliente.Length
                );

            this.complemento_end_cliente =
                String.IsNullOrEmpty(complemento_end_cliente) ? ""
                : complemento_end_cliente.Substring(
                    0,
                    complemento_end_cliente.Length > 50 ? 50
                    : complemento_end_cliente.Length
                );

            this.nr_rua_cliente =
                String.IsNullOrEmpty(nr_rua_cliente) ? ""
                : nr_rua_cliente.Substring(
                    0,
                    nr_rua_cliente.Length > 20 ? 20
                    : nr_rua_cliente.Length
                );

            this.bairro_cliente =
                String.IsNullOrEmpty(bairro_cliente) ? ""
                : bairro_cliente.Substring(
                    0,
                    bairro_cliente.Length > 60 ? 60
                    : bairro_cliente.Length
                );

            this.cep_cliente =
                String.IsNullOrEmpty(cep_cliente) ? ""
                : cep_cliente.Substring(
                    0,
                    cep_cliente.Length > 9 ? 9
                    : cep_cliente.Length
                );

            this.cidade_cliente =
                String.IsNullOrEmpty(cidade_cliente) ? ""
                : cidade_cliente.Substring(
                    0,
                    cidade_cliente.Length > 40 ? 40
                    : cidade_cliente.Length
                );

            this.uf_cliente =
                String.IsNullOrEmpty(uf_cliente) ? ""
                : uf_cliente.Substring(
                    0,
                    uf_cliente.Length > 2 ? 2
                    : uf_cliente.Length
                );

            this.fone_cliente =
                String.IsNullOrEmpty(fone_cliente) ? ""
                : fone_cliente.Substring(
                    0,
                    fone_cliente.Length > 20 ? 20
                    : fone_cliente.Length
                );

            this.fone_comercial =
                String.IsNullOrEmpty(fone_comercial) ? ""
                : fone_comercial.Substring(
                    0,
                    fone_comercial.Length > 20 ? 20
                    : fone_comercial.Length
                );

            this.cel_cliente =
                String.IsNullOrEmpty(cel_cliente) ? ""
                : cel_cliente.Substring(
                    0,
                    cel_cliente.Length > 20 ? 20
                    : cel_cliente.Length
                );

            this.email_cliente =
                String.IsNullOrEmpty(email_cliente) ? ""
                : email_cliente.Substring(
                    0,
                    email_cliente.Length > 50 ? 50
                    : email_cliente.Length
                );

            this.rg_cliente =
                String.IsNullOrEmpty(rg_cliente) ? ""
                : rg_cliente.Substring(
                    0,
                    rg_cliente.Length > 20 ? 20
                    : rg_cliente.Length
                );

            this.rg_orgao_emissor =
                String.IsNullOrEmpty(rg_orgao_emissor) ? ""
                : rg_orgao_emissor.Substring(
                    0,
                    rg_orgao_emissor.Length > 7 ? 7
                    : rg_orgao_emissor.Length
                );

            this.estado_civil_cliente =
                String.IsNullOrEmpty(estado_civil_cliente) ? 0
                : Convert.ToInt32(estado_civil_cliente);

            this.empresa_cliente =
                String.IsNullOrEmpty(empresa_cliente) ? ""
                : empresa_cliente.Substring(
                    0,
                    empresa_cliente.Length > 30 ? 30
                    : empresa_cliente.Length
                );

            this.cargo_cliente =
                String.IsNullOrEmpty(cargo_cliente) ? ""
                : cargo_cliente.Substring(
                    0,
                    cargo_cliente.Length > 30 ? 30
                    : cargo_cliente.Length
                );

            this.sexo_cliente =
                String.IsNullOrEmpty(sexo_cliente) ? ""
                : sexo_cliente.Substring(
                    0,
                    sexo_cliente.Length > 1 ? 1
                    : sexo_cliente.Length
                );

            this.dt_update =
                String.IsNullOrEmpty(dt_update) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_update);

            this.ativo =
                String.IsNullOrEmpty(ativo) ? 0
                : Convert.ToInt32(ativo);

            this.receber_email =
                String.IsNullOrEmpty(receber_email) ? false
                : Convert.ToBoolean(receber_email);

            this.dt_expedicao_rg =
                String.IsNullOrEmpty(dt_expedicao_rg) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_expedicao_rg);

            this.naturalidade =
                String.IsNullOrEmpty(naturalidade) ? ""
                : naturalidade.Substring(
                    0,
                    naturalidade.Length > 40 ? 40
                    : naturalidade.Length
                );

            this.tempo_residencia =
                String.IsNullOrEmpty(tempo_residencia) ? 0
                : Convert.ToInt32(tempo_residencia);

            this.renda =
                String.IsNullOrEmpty(renda) ? 0
                : Convert.ToDecimal(renda);

            this.numero_compl_rua_cliente =
                String.IsNullOrEmpty(numero_compl_rua_cliente) ? ""
                : numero_compl_rua_cliente.Substring(
                    0,
                    numero_compl_rua_cliente.Length > 10 ? 10
                    : numero_compl_rua_cliente.Length
                );

            this.tipo_pessoa =
                String.IsNullOrEmpty(tipo_pessoa) ? ""
                : tipo_pessoa.Substring(
                    0,
                    tipo_pessoa.Length > 1 ? 1
                    : tipo_pessoa.Length
                );

            this.aceita_programa_fidelidade =
                String.IsNullOrEmpty(aceita_programa_fidelidade) ? false
                : Convert.ToBoolean(aceita_programa_fidelidade);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }

        private string LengthValidation(ILoggerAuditoriaService logger, string propName, string propValue, int propLen)
        {
            if (String.IsNullOrEmpty(propValue))
                return String.Empty;
            else if (propValue.Length <= propLen)
                return propValue;
            else
            {
                _logger.AddLog(
                    level: EnumIdLogLevel.Validations,
                    idError: EnumIdError.LegthValidation,
                    message_log_detalhes_da_ocorrencia: $"prop {propName}: {propValue}"
                );
                return propValue.Substring(0, propLen);
            }
        }
    }
}
