using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaTransportadores
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_transportador { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_fantasia { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_pessoa { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? tipo_transportador { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? endereco { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? numero_rua { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? bairro { get; private set; }

        [Column(TypeName = "char(9)")]
        public string? cep { get; private set; }

        [Column(TypeName = "varchar(40)")]
        public string? cidade { get; private set; }

        [Column(TypeName = "char(2)")]
        public string? uf { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? documento { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email { get; private set; }

        [Column(TypeName = "varchar(80)")]
        public string? pais { get; private set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? obs { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaTransportadores() { }

        public B2CConsultaTransportadores(
            string? cod_transportador,
            string? nome,
            string? nome_fantasia,
            string? tipo_pessoa,
            string? tipo_transportador,
            string? endereco,
            string? numero_rua,
            string? bairro,
            string? cep,
            string? cidade,
            string? uf,
            string? documento,
            string? fone,
            string? email,
            string? pais,
            string? obs,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_transportador =
                String.IsNullOrEmpty(cod_transportador) ? 0
                : Convert.ToInt32(cod_transportador);

            this.nome =
                String.IsNullOrEmpty(nome) ? ""
                : nome.Substring(
                    0,
                    nome.Length > 60 ? 60
                    : nome.Length
                );

            this.nome_fantasia =
                String.IsNullOrEmpty(nome_fantasia) ? ""
                : nome_fantasia.Substring(
                    0,
                    nome_fantasia.Length > 60 ? 60
                    : nome_fantasia.Length
                );

            this.tipo_pessoa =
                String.IsNullOrEmpty(tipo_pessoa) ? ""
                : tipo_pessoa.Substring(
                    0,
                    tipo_pessoa.Length > 1 ? 1
                    : tipo_pessoa.Length
                );

            this.tipo_transportador =
                String.IsNullOrEmpty(tipo_transportador) ? ""
                : tipo_transportador.Substring(
                    0,
                    tipo_transportador.Length > 1 ? 1
                    : tipo_transportador.Length
                );

            this.endereco =
                String.IsNullOrEmpty(endereco) ? ""
                : endereco.Substring(
                    0,
                    endereco.Length > 250 ? 250
                    : endereco.Length
                );

            this.numero_rua =
                String.IsNullOrEmpty(numero_rua) ? ""
                : numero_rua.Substring(
                    0,
                    numero_rua.Length > 20 ? 20
                    : numero_rua.Length
                );

            this.bairro =
                String.IsNullOrEmpty(bairro) ? ""
                : bairro.Substring(
                    0,
                    bairro.Length > 60 ? 60
                    : bairro.Length
                );

            this.cep =
                String.IsNullOrEmpty(cep) ? ""
                : cep.Substring(
                    0,
                    cep.Length > 9 ? 9
                    : cep.Length
                );

            this.cidade =
                String.IsNullOrEmpty(cidade) ? ""
                : cidade.Substring(
                    0,
                    cidade.Length > 40 ? 40
                    : cidade.Length
                );

            this.uf =
                String.IsNullOrEmpty(uf) ? ""
                : uf.Substring(
                    0,
                    uf.Length > 2 ? 2
                    : uf.Length
                );

            this.documento =
                String.IsNullOrEmpty(documento) ? ""
                : documento.Substring(
                    0,
                    documento.Length > 14 ? 14
                    : documento.Length
                );

            this.fone =
                String.IsNullOrEmpty(fone) ? ""
                : fone.Substring(
                    0,
                    fone.Length > 20 ? 20
                    : fone.Length
                );

            this.email =
                String.IsNullOrEmpty(email) ? ""
                : email.Substring(
                    0,
                    email.Length > 50 ? 50
                    : email.Length
                );

            this.pais =
                String.IsNullOrEmpty(pais) ? ""
                : pais.Substring(
                    0,
                    pais.Length > 80 ? 80
                    : pais.Length
                );

            this.obs =
                String.IsNullOrEmpty(obs) ? ""
                : obs;

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
