using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce
{
    public class B2CConsultaCNPJsChave
    {
        [Column(TypeName = "datetime")]
        public DateTime? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nome_empresa { get; private set; }

        [Key]
        [Column(TypeName = "smallint")]
        public Int32? id_empresas_rede { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? rede { get; private set; }

        [Column(TypeName = "int")]
        public Int32? portal { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nome_portal { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public Int32? empresa { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? classificacao_portal { get; private set; }

        [Column(TypeName = "bit")]
        public bool? b2c { get; private set; }

        [Column(TypeName = "bit")]
        public bool? oms { get; private set; }

        public B2CConsultaCNPJsChave() { }

        public B2CConsultaCNPJsChave(
            string? cnpj,
            string? nome_empresa,
            string? id_empresas_rede,
            string? rede,
            string? portal,
            string? nome_portal,
            string? empresa,
            string? classificacao_portal,
            string? b2c,
            string? oms
        )
        {
            lastupdateon = DateTime.Now;

            this.cnpj =
                String.IsNullOrEmpty(cnpj) ? ""
                : cnpj.Substring(
                    0,
                    cnpj.Length > 14 ? 14
                    : cnpj.Length
                );

            this.nome_empresa =
                String.IsNullOrEmpty(nome_empresa) ? ""
                : nome_empresa.Substring(
                    0,
                    nome_empresa.Length > 250 ? 250
                    : nome_empresa.Length
                );

            this.id_empresas_rede =
                String.IsNullOrEmpty(id_empresas_rede) ? 0
                : Convert.ToInt32(id_empresas_rede);

            this.rede =
                String.IsNullOrEmpty(rede) ? ""
                : rede.Substring(
                    0,
                    rede.Length > 100 ? 100
                    : rede.Length
                );

            this.nome_portal =
                String.IsNullOrEmpty(nome_portal) ? ""
                : nome_portal.Substring(
                    0,
                    nome_portal.Length > 50 ? 50
                    : nome_portal.Length
                );

            this.empresa =
                String.IsNullOrEmpty(empresa) ? 0
                : Convert.ToInt32(empresa);

            this.classificacao_portal =
                String.IsNullOrEmpty(classificacao_portal) ? ""
                : classificacao_portal.Substring(
                    0,
                    classificacao_portal.Length > 50 ? 50
                    : classificacao_portal.Length
                );

            this.b2c =
                String.IsNullOrEmpty(b2c) ? false
                : Convert.ToBoolean(b2c);

            this.oms =
                String.IsNullOrEmpty(oms) ? false
                : Convert.ToBoolean(oms);

            this.portal =
                String.IsNullOrEmpty(portal) ? 0
                : Convert.ToInt32(portal);
        }
    }
}
