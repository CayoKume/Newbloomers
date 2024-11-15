using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce
{
    public class B2CConsultaClientesContatos
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? id_clientes_contatos { get; private set; }

        [Key]
        [ForeignKey("id_contato_b2c")]
        [Column(TypeName = "int")]
        public Int32? id_contato_b2c { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_contato { get; private set; }

        [Column(TypeName = "datetime")]
        public DateTime? data_nasc_contato { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? sexo_contato { get; private set; }

        [Key]
        [ForeignKey("id_parentesco")]
        [Column(TypeName = "int")]
        public Int32? id_parentesco { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? fone_contato { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? celular_contato { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? email_contato { get; private set; }

        [Column(TypeName = "int")]
        public int? cod_cliente_erp { get; private set; }

        [Column(TypeName = "bigint")]
        public Int64? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        public B2CConsultaClientesContatos() { }

        public B2CConsultaClientesContatos(
            string? id_clientes_contatos,
            string? id_contato_b2c,
            string? nome_contato,
            string? data_nasc_contato,
            string? sexo_contato,
            string? id_parentesco,
            string? fone_contato,
            string? celular_contato,
            string? email_contato,
            string? cod_cliente_erp,
            string? timestamp,
            string? portal
        )
        {
            lastupdateon = DateTime.Now;

            this.id_clientes_contatos =
               String.IsNullOrEmpty(id_clientes_contatos) ? 0
               : Convert.ToInt32(id_clientes_contatos);

            this.id_contato_b2c =
               String.IsNullOrEmpty(id_contato_b2c) ? 0
               : Convert.ToInt32(id_contato_b2c);

            this.nome_contato =
                String.IsNullOrEmpty(nome_contato) ? ""
                : nome_contato.Substring(
                    0,
                    nome_contato.Length > 50 ? 50
                    : nome_contato.Length
                );

            this.data_nasc_contato =
                String.IsNullOrEmpty(data_nasc_contato) ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                : Convert.ToDateTime(data_nasc_contato);

            this.sexo_contato =
                String.IsNullOrEmpty(sexo_contato) ? ""
                : sexo_contato.Substring(
                    0,
                    sexo_contato.Length > 1 ? 1
                    : sexo_contato.Length
                );

            this.id_parentesco =
               String.IsNullOrEmpty(id_parentesco) ? 0
               : Convert.ToInt32(id_parentesco);

            this.fone_contato =
                String.IsNullOrEmpty(fone_contato) ? ""
                : fone_contato.Substring(
                    0,
                    fone_contato.Length > 20 ? 20
                    : fone_contato.Length
                );

            this.celular_contato =
                String.IsNullOrEmpty(celular_contato) ? ""
                : celular_contato.Substring(
                    0,
                    celular_contato.Length > 20 ? 20
                    : celular_contato.Length
                );

            this.email_contato =
                String.IsNullOrEmpty(email_contato) ? ""
                : email_contato.Substring(
                    0,
                    email_contato.Length > 50 ? 50
                    : email_contato.Length
                );

            this.cod_cliente_erp =
               String.IsNullOrEmpty(cod_cliente_erp) ? 0
               : Convert.ToInt32(cod_cliente_erp);

            this.timestamp =
                String.IsNullOrEmpty(timestamp) ? 0
                : Convert.ToInt64(timestamp);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
