using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxMicrovix
{
    [Table("LinxFaturas", Schema = "untreated")]
    public class LinxFaturas
    {
        [Column(TypeName = "datetime")]
        public string? lastupdateon { get; private set; }

        [Column(TypeName = "int")]
        public string? portal { get; private set; }

        [Column(TypeName = "varchar(14)")]
        public string? cnpj_emp { get; private set; }

        [Key]
        [Column(TypeName = "bigint")]
        public string? codigo_fatura { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_emissao { get; private set; }

        [Column(TypeName = "int")]
        public string? cod_cliente { get; private set; }

        [Column(TypeName = "varchar(60)")]
        public string? nome_cliente { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_vencimento { get; private set; }

        [Column(TypeName = "datetime")]
        public string? data_baixa { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_fatura { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_pago { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_desconto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_juros { get; private set; }

        [Column(TypeName = "int")]
        public string? documento { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? serie { get; private set; }

        [Column(TypeName = "int")]
        public string? ecf { get; private set; }

        [Column(TypeName = "text")]
        public string? observacao { get; private set; }

        [Column(TypeName = "int")]
        public string? qtde_parcelas { get; private set; }

        [Column(TypeName = "int")]
        public string? ordem_parcela { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? receber_pagar { get; private set; }

        [Column(TypeName = "int")]
        public string? vendedor { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? excluido { get; private set; }

        [Column(TypeName = "char(1)")]
        public string? cancelado { get; private set; }

        [Column(TypeName = "uniqueidentifier")]
        public string? identificador { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? nsu { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? cod_autorizacao { get; private set; }

        [Column(TypeName = "varchar(350)")]
        public string? documento_sem_tef { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? autorizacao_sem_tef { get; private set; }

        [Column(TypeName = "int")]
        public string? plano { get; private set; }

        [Column(TypeName = "bigint")]
        public string? conta_credito { get; private set; }

        [Column(TypeName = "bigint")]
        public string? conta_debito { get; private set; }

        [Column(TypeName = "bigint")]
        public string? conta_fluxo { get; private set; }

        [Column(TypeName = "bigint")]
        public string? cod_historico { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? forma_pgto { get; private set; }

        [Column(TypeName = "int")]
        public string? ordem_cartao { get; private set; }

        [Column(TypeName = "varchar(10)")]
        public string? banco_codigo { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? banco_agencia { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? banco_conta { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? banco_autorizacao_garantidora { get; private set; }

        [Column(TypeName = "varchar(30)")]
        public string? numero_bilhete_seguro { get; private set; }

        [Column(TypeName = "bigint")]
        public string? timestamp { get; private set; }

        [Column(TypeName = "int")]
        public string? empresa { get; private set; }

        [Column(TypeName = "int")]
        public string? id_categorias_financeiras { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? taxa_financeira { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_abatimento { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? valor_multa { get; private set; }

        [Column(TypeName = "int")]
        public string? centrocusto { get; private set; }

        [Column(TypeName = "decimal(10,2)")]
        public string? perc_taxa_adquirente { get; private set; }

        [Column(TypeName = "varchar(50)")]
        public string? fatura_origem_importacao_erp { get; private set; }
    }
}
