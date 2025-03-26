using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaEmpresas", Schema = "linx_microvix_commerce")]
    public class B2CConsultaEmpresas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

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
        public string? timestamp { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_criacao { get; private set; }

        [Column(TypeName = "bit")]
        public string? centro_distribuicao { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
