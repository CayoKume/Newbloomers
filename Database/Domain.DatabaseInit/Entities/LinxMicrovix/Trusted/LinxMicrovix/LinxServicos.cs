using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;
using Domain.IntegrationsCore.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxMicrovix
{
    [Table("LinxServicos", Schema = "linx_microvix_erp")]
    public class LinxServicos
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? id_setor { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? cod_servico { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nome { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_setor { get; private set; }

        [Column(TypeName = "int")]
        public string? id_linha { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_linha { get; private set; }

        [Column(TypeName = "int")]
        public string? id_marca { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? desc_marca { get; private set; }

        [Column(TypeName = "datetime")]
        public string? dt_update { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? operacao_servico { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? servico_km { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? desativado { get; private set; }

        [Column(TypeName = "varchar(4)")]
        public string? cod_lc11603 { get; private set; }

        [Column(TypeName = "varchar(20)")]
        public string? codigo_nbs { get; private set; }

        [Column(TypeName = "datetime")]
        public string? dt_inclusao { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? codigo_ws { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }
    }
}
