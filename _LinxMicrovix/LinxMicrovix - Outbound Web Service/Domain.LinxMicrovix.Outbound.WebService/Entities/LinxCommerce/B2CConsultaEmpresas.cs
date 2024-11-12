using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce
{
    public class B2CConsultaEmpresas
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_emp { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? end_unidade { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? complemento_end_unidade { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? nr_rua_unidade { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro_unidade { get; private set; }

        [Column(TypeName = "varchar(9)")]
        public string? cep_unidade { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? cidade_unidade { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? uf_unidade { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email_unidade { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_criacao { get; private set; }

        [Column(TypeName = "bit")]
        public bool? centro_distribuicao { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaEmpresas() { }

        public B2CConsultaEmpresas(
            string? empresa,
            string? nome_emp,
            string? cnpj_emp,
            string? end_unidade,
            string? complemento_end_unidade,
            string? nr_rua_unidade,
            string? bairro_unidade,
            string? cep_unidade,
            string? cidade_unidade,
            string? uf_unidade,
            string? email_unidade,
            string? timestamp,
            string? data_criacao,
            string? centro_distribuicao,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.nome_emp =
                String.IsNullOrEmpty(nome_emp) ? ""
                : nome_emp.Substring(
                    0,
                    nome_emp.Length > 50 ? 50
                    : nome_emp.Length
                );

            this.cnpj_emp =
                String.IsNullOrEmpty(cnpj_emp) ? ""
                : cnpj_emp.Substring(
                    0,
                    cnpj_emp.Length > 14 ? 14
                    : cnpj_emp.Length
                );

            this.end_unidade =
                String.IsNullOrEmpty(end_unidade) ? ""
                : end_unidade.Substring(
                    0,
                    end_unidade.Length > 250 ? 250
                    : end_unidade.Length
                );

            this.complemento_end_unidade =
                String.IsNullOrEmpty(complemento_end_unidade) ? ""
                : complemento_end_unidade.Substring(
                    0,
                    complemento_end_unidade.Length > 60 ? 60
                    : complemento_end_unidade.Length
                );

            this.nr_rua_unidade =
                String.IsNullOrEmpty(nr_rua_unidade) ? ""
                : nr_rua_unidade.Substring(
                    0,
                    nr_rua_unidade.Length > 20 ? 20
                    : nr_rua_unidade.Length
                );

            this.bairro_unidade =
                String.IsNullOrEmpty(bairro_unidade) ? ""
                : bairro_unidade.Substring(
                    0,
                    bairro_unidade.Length > 60 ? 60
                    : bairro_unidade.Length
                );

            this.cep_unidade =
                String.IsNullOrEmpty(cep_unidade) ? ""
                : cep_unidade.Substring(
                    0,
                    cep_unidade.Length > 9 ? 9
                    : cep_unidade.Length
                );

            this.cidade_unidade =
                String.IsNullOrEmpty(cidade_unidade) ? ""
                : cidade_unidade.Substring(
                    0,
                    cidade_unidade.Length > 50 ? 50
                    : cidade_unidade.Length
                );

            this.uf_unidade =
                String.IsNullOrEmpty(uf_unidade) ? ""
                : uf_unidade.Substring(
                    0,
                    uf_unidade.Length > 2 ? 2
                    : uf_unidade.Length
                );

            this.email_unidade =
                String.IsNullOrEmpty(email_unidade) ? ""
                : email_unidade.Substring(
                    0,
                    email_unidade.Length > 50 ? 50
                    : email_unidade.Length
                );

            this.data_criacao =
                String.IsNullOrEmpty(data_criacao) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_criacao);

            this.centro_distribuicao =
                String.IsNullOrEmpty(centro_distribuicao) ? false
                : Convert.ToBoolean(centro_distribuicao);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
