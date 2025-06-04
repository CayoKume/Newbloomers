using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxMovimentoCartoes", Schema = "untreated")]
    public class LinxMovimentoCartoes
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Key]
        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? codlojasitef { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_lancamento { get; private set; }

        [Key]
        [Column(TypeName = "varchar(20)")]
        public string? cupomfiscal { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? credito_debito { get; private set; }

        [Column(TypeName = "int")]
        public string? id_cartao_bandeira { get; private set; }

        [Column(TypeName = "varchar(100)")]
        public string? descricao_bandeira { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor { get; private set; }

        [Column(TypeName = "int")]
        public string? ordem_cartao { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nsu_host { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nsu_sitef { get; private set; }

        [Key]
        [Column(TypeName = "varchar(50)")]
        public string? cod_autorizacao { get; private set; }

        [Column(TypeName = "int")]
        public string? id_antecipacoes_financeiras { get; private set; }

        [Column(TypeName = "bit")]
        public string? transacao_servico_terceiro { get; private set; }

        [Column(TypeName = "varchar(max)")]
        public string? texto_comprovante { get; private set; }

        [Column(TypeName = "int")]
        public string? id_maquineta_pos { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? descricao_maquineta { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? serie_maquineta { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "varchar(1)")]
        public string? cartao_prepago { get; private set; }
    }
}
