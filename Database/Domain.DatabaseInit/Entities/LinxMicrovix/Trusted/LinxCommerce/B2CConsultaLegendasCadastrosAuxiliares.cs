using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce
{
    [Table("B2CConsultaLegendasCadastrosAuxiliares", Schema = "linx_microvix_commerce")]
    public class B2CConsultaLegendasCadastrosAuxiliares
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_setor { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_linha { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_marca { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_colecao { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_grade1 { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_grade2 { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_espessura { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? legenda_classificacao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
