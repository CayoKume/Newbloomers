using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
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

        [Column(TypeName = "money")]
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
                cod_cliente_b2c == String.Empty ? 0
                : Convert.ToInt32(cod_cliente_b2c);

            this.cod_cliente_erp =
                cod_cliente_erp == String.Empty ? 0
                : Convert.ToInt32(cod_cliente_erp);

            this.doc_cliente =
                doc_cliente == String.Empty ? ""
                : doc_cliente.Substring(
                    0,
                    doc_cliente.Length > 14 ? 14
                    : doc_cliente.Length
                );

            this.nm_cliente =
                nm_cliente == String.Empty ? ""
                : nm_cliente.Substring(
                    0,
                    nm_cliente.Length > 50 ? 50
                    : nm_cliente.Length
                );

            this.nm_mae =
                nm_mae == String.Empty ? ""
                : nm_mae.Substring(
                    0,
                    nm_mae.Length > 50 ? 50
                    : nm_mae.Length
                );

            this.nm_pai =
                nm_pai == String.Empty ? ""
                : nm_pai.Substring(
                    0,
                    nm_pai.Length > 50 ? 50
                    : nm_pai.Length
                );

            this.nm_conjuge =
                nm_conjuge == String.Empty ? ""
                : nm_conjuge.Substring(
                    0,
                    nm_conjuge.Length > 50 ? 50
                    : nm_conjuge.Length
                );

            this.dt_cadastro =
                dt_cadastro == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime( dt_cadastro );

            this.dt_nasc_cliente =
                dt_nasc_cliente == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_nasc_cliente);

            this.end_cliente =
                end_cliente == String.Empty ? ""
                : end_cliente.Substring(
                    0,
                    end_cliente.Length > 250 ? 250
                    : end_cliente.Length
                );

            this.complemento_end_cliente =
                complemento_end_cliente == String.Empty ? ""
                : complemento_end_cliente.Substring(
                    0,
                    complemento_end_cliente.Length > 50 ? 50
                    : complemento_end_cliente.Length
                );

            this.nr_rua_cliente =
                nr_rua_cliente == String.Empty ? ""
                : nr_rua_cliente.Substring(
                    0,
                    nr_rua_cliente.Length > 20 ? 20
                    : nr_rua_cliente.Length
                );

            this.bairro_cliente =
                bairro_cliente == String.Empty ? ""
                : bairro_cliente.Substring(
                    0,
                    bairro_cliente.Length > 60 ? 60
                    : bairro_cliente.Length
                );

            this.cep_cliente =
                cep_cliente == String.Empty ? ""
                : cep_cliente.Substring(
                    0,
                    cep_cliente.Length > 9 ? 9
                    : cep_cliente.Length
                );

            this.cidade_cliente =
                cidade_cliente == String.Empty ? ""
                : cidade_cliente.Substring(
                    0,
                    cidade_cliente.Length > 40 ? 40
                    : cidade_cliente.Length
                );

            this.uf_cliente =
                uf_cliente == String.Empty ? ""
                : uf_cliente.Substring(
                    0,
                    uf_cliente.Length > 2 ? 2
                    : uf_cliente.Length
                );

            this.fone_cliente =
                fone_cliente == String.Empty ? ""
                : fone_cliente.Substring(
                    0,
                    fone_cliente.Length > 20 ? 20
                    : fone_cliente.Length
                );

            this.fone_comercial =
                fone_comercial == String.Empty ? ""
                : fone_comercial.Substring(
                    0,
                    fone_comercial.Length > 20 ? 20
                    : fone_comercial.Length
                );

            this.cel_cliente =
                cel_cliente == String.Empty ? ""
                : cel_cliente.Substring(
                    0,
                    cel_cliente.Length > 20 ? 20
                    : cel_cliente.Length
                );

            this.email_cliente =
                email_cliente == String.Empty ? ""
                : email_cliente.Substring(
                    0,
                    email_cliente.Length > 50 ? 50
                    : email_cliente.Length
                );

            this.rg_cliente =
                rg_cliente == String.Empty ? ""
                : rg_cliente.Substring(
                    0,
                    rg_cliente.Length > 20 ? 20
                    : rg_cliente.Length
                );

            this.rg_orgao_emissor =
                rg_orgao_emissor == String.Empty ? ""
                : rg_orgao_emissor.Substring(
                    0,
                    rg_orgao_emissor.Length > 7 ? 7
                    : rg_orgao_emissor.Length
                );

            this.estado_civil_cliente =
                estado_civil_cliente == String.Empty ? 0
                : Convert.ToInt32(estado_civil_cliente);

            this.empresa_cliente =
                empresa_cliente == String.Empty ? ""
                : empresa_cliente.Substring(
                    0,
                    empresa_cliente.Length > 30 ? 30
                    : empresa_cliente.Length
                );

            this.cargo_cliente =
                cargo_cliente == String.Empty ? ""
                : cargo_cliente.Substring(
                    0,
                    cargo_cliente.Length > 30 ? 30
                    : cargo_cliente.Length
                );

            this.sexo_cliente =
                sexo_cliente == String.Empty ? ""
                : sexo_cliente.Substring(
                    0,
                    sexo_cliente.Length > 1 ? 1
                    : sexo_cliente.Length
                );

            this.dt_update =
                dt_update == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_update);

            this.ativo =
                ativo == String.Empty ? 0
                : Convert.ToInt32(ativo);

            this.receber_email =
                receber_email == String.Empty ? false
                : Convert.ToBoolean(receber_email);

            this.dt_expedicao_rg =
                dt_expedicao_rg == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_expedicao_rg);

            this.naturalidade =
                naturalidade == String.Empty ? ""
                : naturalidade.Substring(
                    0,
                    naturalidade.Length > 40 ? 40
                    : naturalidade.Length
                );

            this.tempo_residencia =
                tempo_residencia == String.Empty ? 0
                : Convert.ToInt32(tempo_residencia);

            this.renda =
                renda == String.Empty ? 0
                : Convert.ToDecimal(renda);

            this.numero_compl_rua_cliente =
                numero_compl_rua_cliente == String.Empty ? ""
                : numero_compl_rua_cliente.Substring(
                    0,
                    numero_compl_rua_cliente.Length > 10 ? 10
                    : numero_compl_rua_cliente.Length
                );

            this.tipo_pessoa =
                tipo_pessoa == String.Empty ? ""
                : tipo_pessoa.Substring(
                    0,
                    tipo_pessoa.Length > 1 ? 1
                    : tipo_pessoa.Length
                );

            this.aceita_programa_fidelidade =
                aceita_programa_fidelidade == String.Empty ? false
                : Convert.ToBoolean(aceita_programa_fidelidade);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
