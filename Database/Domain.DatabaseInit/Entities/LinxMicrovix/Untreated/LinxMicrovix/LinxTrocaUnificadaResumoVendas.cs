using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxTrocaUnificadaResumoVendas", Schema = "untreated")]
    public class LinxTrocaUnificadaResumoVendas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? id_troca_unificada_resumo_vendas { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? token { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "int")]
        public string? documento { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_venda { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? documento_cliente { get; private set; }

        [Column(TypeName = "bit")]
        public string? venda_cancelada { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }
    }
}
