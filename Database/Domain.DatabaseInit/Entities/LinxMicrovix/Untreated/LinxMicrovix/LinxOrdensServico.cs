using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxOrdensServico", Schema = "untreated")]
    public class LinxOrdensServico
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "int")]
        public string? numero_os { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_os { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_envio_laboratorio { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "int")]
        public string? id_laboratorio { get; private set; }

        [Column(TypeName = "int")]
        public string? id_posicao_os_ramo_optico { get; private set; }

        [Column(TypeName = "bit")]
        public string? compartilhar_hub_laboratorios { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente_os { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_vendedor { get; private set; }

        [Column(TypeName = "int")]
        public string? numero_sequencial_antecipacao_financeira { get; private set; }

        [Column(TypeName = "varchar(44)")]
        public string? chave_nfe_laboratorio { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
