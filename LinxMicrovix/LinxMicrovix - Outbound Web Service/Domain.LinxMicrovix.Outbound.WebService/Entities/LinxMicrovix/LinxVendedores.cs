using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxVendedores
    {
        [Column(TypeName = "datetime")]
        public DateTime lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? cod_vendedor { get; private set; }

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

        [Column(TypeName = "smalldatetime")]
        public DateTime? dt_upd { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cpf_vendedor { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? ativo { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? data_admissao { get; private set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? data_saida { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? matricula { get; private set; }

        [Column(TypeName = "int")]
        public Int32? id_tipo_venda { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao_tipo_venda { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? cargo { get; private set; }

        public LinxVendedores() { }

        public LinxVendedores(
            string? cod_vendedor,
            string? nome_vendedor,
            string? tipo_vendedor,
            string? end_vend_rua,
            string? end_vend_numero,
            string? end_vend_complemento,
            string? end_vend_bairro,
            string? end_vend_cep,
            string? end_vend_cidade,
            string? end_vend_uf,
            string? fone_vendedor,
            string? mail_vendedor,
            string? dt_upd,
            string? cpf_vendedor,
            string? ativo,
            string? data_admissao,
            string? data_saida,
            string? portal,
            string? timestamp,
            string? matricula,
            string? id_tipo_venda,
            string? descricao_tipo_venda,
            string? cargo
        )
        {
            lastupdateon = DateTime.Now;

            this.cod_vendedor =
                cod_vendedor == String.Empty ? 0
                : Convert.ToInt32(cod_vendedor);

            this.nome_vendedor =
                nome_vendedor == String.Empty ? ""
                : nome_vendedor.Substring(
                    0,
                    nome_vendedor.Length > 50 ? 50
                    : nome_vendedor.Length
                );

            this.dt_upd =
                String.IsNullOrEmpty(dt_upd) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(dt_upd);

            this.data_admissao =
                String.IsNullOrEmpty(data_admissao) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_admissao);

            this.data_saida =
                String.IsNullOrEmpty(data_saida) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_saida);

            this.tipo_vendedor =
                tipo_vendedor == String.Empty ? ""
                : tipo_vendedor.Substring(
                    0,
                    tipo_vendedor.Length > 1 ? 1
                    : tipo_vendedor.Length
                );

            this.end_vend_rua =
                end_vend_rua == String.Empty ? ""
                : end_vend_rua.Substring(
                    0,
                    end_vend_rua.Length > 250 ? 250
                    : end_vend_rua.Length
                );

            this.end_vend_numero =
                end_vend_numero == String.Empty ? ""
                : end_vend_numero.Substring(
                    0,
                    end_vend_numero.Length > 20 ? 20
                    : end_vend_numero.Length
                );

            this.end_vend_complemento =
                end_vend_complemento == String.Empty ? ""
                : end_vend_complemento.Substring(
                    0,
                    end_vend_complemento.Length > 60 ? 60
                    : end_vend_complemento.Length
                );

            this.end_vend_bairro =
                end_vend_bairro == String.Empty ? ""
                : end_vend_bairro.Substring(
                    0,
                    end_vend_bairro.Length > 60 ? 60
                    : end_vend_bairro.Length
                );

            this.end_vend_cep =
                end_vend_cep == String.Empty ? ""
                : end_vend_cep.Substring(
                    0,
                    end_vend_cep.Length > 9 ? 9
                    : end_vend_cep.Length
                );

            this.end_vend_cidade =
                end_vend_cidade == String.Empty ? ""
                : end_vend_cidade.Substring(
                    0,
                    end_vend_cidade.Length > 40 ? 40
                    : end_vend_cidade.Length
                );

            this.end_vend_uf =
                end_vend_uf == String.Empty ? ""
                : end_vend_uf.Substring(
                    0,
                    end_vend_uf.Length > 2 ? 2
                    : end_vend_uf.Length
                );

            this.fone_vendedor =
                fone_vendedor == String.Empty ? ""
                : fone_vendedor.Substring(
                    0,
                    fone_vendedor.Length > 20 ? 20
                    : fone_vendedor.Length
                );

            this.mail_vendedor =
                mail_vendedor == String.Empty ? ""
                : mail_vendedor.Substring(
                    0,
                    mail_vendedor.Length > 50 ? 50
                    : mail_vendedor.Length
                );

            this.cpf_vendedor =
                cpf_vendedor == String.Empty ? ""
                : cpf_vendedor.Substring(
                    0,
                    cpf_vendedor.Length > 14 ? 14
                    : cpf_vendedor.Length
                );

            this.ativo =
                ativo == String.Empty ? ""
                : ativo.Substring(
                    0,
                    ativo.Length > 1 ? 1
                    : ativo.Length
                );

            this.matricula =
                String.IsNullOrEmpty(matricula) ? ""
                : matricula.Substring(
                    0,
                    matricula.Length > 30 ? 30
                    : matricula.Length
                );

            this.descricao_tipo_venda =
                descricao_tipo_venda == String.Empty ? ""
                : descricao_tipo_venda.Substring(
                    0,
                    descricao_tipo_venda.Length > 100 ? 100
                    : descricao_tipo_venda.Length
                );

            this.cargo =
                cargo == String.Empty ? ""
                : cargo.Substring(
                    0,
                    cargo.Length > 20 ? 20
                    : cargo.Length
                );

            this.id_tipo_venda =
                id_tipo_venda == String.Empty ? 0
                : Convert.ToInt32(id_tipo_venda);

            this.timestamp =
                timestamp == String.Empty ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                portal == String.Empty ? 0
                : Convert.ToInt32(portal);
        }
    }
}
