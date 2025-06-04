using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoTrocafone", Schema = "untreated")]
    public class LinxMovimentoTrocafone
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? num_vale { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? voucher { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_vale { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? nome_produto { get; private set; }

        [Column(TypeName = "varchar(250)")]
        public string? condicao { get; private set; }

        [Column(TypeName = "int")]
        public string? id_tradein_parceiro { get; private set; }
    }
}
